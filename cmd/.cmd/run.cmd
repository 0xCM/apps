@echo off
set InstallBase=%DevRoot%\dev\z0\.build\bin\z0.cmd\release\net6.0\win-x64\publish
set ExePath=%Home%\zcmd.exe
set ArgList=%*
powershell %~dp0run.ps1

