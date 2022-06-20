@echo off
set WsId=z0
set ProjectId=cmd
set ShellId=zcmd
set WsRoot=%DevRoot%\dev\z0
call D:\views\control\.cmd\config.cmd
call %ControlScripts%\commit-z0.cmd
call %ControlScripts%\archive-z0.cmd