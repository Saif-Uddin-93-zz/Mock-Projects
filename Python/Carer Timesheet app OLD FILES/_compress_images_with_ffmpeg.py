import os
#import glob

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

#dir_path = os.path.dirname(os.path.realpath(__file__))
#lof_os = os.listdir(dir_path)
##lof_glob = glob.glob(dir_path + "\copy of *")
##print(dir_path+"\copy of *")

onlyfiles = [f for f in listdir(dir_path) if isfile(join(dir_path, f))]

#lof = glob.glob(f"*{old_img_type}")
lof = []

for f in onlyfiles:
    f_bool = old_img_type in f
    if f_bool:
        lof.append(f)

print("\n.png list:\n",lof,"\n")
#input("")

run_cmd = lambda a: os.system(a)

def convert_images():
    for f in lof:
        file_input = str(f)
        file_output = keyword + file_input[:-4] + new_img_type
        command = f'ffmpeg -i "{file_input}" -vf scale={new_img_res} -compression_level 100 "{file_output}"'
        run_cmd(command)

convert_images()

#import pprint
  
# Get the list of user's
# environment variables
#env_var = os.environ
  
# Print the list of user's
# environment variables
#print("User's Environment variable:")
#pprint.pprint(dict(env_var), width = 1)


#currentDirectory = os.environ['PWD']
#print(currentDirectory)


#imgList = []
#keywordFilter = set(["copy of "])

#for f in onlyfiles:
    #imgList.append(f)
    #imgList = [file for file in imgList 
    #if not any(word in file for word in keywordFilter)]

onlyfiles = [f for f in listdir(dir_path) if isfile(join(dir_path, f))]
#lof2 = glob.glob(f"{keyword}*")
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
            #print("TEST! old name:", f)
            #print("TEST! new name:",new_name)
            command = f'rename "{dir_path}\{f}" "{new_name}"'
            run_cmd(command)
            print("new name:",new_name)

#pause = input("pause")
rename()
run_cmd(f"del *{old_img_type}")
print("end")

#convert_images, convert_images2 = convert_images()