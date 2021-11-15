@echo off
call %~dp0config.cmd

dotnet pack %LibProjPath% -c Release --include-symbols --include-source --output %PkgDst%
