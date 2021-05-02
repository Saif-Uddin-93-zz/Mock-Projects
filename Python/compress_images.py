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
        self.root_path = f"C:\ContaCam\Front Door\Carers timesheet\{YEAR}\{MONTH_int} {MONTH_str}\\"
        self.directory = f"{DAY_int} {DAY_str}"
        self.dList = ["ContaCam", "Front Door", "Carers timesheet", YEAR, MONTH_int+" "+MONTH_str]

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
        #self.run_cmd("cls")
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
            #command = f'ffmpeg -i "{file_input}" -c:v libx265 -qp 16 "{file_output}"'
            #command = f'ffmpeg -i "{file_input}" -c:v libx265 -preset slow -crf 19 -c:a libx265 -b:a 128k "{file_output}"'
            #command = f'ffmpeg -i "{file_input}" -c:a copy -c:v vp9 -b:v 100K "{file_output}"' #libvo_aacenc
            #command = f'ffmpeg -i "{file_input}" -c:v copy -c:a copy -y "{file_output}"'
            #command = f'ffmpeg -i "{file_input}" -c:v libx265 -c:a hevc_nvenc -crf 28 -preset medium "{file_output}"'
            #command = f'ffmpeg -i "{file_input}" -vcodec libx265 -crf 8 -preset veryslow -c:a aac -strict experimental -b:a 192k -ac 2 "{file_output}"'
            #command = f'ffmpeg -i "{file_input}" -c:v libx265 -crf 0 -preset veryslow -c:a libfdk_aac -b:a 192k -ac 2 "{file_output}"'
            #command = f'ffmpeg -i "{file_input}" -c:v libx265 -crf 0 -preset veryslow -c:a aac -strict experimental -b:a 192k -ac 2 "{file_output}"'
            #command = f'ffmpeg -fflags +genpts -i "{file_input}" -allow_raw_vfw 1 -c:v copy -c:a copy "{file_output}"'
            self.run_cmd(command)
            #self.logs()

    def logs(self):
        #%Y 2021, %m 01-12, %B January-December, %d 01-31, %a Mon - Sun
        #today = self.getToday.strftime("%Y, %m, %B, %d, %a")
        self.logger.info(self.getToday)

    def rename(self):
        for f in onlyfiles:
            print("old name:",f)
            if "copy of " in f:
                new_name = f[8:]
                command = f'rename "{self.dir_path}\{f}" "{new_name}"'
                self.run_cmd(command)
                print("new name:",new_name)

    def newFolder(self, d="", i=0):
        isdir = os.path.isdir(d)
        #print(d, isdir)
        if not isdir:
            l = len(str(self.dList[-i]))+1
            d = d[:-l]
            i += 1
            #print("\nShould be FALSE:", isdir, "\nnew dir =", d)
            self.newFolder(d, i)
        else:
            if i>1:
                #print(d, "TRUE and i>0. i ==", i)
                self.dir_path = os.path.join(d, str(self.dList[-(i-1)])+"\\")
                os.mkdir(self.dir_path)
                i -= 1                
                self.newFolder(self.dir_path, i)
            else:
                #print("TRUE and i==0. i ==", i)
                try:
                    self.dir_path = os.path.join(self.root_path, self.directory)
                    os.mkdir(self.dir_path)
                    self.dir_path_()
                except FileExistsError:
                    print("Today's folder already created.")

    def deleteExcess(self, path):
        if path == None:
            print(path)
        elif path != None:
            self.dir_path = path
            os.chdir(self.dir_path)
            getFiles = [f for f in listdir(self.dir_path) if isfile(join(self.dir_path, f))]
            mp4Files = [f for f in getFiles if ".mp4" in f]
            otherFiles = list(set(getFiles) - set(mp4Files))
            for f in otherFiles:
                self.run_cmd(f"del {f}")
            for f in range(len(mp4Files)):
                if "shot" in mp4Files[f]:
                    self.run_cmd(f"del {mp4Files[f]}")
                new_name = mp4Files[f].strip("rec_")
                new_name = new_name[11:]
                #new_name = new_name[0:2]+new_name[3:5]+new_name[6:] #removing underscores
                command = f'rename "{self.dir_path}\{mp4Files[f]}" "{new_name}"'
                self.run_cmd(command)
                mp4Files[f] = new_name
            
            morningList = [f for f in mp4Files if (f[0:2]=="08" and int(f[3:5])>55) or f[0:2]=="09"]
            afternoonList = [f for f in mp4Files if (f[0:2]=="12" and int(f[3:5])>25) or (f[0:2]=="13" and int(f[3:5])<35)]
            eveningList = [f for f in mp4Files if (f[0:2]=="18" and int(f[3:5])>25) or (f[0:2]=="19" and int(f[3:5])<35)]
            keepList = morningList + afternoonList + eveningList
            delList = list(set(mp4Files) - set(keepList))
            for f in delList:
                self.run_cmd(f"del {f}")