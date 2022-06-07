@echo off
call %~dp0config.cmd

set ArchiveDst=%ZArchive%\bin\source\z0.zip
set RepoLogs=%ZArchive%\repos
set ArchiveLog=%RepoLogs%\z0-git-archive.log
set GitLogPath=%RepoLogs%\z0-git.log

git add -A -v >> %GitLogPath%
git commit -am "." -v >> %GitLogPath%
git push -v >> %GitLogPath%
git archive -v -o %ArchiveDst% HEAD 2> %ArchiveLog%
