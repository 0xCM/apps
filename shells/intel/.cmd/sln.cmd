@echo off
call %~dp0config.cmd
set SlnDir=%ProjectDir%
set SlnName=%ProjectSlnName%
call %TopDir%\.cmd\sln-config.cmd

call %SlnIntelShellCmd%
call %SlnIntelCoreCmd%
call %SlnIntelIntrinsicsCmd%
call %SlnIntelXedCmd%
call %SlnAllocCmd%
call %SlnApiCodeCmd%
call %SlnArchivesCmd%
call %SlnAssetsCmd%
call %SlnBitsCmd%
call %SlnCommandsCmd%
call %SlnSymbolsCmd%
call %SlnNumbersCmd%
call %SlnDiagnosticsCmd%
call %SlnAsmOperandsCmd%
call %SlnAsmCoreCmd%
call %SlnCgIntelCmd%
call %SlnCgCommonCmd%
call %SlnCgLlvmCmd%
call %SlnApiMd%

