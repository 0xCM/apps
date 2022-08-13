@echo off
set actor=7z
set HelpKind=help
set HelpArgs=--help
set CmdRoot=%~dp0..\cmd
set ToolRoot=%CmdRoot%\tools
set HelpPath=%ToolRoot%\%actor%.%HelpKind%
set HelpCmd=%actor% %HelpArgs%
echo # %HelpCmd%>%HelpPath%
echo --------------------------------------------------------------->>%HelpPath%
call %HelpCmd%>>%HelpPath%