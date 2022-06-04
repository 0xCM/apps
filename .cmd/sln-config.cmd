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
set SlnMachinesCmd=%SlnTool% %SlnPath% add %TopDir%/machines/z0.machines.csproj
set SlnNumbersCmd=%SlnTool% %SlnPath% add %TopDir%/numbers/z0.numbers.csproj
set SlnSymbolsCmd=%SlnTool% %SlnPath% add %TopDir%/symbols/z0.symbols.csproj
set SlnDiagnosticsCmd=%SlnTool% %SlnPath% add %TopDir%/diagnostics/z0.diagnostics.csproj
set SlnApiMd=%SlnTool% %SlnPath% add %TopDir%/api.md/z0.api.md.csproj

set SlnXedShellCmd=%SlnTool% %SlnPath% add %TopDir%/xed.shell/z0.xed.shell.csproj
set SlnXedShellRemoveCmd=%SlnTool% %SlnPath% remove %TopDir%/xed.shell/z0.xed.shell.csproj

set SlnCmdShellCmd=%SlnTool% %SlnPath% add %TopDir%/cmd.shell/z0.cmd.shell.csproj
set SlnCmdShellRemoveCmd=%SlnTool% %SlnPath% remove %TopDir%/cmd.shell/z0.cmd.shell.csproj

set SlnIntelShellCmd=%SlnTool% %SlnPath% add %TopDir%/intel.shell/z0.intel.shell.csproj

set SlnIntelCoreCmd=%SlnTool% %SlnPath% add %TopDir%/intel.core/z0.intel.core.csproj
set SlnIntelIntrinsicsCmd=%SlnTool% %SlnPath% add %TopDir%/intel.intrinsics/z0.intel.intrinsics.csproj
set SlnIntelXedCmd=%SlnTool% %SlnPath% add %TopDir%/intel.xed/z0.intel.xed.csproj

set SlnCmdActionsCmd=%SlnTool% %SlnPath% add %AppDir%/cmd.actions/z0.cmd.actions.csproj

set SlnCgIntelCmd=%SlnTool% %SlnPath% add %CgDir%/codegen.intel/z0.codegen.intel.csproj
set SlnCgCommonCmd=%SlnTool% %SlnPath% add %CgDir%/codegen.common/z0.codegen.common.csproj
set SlnCgLlvmCmd=%SlnTool% %SlnPath% add %CgDir%/codegen.llvm/z0.codegen.llvm.csproj

set SlnCgShellCmd=%SlnTool% %SlnPath% add %CgDir%/codegen.shell/z0.codegen.shell.csproj
set SlnCgShellRemoveCmd=%SlnTool% %SlnPath% remove %CgDir%/codegen.shell/z0.codegen.shell.csproj

set SlnDeprecatedCmd=%SlnTool% %SlnPath% add %TopDir%/deprecated/z0.deprecated.csproj
set SlnExprCmd=%SlnTool% %SlnPath% add %TopDir%/expr/z0.expr.csproj
set SlnLangCmd=%SlnTool% %SlnPath% add %TopDir%/lang/z0.lang.csproj
set SlnExtractCmd=%SlnTool% %SlnPath% add %TopDir%/extract/z0.extract.csproj
set SlnRulesCmd=%SlnTool% %SlnPath% add %TopDir%/rules/z0.rules.csproj

set SlnGlueCmd=%SlnTool% %SlnPath% add %AppDir%/glue/z0.glue.csproj
set SlnLlvmToolsCmd=%SlnTool% %SlnPath% add %AppDir%/llvm.tools/z0.llvm.tools.csproj

set SlnLibsCmd=%SlnTool% %SlnPath% add %LibsRoot%/z0.libs.csproj
set SlnAsmCoreCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.core/z0.asm.core.csproj
set SlnAsmOperandsCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.operands/z0.asm.operands.csproj
set SlnAsmCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm/z0.asm.csproj
set SlnAsmPrototypesCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.prototypes/z0.asm.prototypes.csproj
set SlnAsmServicesCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.services/z0.asm.services.csproj

