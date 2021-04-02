import os

from os import listdir
from os.path import isfile, join

old_img_type = ".png" #ENTER OLD IMAGE TYPE! -----------------------------
new_img_type = ".jpg" #ENTER NEW IMAGE TYPE! -----------------------------
new_img_res = "1920:1080" #ENTER NEW RESOLUTION! -------------------------
keyword = "copy of " #ENTER FILE OUTPUT PREFIX ---------------------------

def dir_path_(dir = str(input("Press Enter to use current directory or input a directory path:\n"))):
    if dir:
        print("INPUT: ")
        return dir        
    else:
        print("DEFAULT: ")
        return os.path.dirname(os.path.abspath(__file__))

dir_path = dir_path_()
os.chdir(dir_path)
print(dir_path)

onlyfiles = [f for f in listdir(dir_path) if isfile(join(dir_path, f))]

lof = []

for f in onlyfiles:
    f_bool = old_img_type in f
    if f_bool:
        lof.append(f)

print("\n.png list:\n",lof,"\n")

run_cmd = lambda a: os.system(a)

def convert_images():
    for f in lof:
        file_input = str(f)
        file_output = keyword + file_input[:-4] + new_img_type
        command = f'ffmpeg -i "{file_input}" -vf scale={new_img_res} -compression_level 100 "{file_output}"'
        run_cmd(command)

convert_images()

onlyfiles = [f for f in listdir(dir_path) if isfile(join(dir_path, f))]

lof2 = []

for f in onlyfiles:
    f_bool = keyword in f
    if f_bool:
        lof2.append(f)

print ("\nlist of converted files:\n", lof2, "\n")

def rename():
    for f in onlyfiles:
        print("old name:",f)
        f_bool = "copy of " in f    
        if f_bool:
            new_name = f[8:]
            command = f'rename "{dir_path}\{f}" "{new_name}"'
            run_cmd(command)
            print("new name:",new_name)

rename()
run_cmd(f"del *{old_img_type}")
print("end")