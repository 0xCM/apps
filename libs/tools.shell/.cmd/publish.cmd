@echo off
call %~dp0config.cmd
set LogPath=%DbRoot%\logs\%ProjectId%\publish.log
: call %PublishProject%>>%LogPath%
call %PublishProject%
