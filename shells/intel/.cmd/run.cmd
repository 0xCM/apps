@echo off
call %~dp0config.cmd
set ShellExe=D:\drives\Z\dev\z0\.build\bin\z0.intel\Release\net6.0\win-x64\intel.exe
%ShellExe% %1 %2 %3 %4