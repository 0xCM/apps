@echo off
call %~dp0..\config.cmd
dotnet build
tsc