@echo off
call %~dp0config.cmd

set RepoArchives=K:\z0\archives\repos
set CommitLogPath=%RepoArchives%\z0-commit.log
set ArchiveTarget=%RepoArchives%\z0.archive.zip

git add -A -v >> %CommitLogPath%
git commit -am "." -v >> %CommitLogPath%
git push -v >> %CommitLogPath%
git archive -v -o %ArchiveTarget% HEAD
