@echo off
call %~dp0config.cmd
robocopy %Artifacts%\%ShellId% %InstallBase%/e