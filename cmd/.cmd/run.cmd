@echo off
set zcmd="%DevRoot%\dev\z0\.build\bin\z0.cmd\release\net6.0\win-x64\zcmd.exe"
set CmdSpec=%comspec% /C %zcmd% %*
call %CmdSpec%
