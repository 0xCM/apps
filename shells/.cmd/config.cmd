@echo off
set ProjectId=shells
set Area=shells
call %DevRoot%\dev\z0\.cmd\config.cmd

set SlnName=%Area%.sln
set SlnRoot=%~dp0..\
set SlnPath=%SlnRoot%%SlnName%


