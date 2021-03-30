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

from datetime import datetime

import update_check_main
import update_check_func


def load_gui(self):

    # Defines tkinter GUI widgets
    self.lbl_src = tk.Label(self.master,text='Browse for source folder:',bg="#037365",fg="#fff",font = "20")
    self.lbl_src.grid(row=0,column=0,columnspan=2,padx=(20,0),pady=(10,10),sticky=N+W)
    self.lbl_dest = tk.Label(self.master,text='Browse for destination folder:',bg="#037365",fg="#fff",font = "20")
    self.lbl_dest.grid(row=2,column=0,columnspan=2,padx=(20,0),pady=(10,10),sticky=N+W)

    self.source = StringVar()
    self.source.set("Select a folder")
    self.destination = StringVar()
    self.destination.set("Select a folder")
    self.transfer = StringVar()
    self.transfer.set('')
    self.txt_src = tk.Entry(self.master,width=38,text=self.source,fg="#00281f",font = "15")
    self.txt_src.grid(row=1,column=1,padx=(18,0),pady=(8,0),ipady=(8),sticky=N+W)
    self.txt_dest = tk.Entry(self.master,width=38,text=self.destination,fg="#00281f",font = "15")
    self.txt_dest.grid(row=3,column=1,padx=(18,0),pady=(8,0),ipady=(8),sticky=N+W)
    self.txt_trans = tk.Entry(self.master,width=38,text=self.transfer,fg="#00281f",font = "15")
    self.txt_trans.grid(row=4,column=1,padx=(18,0),pady=(28,0),ipady=(8),sticky=N+W)

    self.btn_src = tk.Button(self.master,width=10,height=2,text='Browse',command=lambda: update_check_func.browse_src(self),bg="#7bd4cc",fg="#00281f",font = "16")
    self.btn_src.grid(row=1,column=0,padx=(20,0),pady=(0,0),sticky=N+W)
    self.btn_dest = tk.Button(self.master,width=10,height=2,text='Browse',command=lambda: update_check_func.browse_dest(self),bg="#7bd4cc",fg="#00281f",font = "16")
    self.btn_dest.grid(row=3,column=0,padx=(20,0),pady=(0,0),sticky=N+W)
    self.btn_trans = tk.Button(self.master,width=10,height=2,text='Transfer',command=lambda: update_check_func.start(self),bg="#7bd4cc",fg="#00281f",font = "16")
    self.btn_trans.grid(row=4,column=0,padx=(20,0),pady=(20,0),sticky=N+W)

    update_check_func.create_db(self)

    if update_check_func.retrieve_update(self)[0] == 0.0:
        self.transfer.set('No updates have yet been performed.')    
    else:      
        self.transfer.set('Last update check: ' + str(datetime.fromtimestamp(update_check_func.retrieve_update(self)[0]).ctime()))



if __name__ == "__main__":
    pass
