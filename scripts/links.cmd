@echo off
set ShellId=zcmd
set ProjectId=cmd
call %~dp0..\.cmd\config.cmd
: set Publications=%~dp0..\artifacts
mkdir %Publications% 1>nul 2>nul
set Src=%Publications%\%ShellId%
set Dst=%ShellArtifacts%
mklink /D %Src% %Dst%
