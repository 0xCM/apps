@echo off
call %~dp0..\scripts\config.cmd
git archive -v -o %RepoArchive% HEAD
