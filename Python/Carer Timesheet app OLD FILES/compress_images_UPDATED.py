import os
import logging
import datetime

from os import listdir
from os.path import isfile, join

class CompressImgs:

    def __init__(self):
        self.old_img_type = ".png" #ENTER OLD IMAGE TYPE! -----------------------------
        self.new_img_type = ".jpg" #ENTER NEW IMAGE TYPE! -----------------------------
        self.new_img_res = "1920:1080" #ENTER NEW RESOLUTION! -------------------------
        self.keyword = "copy of " #ENTER FILE OUTPUT PREFIX ---------------------------
        self.run_cmd = lambda a: os.system(a)
        #self.log_times = lambda:self.logger.info("test")
        LOG_FORMAT = "%(message)s,"
        logging.basicConfig(filename=r"C:\ContaCam\Front Door\Carers timesheet\times.csv",
                            level = logging.DEBUG,
                            format=LOG_FORMAT)
        self.logger = logging.getLogger()
        self.getToday = datetime.datetime.now()
        YEAR = self.getToday.strftime("%Y")
        MONTH_int = self.getToday.strftime("%m")
        MONTH_str = self.getToday.strftime("%B")
        DAY_int = self.getToday.strftime("%d") 
        DAY_str = self.getToday.strftime("%a")
        root_path = f"C:\ContaCam\Front Door\Carers timesheet\{YEAR}\{MONTH_int} {MONTH_str}\\"
        directory = f"{DAY_int} {DAY_str}"
        self.dir_path = os.path.join(root_path, directory)

    def start(self):
        global onlyfiles
        global lof
        global lof2
        self.dir_path_()
        os.chdir(self.dir_path)

        onlyfiles = [f for f in listdir(self.dir_path) if isfile(join(self.dir_path, f))]
        lof = [f for f in onlyfiles if self.old_img_type in f]
        print("\n.png list:\n", "\n".join(lof), "\n", sep="")

        self.convert_images()        

        onlyfiles = [f for f in listdir(self.dir_path) if isfile(join(self.dir_path, f))]
        lof2 = [f for f in onlyfiles if self.keyword in f]
        print ("\nlist of converted files:\n", "\n".join(lof2), "\n", sep="")

        self.rename()
        self.run_cmd(f"del *{self.old_img_type}")
        print("end")
        #self.run_cmd("pause")    

    def dir_path_(self, vPath=""):
        #dir = str(input("Press Enter to use current directory or input a directory path:\n"))
        self.run_cmd("cls")
        if not vPath:
            print("Today's folder: ", self.dir_path, sep="\n")
            #dir_path = os.path.dirname(os.path.abspath(__file__))
        else:
            self.dir_path = vPath
            print("MANUAL INPUT: ", self.dir_path, sep="\n")

    def convert_images(self):
        for f in lof:
            file_input = str(f)
            file_output = self.keyword + file_input[:-4] + self.new_img_type
            command = f'ffmpeg -i "{file_input}" -vf scale={self.new_img_res} -compression_level 100 "{file_output}"'
            self.run_cmd(command)
            self.logs()

    def logs(self):
        #%Y 2021, %m 01-12, %B January-December, %d 01-31, %a Mon - Sun
        #today = self.getToday.strftime("%Y, %m, %B, %d, %a")
        self.logger.info(self.getToday)

    def rename(self):
        for f in onlyfiles:
            print("old name:",f)
            f_bool = "copy of " in f
            if f_bool:
                new_name = f[8:]
                command = f'rename "{self.dir_path}\{f}" "{new_name}"'
                self.run_cmd(command)
                print("new name:",new_name)

    def newFolder(self):        
        try:
            os.mkdir(self.dir_path)
        except FileExistsError:
            print("Today's folder already created.")