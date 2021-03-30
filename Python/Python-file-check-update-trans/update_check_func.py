
#!/usr/bin/python
# -*- coding: utf-8 -*-
# Python Ver:   3.6.0
#
# Author:       Daniel Wallace
#
# Purpose:      Tech Academy Python Drill - Item 64 - copy updated files
#               Copies files which have been updated within the last 24 hours from a
#               source folder to a destination folder.
#
#               DB creation currently includes a drop table statement. Remove in order for last update values to persist.


from tkinter import *
import tkinter as tk
import sqlite3

from tkinter.filedialog import askopenfilename
import os, shutil

from datetime import timedelta, datetime 
from time import time, strftime

from tkinter import messagebox

import update_check_main
import update_check_gui


def start(self):
    # Retrieves values set by user's directory choice
    src = self.source.get()
    dest = self.destination.get()
    if src != 'Select a folder' and dest != 'Select a folder' and src != dest:
        if src != '' and dest != '':
            current_time = time()
            file_check(self,src,dest)
            add_update(self,current_time)
            # Updates text displaying time of last update check run
            self.transfer.set('Last update check: ' + str(datetime.fromtimestamp(current_time).ctime()))
        else:
            messagebox.showinfo('Transfer Cancelled', 'You have either not chosen a source and or destination or you have chosen the source as destination. Try again please')
    else:
        messagebox.showinfo('Transfer Cancelled', 'You have either not chosen a source and or destination or you have chosen the source as destination. Try again please')


def file_check(self,src,dest):
    last_transfer = retrieve_update(self)
    # Adjusts path to directory
    path = src[2:] + '/' 
    files = os.listdir(path)
    count = 0
    for f in files:
        # Attaches file name
        source_path = path + f
        # Determines time of last file modification 
        last_file_update = os.path.getmtime(source_path)  
        # If timestamp of the file's last modification is later than timestamp of the last update check, copy file to dest
        if last_file_update > last_transfer[0]:
            shutil.copy(source_path,dest)
            count += 1
    messagebox.showinfo('Transfer Sucessful', '' + str(count) + ' updated or new file(s) have been transferred.')


# Browse and set file paths
def browse_src(self):
    src = browse_func(self)
    self.source.set(src)
    
 
def browse_dest(self):
    dest = browse_func(self)
    self.destination.set(dest)
    
    
def browse_func(self):
    return tk.filedialog.askdirectory()


# --------------------------------------------------------    

# Centers tkinter master frame
def center_window(self, w, h): 
    # get user's screen width and height
    screen_width = self.master.winfo_screenwidth()
    screen_height = self.master.winfo_screenheight()
    # calculate x and y coordinates 
    x = int((screen_width/2) - (w/2))
    y = int((screen_height/2) - (h/2))
    centerGeo = self.master.geometry('{}x{}+{}+{}'.format(w, h, x, y))
    return centerGeo


# Catch user's click on windows upper-right 'X', ensure they want to close
def ask_quit(self):
    if messagebox.askokcancel("Exit program", "Okay to exit application?"):
        self.master.destroy()
        os._exit(0)


# --------------------------------------------------------

# Database Creation
def create_db(self):
    conn = sqlite3.connect('db_update_check.db')
    with conn:
        cur = conn.cursor()
        cur.execute("DROP TABLE if exists tbl_updates;")
        cur.execute("CREATE TABLE if not exists tbl_updates( \
            ID INTEGER PRIMARY KEY AUTOINCREMENT, \
            last_update REAL \
            );")
        cur.execute("""INSERT INTO tbl_updates (last_update) VALUES (0.0)""")
        conn.commit()
    conn.close()


# Insert most recent timestamp into Db
def add_update(self,current_time):
    conn = sqlite3.connect('db_update_check.db')    
    with conn:
        cur = conn.cursor()
        cur.execute("""INSERT INTO tbl_updates (last_update) VALUES (?)""",(current_time,))
        conn.commit()
    conn.close()


# Retrieve timestamp of most recent update check from Db
def retrieve_update(self):
    conn = sqlite3.connect('db_update_check.db')
    with conn:
        cur = conn.cursor()
        cur = cur.execute("""SELECT last_update FROM tbl_updates WHERE id=(SELECT MAX(id) FROM tbl_updates);""")
        update_time = cur.fetchone()
        return update_time
        conn.commit()
    conn.close()
    

if __name__ == '__main__':
    pass
