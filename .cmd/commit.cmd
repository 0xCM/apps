@echo off
call %~dp0config.cmd

set CommitLogPath=%RepoArchives%\z0-commit.log

git add -A -v >> %CommitLogPath%
git commit -am "." -v >> %CommitLogPath%
git push -v >> %CommitLogPath%