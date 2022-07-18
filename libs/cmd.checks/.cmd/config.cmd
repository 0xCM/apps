@echo off
set ProjectId=cmd.checks
set WsId=cmd.checks
set EnvId=app.settings
set WsArea=libs
call %~dp0..\..\.cmd\config.cmd
set WsRoot=%SlnRoot%\libs\%WsId%
set SlnPath=%WsRoot%\%WsId%.sln
