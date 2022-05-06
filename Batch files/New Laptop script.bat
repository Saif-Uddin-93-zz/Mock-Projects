::Written by Saif Uddin
@echo off

tzutil /s "GMT Standard Time"

start /b outlook.exe

start /b /d "C:\Users\%username%\AppData\Local\Microsoft\Teams" Update.exe --processStart "Teams.exe"

start /b chrome https://Example.Website1.com/ https://Example.Website2.com/ https://Example.Website3.com/

gpupdate /force

start /b /d "C:\Program Files (x86)\Dell\CommandUpdate" DellCommandUpdate.exe

start /b /d "C:\Program Files\Box\Box" Box.exe

pause