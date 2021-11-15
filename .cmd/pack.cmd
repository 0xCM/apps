@echo off
dotnet pack %~dp0..\z0.sln -c Release --output j:\cache\dev
