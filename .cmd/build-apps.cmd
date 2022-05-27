@echo off
set SlnPath=%~dp0..\apps\cmd.shell\z0.cmd.shell.sln
dotnet build %SlnPath% -c Release
