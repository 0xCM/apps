@echo off
call %~dp0config.cmd
: call %BuildProject%
call %PublishProject%>>%DbRoot%\logs\%ProjectId%\publish.log

