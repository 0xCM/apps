@echo off
call %~dp0..\config.cmd
robocopy %Artifacts%\%ShellId% %InstallBase%/e