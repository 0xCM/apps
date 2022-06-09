@echo off
call %~dp0config.cmd

set ArchiveTarget=%RepoArchives%\z0.archive.zip
git archive -v -o %ArchiveTarget% HEAD
