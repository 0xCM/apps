@echo off
set PkgDst=j:\cache\dev
dotnet pack %~dp0..\z0.test.csproj -c Release --output %PkgDst%
