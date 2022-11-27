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
in_filename = 'main.py'
fin = open(in_filename, 'r')
in_lines = [_line.rstrip('\r\n') for _line in fin.readlines()]
fin.close()


#
START_STRING = "HandyAutomatedLLSTransferSystemBackClipService..".encode('utf-8')


#
ALT_IMG_WIDTH = 800
ALT_IMG_HEIGHT = 600
ALT_CELL_LEN = 1



#
cell_width  = int(ALT_IMG_WIDTH / ALT_CELL_LEN)
cell_height = int(ALT_IMG_HEIGHT / ALT_CELL_LEN)
cell_len    = int(ALT_CELL_LEN)
alt_cell_width  = -cell_width
alt_cell_height = -cell_height
alt_cell_len    = -cell_len
bytes_cell_width  = alt_cell_width.to_bytes(2,  byteorder="little", signed=True)
bytes_cell_height = alt_cell_height.to_bytes(2, byteorder="little", signed=True)
bytes_cell_len    = alt_cell_len.to_bytes(2,    byteorder="little", signed=True)


text = 'Lorem Ipsum'
ba_text_utf8 = text.encode('utf-8')
ba_text_base64 = base64.b64encode(ba_text_utf8)


##
#sb = StringBuffer(lines=in_lines)
#
#
##
#while sb.reading():
#    line = sb.getline()
#
#    print(line)


print(text)
print(ba_text_utf8)
print(ba_text_base64)


#
ba_encoded_text = START_STRING + bytes_cell_width + bytes_cell_height + bytes_cell_len + ba_text_base64
print(ba_encoded_text)


#
from PIL import Image


#
def get_byte(ba_encoded_text, i: int):
    if len(ba_encoded_text) > i:
        return ba_encoded_text[i]
    return 0


#
out_bmp = Image.new('RGB', (800, 600))

#
i = 0
for yi in range(600):
    for xi in range(800):
        byte_r = get_byte(ba_encoded_text, 3 * i)
        byte_g = get_byte(ba_encoded_text, 3 * i + 1)
        byte_b = get_byte(ba_encoded_text, 3 * i + 2)

        #out_bmp[xi, yi] = (byte_r, byte_g, byte_b)

        # https://stackoverflow.com/questions/36468530/changing-pixel-color-value-in-pil
        out_bmp.putpixel( (xi, yi), (byte_r, byte_g, byte_b) )
        
        i += 1

#
#out_bmp.frombytes(ba_encoded_text)
out_bmp.save('out.bmp')



