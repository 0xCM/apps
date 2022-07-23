@echo off
call %~dp0config.cmd
set Src=%AreaProjectPath%
set Dst=%Views%\tools\z0\workers
set CmdSpec=dotnet publish %Src% --output %Dst% --no-build --verbosity normal
call %CmdSpec%