@echo off
call %~dp0..\config.cmd
set Runtime=ts-node
set CmdSpec=%Runtime% %EntryPoint%

set Runtime=deno
set CmdSpec=%Runtime% run %EntryPoint%

call %CmdSpec%