@echo off
call %~dp0props.cmd
set SlnRoot=%Views%\z0
set ShellPath=%SlnRoot%\artifacts\bin\z0.%ProjectId%\%Configuration%\%FrameworkMoniker%\%RuntimeIdentifier%\%ShellId%.exe
call %ShellPath% %1 %2 %3 %4
