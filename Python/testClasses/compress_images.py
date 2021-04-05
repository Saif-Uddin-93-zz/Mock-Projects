import os

from os import listdir
from os.path import isfile, join

class CompressImgs:
    def __init__(self):
        pass

    old_img_type = ".png" #ENTER OLD IMAGE TYPE! -----------------------------
    new_img_type = ".jpg" #ENTER NEW IMAGE TYPE! -----------------------------
    new_img_res = "1920:1080" #ENTER NEW RESOLUTION! -------------------------
    keyword = "copy of " #ENTER FILE OUTPUT PREFIX ---------------------------
    run_cmd = lambda a: os.system(a)

    def dir_path_(self):
        dir = str(input("Press Enter to use current directory or input a directory path:\n"))
        if dir:
            print("INPUT: ")
            return dir
        else:
            print("DEFAULT: ")
            return os.path.dirname(os.path.abspath(__file__))

    def convert_images(self):
        #global lof
        for f in lof:
            file_input = str(f)
            file_output = self.keyword + file_input[:-4] + self.new_img_type
            command = f'ffmpeg -i "{file_input}" -vf scale={self.new_img_res} -compression_level 100 "{file_output}"'
            self.run_cmd(command)

    def rename(self):
        for f in onlyfiles:
            print("old name:",f)
            f_bool = "copy of " in f
            if f_bool:
                new_name = f[8:]
                command = f'rename "{dir_path}\{f}" "{new_name}"'
                self.run_cmd(command)
                print("new name:",new_name)

    def start(self):
        global dir_path
        global onlyfiles
        global lof
        global lof2
        dir_path = self.dir_path_()
        os.chdir(dir_path)
        print(dir_path)

        onlyfiles = [f for f in listdir(dir_path) if isfile(join(dir_path, f))]
        lof = [f for f in onlyfiles if self.old_img_type in f]
        print("\n.png list:\n", "\n".join(lof), "\n", sep="")

        self.convert_images()

        onlyfiles = [f for f in listdir(dir_path) if isfile(join(dir_path, f))]
        lof2 = [f for f in onlyfiles if self.keyword in f]
        print ("\nlist of converted files:\n", "\n".join(lof2), "\n", sep="")

        self.rename()
        self.run_cmd(f"del *{self.old_img_type}")
        print("end")
        self.run_cmd("pause")

