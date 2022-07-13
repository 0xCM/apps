@echo off
call %~dp0config.cmd

dotnet new sln --force

dotnet sln %LibSlnPath% add %LibsRoot%\%ProjectId%\z0.%ProjectId%.csproj

set ProjectId=api.specs
dotnet sln %LibSlnPath% add %LibsWs%\%ProjectId%\z0.%ProjectId%.csproj

set ProjectId=asm.models
dotnet sln %LibSlnPath% add %LibsWs%\%ProjectId%\z0.%ProjectId%.csproj

set ProjectId=literals
dotnet sln %LibSlnPath% add %LibsWs%\%ProjectId%\z0.%ProjectId%.csproj

set ProjectId=cmd.specs
dotnet sln %LibSlnPath% add %LibsWs%\%ProjectId%\z0.%ProjectId%.csproj

set ProjectId=cmd.svc
dotnet sln %LibSlnPath% add %LibsWs%\%ProjectId%\z0.%ProjectId%.csproj

set ProjectId=archives
dotnet sln %LibSlnPath% add %LibsWs%\%ProjectId%\z0.%ProjectId%.csproj

set ProjectId=lib
dotnet sln %LibSlnPath% add %LibsWs%\%ProjectId%\z0.%ProjectId%.csproj
