@echo off
call %~dp0..\config.cmd
mkdir %Artifacts% 1>nul 2>nul
set Src=%Artifacts%\%RuntimeIdentifer%
set Dst=%PhysicalArtifacts%
set CmdSpec=mklink /D %Src% %Dst%
call %CmdSpec%


