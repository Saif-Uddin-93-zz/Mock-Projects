@echo off

::SET MYPATH=\\GBRPW-FIL001\UK\temp
SET MYPATH="C:\Users\Saif Uddin\Desktop\code practice"
SET FILE=Update_Assets.csv

echo %COMPUTERNAME%,%USERNAME%>>%MYPATH%\%FILE%

::pause