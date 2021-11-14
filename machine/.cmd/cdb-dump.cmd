@echo off
set ProjectId=machine
set AppId=machine
call %ControlScripts%\build-config.cmd

set AppExe=%AppRuntimeRoot%\%AppId%.exe
echo AppExe:%AppExe%

set DumpPath=j:\dumps\capture.2021-05-04.16.14.36.652.dmp

cdb -y %_NT_SYMBOL_PATH% -z %DumpPath% -ee MASM

: .load C:\Data\packages\sos\x64-release\sos.dll
: !name2ee * Program: Lists loaded module addresses along with the assembly name

: !dumpmodule -mt 00007ff9835f7d48