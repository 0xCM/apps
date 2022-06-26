@echo off
set WsId=cmd
set ZDev=%Views%\z0
set WsRoot=%ZDev%\cmd
set SlnFile=z0.%WsId%.sln
set SlnPath=%WsRoot%\%SlnFile%
dotnet sln %SlnPath% add %ZDev%\libs\z0.libs.csproj
dotnet sln %SlnPath% add %ZDev%\cg\cg.libs\z0.cg.libs.csproj
dotnet sln %SlnPath% add %ZDev%\cmd\z0.cmd.csproj
dotnet sln %SlnPath% add %ZDev%\libs\lib\z0.lib.csproj
