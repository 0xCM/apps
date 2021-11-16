@echo off
dotnet pack %~dp0..\lib\z0.lib.csproj -c Release --output j:\cache\dev
