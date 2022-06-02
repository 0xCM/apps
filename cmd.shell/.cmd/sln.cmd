@echo off
call %~dp0config.cmd
set SlnDir=%ProjectDir%
set SlnName=%ProjectSlnName%
call %TopDir%\.cmd\sln-config.cmd

call %SlnCmdShellCmd%
call %SlnAsmCmd%
call %SlnAsmOperandsCmd%
call %SlnAsmCoreCmd%
call %SlnAllocCmd%
call %SlnApiCodeCmd%
call %SlnArchivesCmd%
call %SlnAssetsCmd%
call %SlnCmdActionsCmd%

call %SlnBitsCmd%
call %SlnCommandsCmd%
call %SlnSymbolsCmd%
call %SlnNumbersCmd%
call %SlnDiagnosticsCmd%
call %SlnIntelCoreCmd%
call %SlnIntelIntrinsicsCmd%
call %SlnIntelXedCmd%

call %SlnAsmPrototypesCmd%
call %SlnAsmServicesCmd%
