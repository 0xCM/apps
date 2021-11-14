@echo off
set ProjectId=logix.test
set BuildCmd=%ControlScripts%\build-app.cmd
set RunCmd=z0.%ProjectId%.exe
call %BuildCmd%
call %RunCmd%