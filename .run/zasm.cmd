@echo off
call %~dp0config.cmd
set ProjId=z0.asmz
set ExeName=zasm
set FrameworkMoniker=netcoreapp3.1
set RtId=win-x64
set ConfigName=Release
set CmdSpec=%BuildRoot%\bin\%ProjId%\%ConfigName%\%FrameworkMoniker%\%RtId%\%ExeName%.exe capture-v2
call %CmdSpec%