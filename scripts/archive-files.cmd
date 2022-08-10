@echo off
call %~dp0..\config.cmd
set Src=%SlnRoot%
set Dst=%Views%\archives\repos\%SlnId%
mkdir %Dst% 1>nul 2>nul
set XD=/xd %Src%.git /xd %Src%.vs /xd %Src%artifacts /xd %Src%vscode /xd %SlnRoot%\cmd\artifacts
echo XD=%XD%
set CmdSpec=robocopy %Src% %Dst% /e %XD%
echo CmdSpec=%CmdSpec%
call %CmdSpec%