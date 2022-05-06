::Written by Saif Uddin
@echo off

SET DAY=%DATE:~0,2%
SET MONTH=%DATE:~3,2%
SET YEAR=%DATE:~6,4%
SET SERVER_PATH=\\Server\Path
SET DOMAIN=company.domain.com
SET FILE=LOG_ON_SUMMARY.csv

::ipconfig /flushdns

::echo DO NOT CLOSE. WINDOW WILL CLOSE ONCE CONNECTED TO COMPANY NETWORK

:RETRY
ping -n 1 %DOMAIN% | find "TTL=" >nul
if errorlevel 1 (
    ::echo host not reachable
    GOTO:RETRY
) else (
    ::echo host reachable
    echo %YEAR%/%MONTH%/%DAY%,%TIME:~0,5%,%USERNAME%,%COMPUTERNAME%>>%SERVER_PATH%\%FILE%
)
::pause