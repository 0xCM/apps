@echo off
call %~dp0config.cmd
git archive -v -o %RepoArchive% HEAD
