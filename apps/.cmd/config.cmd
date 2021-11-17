@echo off
set RepoId=z0.apps
set SrcRoot=%~dp0..\..
set AppsRoot=%SrcRoot%\apps
set BuildRoot=%SrcRoot%\.build
set RtId=win-x64
set FrameworkMoniker=netcoreapp3.1
set Configuration=release
set BuildLogs=%BuildRoot%\logs
set BuildVerbosity=normal

mkdir %BuildLogs% 1>nul 2>nul

