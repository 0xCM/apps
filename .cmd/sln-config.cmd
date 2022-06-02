@echo off
set SlnTool=dotnet sln
set SlnPath=%SlnDir%/%SlnName%
set SlnLibCmd=%SlnTool% %SlnPath% add %LibDir%/z0.lib.csproj
set SlnAllocCmd=%SlnTool% %SlnPath% add %TopDir%/alloc/z0.alloc.csproj
set SlnApiCodeCmd=%SlnTool% %SlnPath% add %TopDir%/api.code/z0.api.code.csproj
set SlnArchivesCmd=%SlnTool% %SlnPath% add %TopDir%/archives/z0.archives.csproj
set SlnAssetsCmd=%SlnTool% %SlnPath% add %TopDir%/assets/z0.assets.csproj
set SlnBitsCmd=%SlnTool% %SlnPath% add %TopDir%/bits/z0.bits.csproj
set SlnCommandsCmd=%SlnTool% %SlnPath% add %TopDir%/commands/z0.commands.csproj
set SlnSymbolsCmd=%SlnTool% %SlnPath% add %TopDir%/symbols/z0.symbols.csproj
set SlnNumbersCmd=%SlnTool% %SlnPath% add %TopDir%/numbers/z0.numbers.csproj
set SlnDiagnosticsCmd=%SlnTool% %SlnPath% add %TopDir%/diagnostics/z0.diagnostics.csproj
set SlnXedShellCmd=%SlnTool% %SlnPath% add %TopDir%/xed.shell/z0.xed.shell.csproj
set SlnAsmCoreCmd=%SlnTool% %SlnPath% add %AppDir%/asm.core/z0.asm.core.csproj
set SlnAsmOperandsCmd=%SlnTool% %SlnPath% add %AppDir%/asm.operands/z0.asm.operands.csproj

set SlnCmdActionsCmd=%SlnTool% %SlnPath% add %AppDir%/cmd.actions/z0.cmd.actions.csproj
set SlnIntelCoreCmd=%SlnTool% %SlnPath% add %AppDir%/intel.core/z0.intel.core.csproj
set SlnIntelIntrinsicsCmd=%SlnTool% %SlnPath% add %AppDir%/intel.intrinsics/z0.intel.intrinsics.csproj