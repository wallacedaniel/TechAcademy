# -*- coding: utf-8 -*-
# Python Ver:   2.7.13
#
# Author:       Daniel Wallace
#
# Purpose:      Tech Academy Python Drill - Item 63 - file transfer
#               Copies Files from a folderA on the desktop to folderB on the desktop


import os, shutil

def start():
    trans_req = raw_input('\nPress T to transfer your files. ').capitalize()
    if trans_req == 'T':
        
        path = '/Users/Student/Desktop/folderA/'
        move_to = '/Users/Student/Desktop/folderB/'
        
        files = os.listdir(path)
        
        for f in files:
            src = path + f
            dst = move_to + f
            shutil.move(src,dst)
            print(src + ' has been transfered.')
        
        print('Your files have been successfully transfered.')
        
    else:
        print('\nYou need to press T to transfer your files. Try again please')
        start()


if __name__ == '__main__':
    start()

    

