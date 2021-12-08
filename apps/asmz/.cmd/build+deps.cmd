@echo off
call %~dp0config.cmd
call %ZDev%\.cmd\build-libs.cmd
call %ZDev%\.cmd\build-test.cmd
call %BuildProjCmd%
