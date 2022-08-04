@echo off
call %~dp0config.cmd
call %PublishProject%>>%DbRoot%\logs\%ProjectId%\publish.log
