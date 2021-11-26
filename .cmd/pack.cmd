@echo off

: dotnet pack %~dp0..\lib\z0.lib.csproj -c Release -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg --output j:\cache\dev

dotnet pack %~dp0..\lib\z0.lib.csproj -c Release -p:IncludeSymbols=true --output j:\cache\dev