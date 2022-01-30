@echo off
set SlnPath=%~dp0..\apps\z0.apps.sln
dotnet build %SlnPath% -c Release
