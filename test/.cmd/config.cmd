@echo off
set ProjId=test.runner
set AppName=ztest
call %~dp0..\..\apps\.cmd\project-config.cmd
::set ExePath=%ZDev%\.build\bin