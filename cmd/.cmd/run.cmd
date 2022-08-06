@echo off
set zcmd="%~dp0..\..\artifacts\zcmd\zcmd.exe"
: set CmdSpec=%comspec% /C %zcmd% %*
call %zcmd%
