using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



/// <summary>
/// 
/// </summary>
namespace ALT
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Form
    {
        #region 상수를 정의합니다.
        /// <summary>
        /// 
        /// </summary>
        public const string STR2BMP_FILENAME = "str.bmp";
        /// <summary>
        /// 
        /// </summary>
        public const string TMP_STR2BMP_FILENAME = "tmp.str.bmp";
        /// <summary>
        /// 
        /// </summary>
        public const string START_STRING = "HandyAutomatedLLSTransferSystemBackClipService..";
        /// <summary>
        /// 
        /// </summary>
        public int CELL_LEN => int.Parse(_textBox_CellLen.Text);


        /// <summary>
        /// 
        /// </summary>
        string _textBase64;
        /// <summary>
        /// 
        /// </summary>
        byte[] _bytesTextBase64;
        /// <summary>
        /// 
        /// </summary>
        public string _TextBase64
        {
            get
            {
                return _textBase64;
            }
            set
            {
                _textBase64 = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public byte[] _BytesTextBase64
        {
            get
            {
                return _bytesTextBase64;
            }
            set
            {
                _bytesTextBase64 = value;
            }
        }

        #endregion





        #region 생성자를 정의합니다.
        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion





        #region 보조 메서드를 정의합니다.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="byteArray"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        static int GetByte(byte[] byteArray, int index)
        {
            return byteArray.Length > index ? byteArray[index] : 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        static bool WriteBitmap(Bitmap bitmap, string filename)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
                {
                    bitmap.Save(memory, ImageFormat.Bmp);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Bitmap ReadBitmap(string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                Bitmap bitmapSource = Bitmap.FromStream(fs) as Bitmap;
                Bitmap bitmap = bitmapSource.Clone(new Rectangle(Point.Empty, bitmapSource.Size), PixelFormat.Format32bppArgb);
                return bitmap;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isTouched"></param>
        /// <param name="xi"></param>
        /// <param name="yi"></param>
        /// <param name="bitmap"></param>
        /// <param name="txtColors"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        bool FoundMatchingText(
            bool[,] isTouched,
            int xi,
            int yi,
            Bitmap bitmap,
            Color[] txtColors,
            out int width,
            out int height,
            out int cellLen
            )
        {
            width = -1;
            height = -1;
            cellLen = -1;

            // 이미 검사한 지점이라면 그냥 지나갑니다.
            if (isTouched[xi, yi])
            {
                return false;
            }
            isTouched[xi, yi] = true;

            //
            for (int i = 0; i < txtColors.Length; ++i)
            {
                // 시작 문자열은 가로로만 존재한다고 가정합니다.
                int x = CELL_LEN * (xi + i);
                int y = CELL_LEN * (yi);

                // 이미지 크기를 넘는다면 적절하지 않은 위치입니다.
                if (x >= bitmap.Width)
                {
                    return false;
                }

                //
                Color color = bitmap.GetPixel(x, y);
                if (color != txtColors[i])
                {
                    return false;
                }

                //
                isTouched[xi + i, yi] = true;
            }

            //
            int x0 = CELL_LEN * (xi + txtColors.Length);
            int y0 = CELL_LEN * yi;
            Color c0 = bitmap.GetPixel(x0, y0);
            int x1 = CELL_LEN * (xi + txtColors.Length + 1);
            int y1 = CELL_LEN * yi;
            Color c1 = bitmap.GetPixel(x1, y1);
            byte[] bytesWidth = { c0.R, c0.G };
            byte[] bytesHeight = { c0.B, c1.R };
            byte[] bytesCellLen = { c1.G, c1.B };

            //
            width = -BitConverter.ToInt16(bytesWidth, 0);
            height = -BitConverter.ToInt16(bytesHeight, 0);
            cellLen = -BitConverter.ToInt16(bytesCellLen, 0);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static Color[] GetColorsFromString(string text)
        {
            byte[] baText = Encoding.UTF8.GetBytes(text);
            int chunkCount = (int)Math.Ceiling(baText.Length / 3.0);

            //
            List<Color> colors = new List<Color>();
            for (int i = 0; i < chunkCount; ++i)
            {
                int red = GetByte(baText, 3 * i);
                int green = GetByte(baText, 3 * i + 1);
                int blue = GetByte(baText, 3 * i + 2);
                Color color = Color.FromArgb(red: red, green: green, blue: blue);
                colors.Add(color);
            }
            return colors.ToArray();
        }

        #endregion





        #region 이벤트 핸들러를 정의합니다.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _button_ConvertText_Click(object sender, EventArgs e)
        {
            int MAX_PIXEL_WIDTH = 800;
            int MAX_PIXEL_HEIGHT = 600;
            int MAX_CELL_WIDTH = MAX_PIXEL_WIDTH / CELL_LEN;
            int MAX_CELL_HEIGHT = MAX_PIXEL_HEIGHT / CELL_LEN;
            Bitmap bitmap = new Bitmap(MAX_PIXEL_WIDTH, MAX_PIXEL_HEIGHT);

            //
            string text0 = _textBox_str.Text;
            byte[] baText0 = Encoding.UTF8.GetBytes(text0);
            _textBase64 = Convert.ToBase64String(baText0);
            _BytesTextBase64 = Encoding.UTF8.GetBytes(_textBase64);

            //
            byte[] bytesHeaderStart = Encoding.UTF8.GetBytes(START_STRING);
            List<byte> bytesHeaderInfo = new List<byte>();

            //
            short width = (short)-MAX_CELL_WIDTH;
            short height = (short)-MAX_CELL_HEIGHT;
            short cellLen = (short)-CELL_LEN;

            //
            bytesHeaderInfo.AddRange(BitConverter.GetBytes(width));
            bytesHeaderInfo.AddRange(BitConverter.GetBytes(height));
            bytesHeaderInfo.AddRange(BitConverter.GetBytes(cellLen));
            var bytesHeader = bytesHeaderStart.Concat(bytesHeaderInfo);

            //
            byte[] baEncodedText = bytesHeader.Concat(_BytesTextBase64).ToArray();
            int chunkCount = (int)Math.Ceiling(baEncodedText.Length / 3.0);

            //
            //Console.WriteLine("==================================");
            for (int i = 0; i < chunkCount; ++i)
            {
                int red = GetByte(baEncodedText, 3 * i);
                int green = GetByte(baEncodedText, 3 * i + 1);
                int blue = GetByte(baEncodedText, 3 * i + 2);
                Color color = Color.FromArgb(red: red, green: green, blue: blue);

                //
                int cellX = i % MAX_CELL_WIDTH;
                int cellY = i / MAX_CELL_WIDTH;

                //
                try
                {
                    for (int pixelY = 0; pixelY < CELL_LEN; ++pixelY)
                    {
                        for (int pixelX = 0; pixelX < CELL_LEN; ++pixelX)
                        {
                            bitmap.SetPixel(CELL_LEN * cellX + pixelX, CELL_LEN * cellY + pixelY, color);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {

                }

                //
                //Console.WriteLine("(x={0}, y={1}) == (r={2}, g={3}, b={4})", x, y, red, green, blue);
            }
            //Console.WriteLine("----------------------------------");

            //
            //MemoryStream memoryStream = new MemoryStream(bitmapdata);
            //Bitmap bitmap = new Bitmap(memoryStream);

            //
            WriteBitmap(bitmap, TMP_STR2BMP_FILENAME);
            FileInfo fileInfo = new FileInfo(TMP_STR2BMP_FILENAME);
            int fileSize = (int)fileInfo.Length / 1024;

            //
            _textBox_imageInfo.Text = string.Format("{0} x {1} = ({2} x {3}) / {4}^2, {5} KB",
                MAX_CELL_WIDTH, MAX_CELL_HEIGHT, MAX_PIXEL_WIDTH, MAX_PIXEL_HEIGHT, CELL_LEN, fileSize);

            //
            _textBox_InputBase64.Text = _TextBase64;

            //
            _textBox_imageInfo2.Text = string.Format("baText.Length = {0}, chunkCount = {1}", baEncodedText.Length, chunkCount);

            //
            _pictureBox_bmp.Image = bitmap;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _button_SaveImage_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = _pictureBox_bmp.Image as Bitmap;
            if (bitmap == null)
            {
                return;
            }

            //
            WriteBitmap(bitmap, STR2BMP_FILENAME);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _button_LoadImage_Click(object sender, EventArgs e)
        {
            //
            using (FileStream fs = new FileStream(STR2BMP_FILENAME, FileMode.Open, FileAccess.Read))
            {
                Bitmap bitmapSource = Bitmap.FromStream(fs) as Bitmap;
                Bitmap bitmap = bitmapSource.Clone(new Rectangle(Point.Empty, bitmapSource.Size), PixelFormat.Format32bppArgb);
                _pictureBox_bmp.Image?.Dispose();
                _pictureBox_bmp.Image = bitmap;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="x0"></param>
        /// <param name="y0"></param>
        /// <param name="cellWidth"></param>
        /// <param name="cellHeight"></param>
        /// <returns></returns>
        bool ParseAltBackClipBitmap(
            Bitmap bitmap,
            int x0,
            int y0,
            int cellWidth,
            int cellHeight,
            int cellLen,
            out byte[] bytes
            )
        {
            if (bitmap == null)
            {
                bytes = null;
                return false;
            }

            /*
            List<byte> blText = new List<byte>();
            for (int xi = 0; xi < START_STRING.Length + 6; ++xi)
            {
                Color color = bitmap.GetPixel(x0 + CELL_LEN * xi, y0);
                blText.AddRange(new byte[]{ color.R, color.G, color.B });
            }
            byte[] baFirst = blText.ToArray();
            int MAX_PIXEL_WIDTH = -BitConverter.ToInt16(baFirst, START_STRING.Length);
            int MAX_PIXEL_HEIGHT = -BitConverter.ToInt16(baFirst, START_STRING.Length + 2);
            */
            int MAX_CELL_WIDTH = cellWidth; // cellLen;
            int MAX_CELL_HEIGHT = cellHeight; // cellLen;

            //
            List<byte> blText = new List<byte>();

            //
            int headerStartIndex = (START_STRING.Length + 6) / 3;
            for (int xi = headerStartIndex; xi < MAX_CELL_WIDTH; ++xi)
            {
                Color color = bitmap.GetPixel(x0 + cellLen * xi, y0);

                /*
                byte[] bytes = { color.R, color.G, color.B };
                Console.WriteLine("{0}", Encoding.UTF8.GetString(bytes));
                */

                //
                byte red = color.R;
                if (red == 0)
                {
                    goto EndOfImage;
                }
                blText.Add(red);

                //
                byte green = color.G;
                if (green == 0)
                {
                    goto EndOfImage;
                }
                blText.Add(green);

                //
                byte blue = color.B;
                if (blue == 0)
                {
                    goto EndOfImage;
                }
                blText.Add(blue);
            }
            for (int yi = 1; yi < MAX_CELL_HEIGHT; ++yi)
            {
                for (int xi = 0; xi < MAX_CELL_WIDTH; ++xi)
                {
                    Color color = bitmap.GetPixel(x0 + cellLen * xi, y0 + cellLen * yi);

                    /*
                    byte[] bytes = { color.R, color.G, color.B };
                    Console.WriteLine("{0}", Encoding.UTF8.GetString(bytes));
                    */

                    //
                    byte red = color.R;
                    if (red == 0)
                    {
                        goto EndOfImage;
                    }
                    blText.Add(red);

                    //
                    byte green = color.G;
                    if (green == 0)
                    {
                        goto EndOfImage;
                    }
                    blText.Add(green);

                    //
                    byte blue = color.B;
                    if (blue == 0)
                    {
                        goto EndOfImage;
                    }
                    blText.Add(blue);
                }
            }
        EndOfImage:
            //blText.Add(0);

            /*
            byte[] baEncodedText = blText.ToArray();
            //string headerString = BitConverter.ToString(baEncodedText, 0, START_STRING.Length);

            //
            _BytesTextBase64 = new byte[baEncodedText.Length - headerStartIndex];
            Array.Copy(
                sourceArray: baEncodedText,
                sourceIndex: START_STRING.Length + 6,
                destinationArray: _BytesTextBase64,
                destinationIndex: 0,
                length: _BytesTextBase64.Length
                );
            */
            _BytesTextBase64 = blText.ToArray();
            _TextBase64 = Encoding.UTF8.GetString(_BytesTextBase64);
            bytes = Convert.FromBase64String(_TextBase64);
            string text = Encoding.UTF8.GetString(bytes);

            //
            _textBox_ParsedText64.Text = _TextBase64;
            _textBox_ParseResult.Text = text;

            //
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _button_ParseImage_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = _pictureBox_bmp.Image as Bitmap;
            if (ParseAltBackClipBitmap(
                bitmap: bitmap,
                x0: 0,
                y0: 0,
                cellWidth: bitmap.Width,
                cellHeight: bitmap.Height,
                cellLen: CELL_LEN,
                bytes: out byte[] bytes
                ) == false)
            {
                return;
            }
            Console.WriteLine("Good");
        }
        /// <summary>
        /// 이미지를 사선으로 읽고 시작점을 찾은 후 해당 지점부터 파싱 합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _button_LoadImage2_Click(object sender, EventArgs e)
        {
            //
            const string INPUT_FILENAME = @"C:\Users\rbfwm\Desktop\str2.bmp";
            Bitmap bitmap = ReadBitmap(INPUT_FILENAME);

            //
            int maxCellWidth = bitmap.Width / CELL_LEN;
            int maxCellHeight = bitmap.Height / CELL_LEN;
            bool[,] isTouched = new bool[maxCellWidth, maxCellHeight];

            //
            Color[] txtColors = GetColorsFromString(START_STRING);
            //Color[] txtColors = GetColorsFromString("SGFuZHlBdXRvbWF0ZWRMTFNUcmFuc2ZlclN5c3RlbUJhY2tDbGlwU2VydmljZS4u");

            //
            int targetXi = -1;
            int targetYi = -1;
            int width = -1;
            int height = -1;
            int cellLen = -1;
            for (int dist = 0; dist < maxCellWidth; ++dist)
            {
                //Console.WriteLine("d = {0}", dist);
                for (int yi = 0; yi <= dist; ++yi)
                {
                    int xi = dist - yi;

                    //
                    if (xi >= maxCellWidth || yi >= maxCellHeight)
                    {
                        continue;
                    }

                    //
                    if (FoundMatchingText(
                        isTouched,
                        xi,
                        yi,
                        bitmap,
                        txtColors,
                        out width,
                        out height,
                        out cellLen
                        ))
                    {
                        targetXi = xi;
                        targetYi = yi;
                        goto LabelOnMatchingTextFound;
                    }
                }
            }
            return;

        LabelOnMatchingTextFound:
            Console.WriteLine("위치: ({0}, {1})", targetXi, targetYi);
            Console.WriteLine("크기: ({0}, {1})", width, height);
            Console.WriteLine("길이: ({0})", cellLen);

            //
            byte[] bytes;
            if (ParseAltBackClipBitmap(
                bitmap: bitmap,
                x0: cellLen * targetXi,
                y0: cellLen * targetYi,
                cellWidth: width,
                cellHeight: height,
                cellLen: cellLen,
                bytes: out bytes
                ) == false)
            {
                return;
            }

            //
            Console.WriteLine("Fetch done...");

            //
            File.WriteAllBytes("archive.tar.gz", bytes);

            //
            Console.WriteLine("Decoding done...");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
