@echo off
set RepoId=z0.apps
call %ControlScripts%\commit-config.cmd

git add -A -v >> %CommitLog% 2>nul
git commit -v -am "." >> %CommitLog% 2>nul
git push
git archive -v -o %RepoArchive% HEAD 2> %ArchiveLog%
