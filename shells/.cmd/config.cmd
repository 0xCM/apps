@echo off
set Area=shells
set ProjectId=shells
call %~dp0..\..\.cmd\config.cmd
set SlnPath=%~dp0..\z0.shells.sln
set SlnTool=dotnet sln %SlnPath% add
set BuildSln=%BuildTool% %SlnPath% %BuildProps% %BinLogSpec%; -graph:true -m:24
