import tkinter as tk
from tkinter import filedialog, Text
import os
#import clipboard
import pyperclip

#import compress_images
#from compress_images import CompressImgs
#compImg = CompressImgs()

root = tk.Tk()


canvas = tk.Canvas(root, height=400, width=400, bg="#263D42")
canvas.pack()

frame = tk.Frame(root, bg="white")
frame.place(relwidth=0.6, relheight=0.8, relx=0.2, rely=0.1, anchor="nw")


morningArriveButton = tk.Button(frame, text="Morning Arrive", padx=10,
                     pady=5, fg="white", bg="#263D42",
                     command=lambda:pyperclip.copy("1 Morning ARRIVE"))
#morningArriveButton.place(relwidth=0.6, relheight=0.8, relx=0, rely=0, anchor = "ne")
morningArriveButton.pack()

morningLeaveButton = tk.Button(frame, text="Morning LEAVE", padx=10,
                     pady=5, fg="white", bg="#263D42",
                     command=lambda:pyperclip.copy("2 Morning LEAVE"))
morningLeaveButton.pack()

afternoonArriveButton = tk.Button(frame, text="Afternoon ARRIVE", padx=10,
                     pady=5, fg="white", bg="#263D42",
                     command=lambda:pyperclip.copy("3 Afternoon ARRIVE"))
afternoonArriveButton.pack()                     

afternoonLeaveButton = tk.Button(frame, text="Afternoon LEAVE", padx=10,
                     pady=5, fg="white", bg="#263D42",
                     command=lambda:pyperclip.copy("4 Afternoon LEAVE"))
afternoonLeaveButton.pack()

eveningArriveButton = tk.Button(frame, text="Evening ARRIVE", padx=10,
                     pady=5, fg="white", bg="#263D42",
                     command=lambda:pyperclip.copy("5 Evening ARRIVE"))
eveningArriveButton.pack()                     

eveningLeaveButton = tk.Button(frame, text="Evening LEAVE", padx=10,
                     pady=5, fg="white", bg="#263D42",
                     command=lambda:pyperclip.copy("6 Evening LEAVE"))
eveningLeaveButton.pack()

def SelectFolder():
    foldername = filedialog.askdirectory(initialdir="C:\ContaCam\Front Door\Carers timesheet", title="Select Folder")
    pyperclip.copy(foldername)
    #filedialog.askdirectory(title=title, initialdir=folder, parent=None if master is None else master.tk)
selectFolder = tk.Button(frame, text="Select Folder", padx=10,
                     pady=5, fg="white", bg="#263D42",
                     command=SelectFolder)
selectFolder.pack()

compressButton = tk.Button(frame, text="COMPRESS TOOL!", padx=10,
                     pady=5, fg="white", bg="#263D42",
                     )#command=lambda:os.startfile(r"C:\Users\Saif Uddin\Desktop\compress_images_DESKTOP.py"))
                     #command=lambda:compImg.start())
compressButton.pack()

root.mainloop()
