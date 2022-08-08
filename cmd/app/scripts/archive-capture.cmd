@echo off
set actor=7z
set Db=%DbRoot%
set CmdLogs=%Db%\logs\tools\%actor%
set CmdLog=%ActorLogs%\%actor%
set SrcRoot=%Db%\capture\%Ts%
set SrcExpr=%SrcRoot%\*.*
set ArchiveName=capture.%Ts%.7z
set Dst=%Views%\archives\capture\%ArchiveName%
del %Dst% 1>nul 2>nul
set Action=a
set Options=-t7z
set CmdSpec=%actor% %Action% %Options% %Dst% %SrcExpr%
echo %CmdSpec%>> %CmdLog%
echo --------------------------------------------------------------------------->>%CmdLog%
call %CmdSpec%>> %CmdLog%
if errorlevel 1 goto:eof

echo %actor%:[%SrcRoot% -- %Dst%]

set CmdSpec=rmdir %SrcRoot% /s/q
call %CmdSpec%
