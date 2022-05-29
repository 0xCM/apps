@echo off
call %~dp0config.cmd

@REM git add -A
@REM git commit -am "."
@REM git push

set ArchiveSrc=%TopDir%
set ArchiveDst=%Archives%\bin\source\z0.zip
set ArchiveLog=%RepoLogs%\z0-git-archive.log
set GitLogPath=%RepoLogs%\z0-git.log

cd %ArchiveSrc%

git add -A -v >> %GitLogPath%
git commit -am "." -v >> %GitLogPath%
git push -v >> %GitLogPath%
git archive -v -o %ArchiveDst% HEAD 2> %ArchiveLog%
