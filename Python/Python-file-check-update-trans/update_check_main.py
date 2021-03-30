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

import update_check_gui
import update_check_func


# Tkinter frame class that our class will inherit from
class ParentWindow(Frame):
    def __init__(self, master, *args, **kwargs):
        Frame.__init__(self, master, *args, **kwargs)

        # Defines master frame configuration
        self.master = master
        self.master.minsize(600,325) 
        self.master.maxsize(600,325)
        # Center's on users screen
        update_check_func.center_window(self,500,300)
        self.master.title("Check Modified Files")
        self.master.configure(bg="#037365")
        # Catch if user clicks the upper corner, "X" on Windows OS.
        self.master.protocol("WM_DELETE_WINDOW", lambda: update_check_func.ask_quit(self))
        arg = self.master
        
        # Load in the GUI widgets 
        update_check_gui.load_gui(self)
        
        # Instantiate the Tkinter menu dropdown object
        menubar = Menu(self.master)
        filemenu = Menu(menubar, tearoff=0)
        filemenu.add_separator()
        filemenu.add_command(label="Exit", underline=1,accelerator="Ctrl+Q",command=lambda: update_check_func.ask_quit(self))
        menubar.add_cascade(label="File", underline=0, menu=filemenu)
        helpmenu = Menu(menubar, tearoff=0) 
        helpmenu.add_separator()
        helpmenu.add_command(label="How to use this program")
        helpmenu.add_separator()
        helpmenu.add_command(label="About this update checker") 
        menubar.add_cascade(label="Help", menu=helpmenu)
        
        self.master.config(menu=menubar, borderwidth='1')

if __name__ == "__main__":
    root = tk.Tk()
    App = ParentWindow(root)
    root.mainloop()
