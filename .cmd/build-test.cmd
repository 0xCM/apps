@echo off
set SlnPath=%~dp0..\test\z0.test.sln
dotnet build %SlnPath% -c Release
