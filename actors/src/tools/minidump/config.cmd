@echo off
set ToolId=minidump
set ToolSpec=%~dp0index.ts
set CmdSpec=ts-node %ToolSpec%
call %CmdSpec% >%~dp0%ToolId%.json