@echo off
call %~dp0config.cmd
robocopy %Artifacts%\%ShellId% %Views%\tools\z0\zcmd /e