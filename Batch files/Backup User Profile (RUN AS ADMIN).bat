::Written by Saif Uddin
::Do not run from server. Copy file onto the computer locally.

@echo off
::SET SRC_COMPUTER=%COMPUTERNAME%
SET /p SRC_COMPUTER="paste in or type in source computer name OR if running script locally on source computer type, SKIP: "
SET /p DEST_COMPUTER="Paste in or type in the destination computer name: "
::SET USER=%USERNAME%
SET /p USER="Type SKIP if logged in to the old laptop as the user OR type or paste in username of profile being backed up: "

IF %USER%=="SKIP" SET USER=%USERNAME%
IF %USER%=="skip" SET USER=%USERNAME%
::IF %USER%=="" SET USER=%USERNAME%

IF %SRC_COMPUTER%=="SKIP" SET SRC_COMPUTER=%HOSTNAME%
IF %SRC_COMPUTER%=="skip" SET SRC_COMPUTER=%HOSTNAME%
::IF %SRC_COMPUTER%=="" SET SRC_COMPUTER=%HOSTNAME%

SET SRC_DESKTOP=\\%SRC_COMPUTER%\c$\Users\%USER%\Desktop
SET SRC_DOCUMENTS=\\%SRC_COMPUTER%\c$\Users\%USER%\Documents
SET SRC_DOWNLOADS=\\%SRC_COMPUTER%\c$\Users\%USER%\Downloads
SET SRC_MUSIC=\\%SRC_COMPUTER%\c$\Users\%USER%\Music
SET SRC_PICTURES=\\%SRC_COMPUTER%\c$\Users\%USER%\Pictures
SET SRC_VIDEOS=\\%SRC_COMPUTER%\c$\Users\%USER%\Videos

SET DEST_DESKTOP=\\%DEST_COMPUTER%\c$\Users\%USER%\Desktop
SET DEST_DOCUMENTS=\\%DEST_COMPUTER%\c$\Users\%USER%\Documents
SET DEST_DOWNLOADS=\\%DEST_COMPUTER%\c$\Users\%USER%\Downloads
SET DEST_MUSIC=\\%DEST_COMPUTER%\c$\Users\%USER%\Music
SET DEST_PICTURES=\\%DEST_COMPUTER%\c$\Users\%USER%\Pictures
SET DEST_VIDEOS=\\%DEST_COMPUTER%\c$\Users\%USER%\Videos

::backup bookmarks
xcopy /Y "\\%SRC_COMPUTER%\c$\Users\%USER%\AppData\Local\Google\Chrome\User Data\default\bookmarks" "\\%DEST_COMPUTER%\c$\Users\%USER%\AppData\Local\Google\Chrome\User Data\default"

::backup files
xcopy /Y/E/C/I/H "%SRC_DESKTOP%" "%DEST_DESKTOP%"
xcopy /Y/E/C/I/H "%SRC_DOCUMENTS%" "%DEST_DOCUMENTS%"
xcopy /Y/E/C/I/H "%SRC_MUSIC%" "%DEST_MUSIC%"
xcopy /Y/E/C/I/H "%SRC_PICTURES%" "%DEST_PICTURES%"
xcopy /Y/E/C/I/H "%SRC_VIDEOS%" "%DEST_VIDEOS%"
xcopy /Y/E/C/I/H "%SRC_DOWNLOADS%" "%DEST_DOWNLOADS%"
pause