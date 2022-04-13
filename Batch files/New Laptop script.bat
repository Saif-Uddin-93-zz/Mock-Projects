::Written by Saif Uddin
@echo off

tzutil /s "GMT Standard Time"

start /b outlook.exe

start /b /d "C:\Users\%username%\AppData\Local\Microsoft\Teams" Update.exe --processStart "Teams.exe"

start /b chrome https://shiseido-emea.app.box.com/ https://shiseido.service-now.com/ https://app.matrixbooking.com/

gpupdate /force

start /b /d "C:\Program Files (x86)\Dell\CommandUpdate" DellCommandUpdate.exe

start /b /d "C:\Program Files\Box\Box" Box.exe

pause