@echo off
set ToolId=ztool
set ToolPath="%DevRoot%\dev\z0\artifacts\%ToolId%\%ToolId%.exe"
set ztool=%ToolPath%
set CmdSpec=%comspec% /C %ztool% %*
call %CmdSpec%
