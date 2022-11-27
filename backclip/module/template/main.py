#
#
#
#
#
import sys
import os
import re

#
from StringBuffer import StringBuffer

#
import base64

#
from PIL import Image


#
START_STRING = "HandyAutomatedLLSTransferSystemBackClipService..".encode('utf-8')


#
in_width = int(sys.argv[1])
in_height = int(sys.argv[2])
in_cell_len = int(sys.argv[3])
in_filename = sys.argv[4]
out_bmp_filename = sys.argv[5]


#
def get_byte(ba_encoded_text, i: int):
    if len(ba_encoded_text) > i:
        return ba_encoded_text[i]
    return 0


#
def run(ALT_IMG_WIDTH: int, ALT_IMG_HEIGHT: int, ALT_CELL_LEN: int, in_filename: str, out_bmp_filename: str):
    cell_width  = int(ALT_IMG_WIDTH / ALT_CELL_LEN)
    cell_height = int(ALT_IMG_HEIGHT / ALT_CELL_LEN)
    cell_len    = int(ALT_CELL_LEN)
    alt_cell_width  = -cell_width
    alt_cell_height = -cell_height
    alt_cell_len    = -cell_len
    bytes_cell_width  = alt_cell_width.to_bytes(2,  byteorder="little", signed=True)
    bytes_cell_height = alt_cell_height.to_bytes(2, byteorder="little", signed=True)
    bytes_cell_len    = alt_cell_len.to_bytes(2,    byteorder="little", signed=True)

    #
    with open(in_filename, 'rb') as fin:
        bin_data = fin.read()

    ##
    #text = in_text
    #ba_text_utf8 = text.encode('utf-8')
    #ba_text_base64 = base64.b64encode(ba_text_utf8)

    #
    ba_text_base64 = base64.b64encode(bin_data)
    ba_encoded_text = START_STRING + bytes_cell_width + bytes_cell_height + bytes_cell_len + ba_text_base64

    #
    out_bmp = Image.new('RGB', (ALT_IMG_WIDTH, ALT_IMG_HEIGHT))

    #
    i = 0
    for yi in range(cell_height):
        for xi in range(cell_width):
            byte_r = get_byte(ba_encoded_text, 3 * i)
            byte_g = get_byte(ba_encoded_text, 3 * i + 1)
            byte_b = get_byte(ba_encoded_text, 3 * i + 2)
            #print('==========')
            #print(f'(xi,yi)=({xi},{yi})')

            # https://stackoverflow.com/questions/36468530/changing-pixel-color-value-in-pil
            #out_bmp[xi, yi] = (byte_r, byte_g, byte_b)
            #out_bmp.putpixel( (xi, yi), (byte_r, byte_g, byte_b) )
            #print('--------')
            for yi1 in range(cell_len):
                for xi1 in range(cell_len):
                    x = cell_len * xi + xi1
                    y = cell_len * yi + yi1
                    #print(f'(x,y)=({x},{y})')
                    out_bmp.putpixel( (x, y), (byte_r, byte_g, byte_b) )
            
            i += 1

    #
    out_bmp.save(out_bmp_filename)
    with open(out_bmp_filename + '.txt', 'w') as fout:
        print(ba_text_base64.decode(), file=fout)


#
run(
    ALT_IMG_WIDTH=in_width,
    ALT_IMG_HEIGHT=in_height,
    ALT_CELL_LEN=in_cell_len,
    in_filename=in_filename,
    out_bmp_filename=out_bmp_filename,
    )


##
#in_filename = 'main.py'
#fin = open(in_filename, 'r')
#in_lines = [_line.rstrip('\r\n') for _line in fin.readlines()]
#fin.close()
##
#sb = StringBuffer(lines=in_lines)
#
#
##
#while sb.reading():
#    line = sb.getline()
#
#    print(line)
