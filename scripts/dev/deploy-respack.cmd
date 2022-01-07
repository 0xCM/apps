@echo off

call %~dp0config.cmd

set ProjectId=respack
set FrameworkMoniker=netcoreapp3.1
set BuildConfigRoot=%ZDev%\.build\bin\release
set ProjectBuildRoot=%BuildConfigRoot%\z0.%ProjectId%\%FrameworkMoniker%
set DeploySrc=%ProjectBuildRoot%
set DeployDst=%ZPack%\%ProjectId%
set DeployLog=%EtlLogs%\deploy-%ProjectId%.log
set DeployCmd=robocopy %DeploySrc% %DeployDst% /log:%DeployLog% /tee /TS /BYTES /V /e

@echo on

call %DeployCmd%