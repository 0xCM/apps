@echo off
set SlnTool=dotnet sln
set SlnPath=%SlnDir%/%SlnName%
set SlnZLibCmd=%SlnTool% %SlnPath% add %LibDir%/z0.lib.csproj

set SlnLibsCmd=%SlnTool% %SlnPath% add %LibsRoot%/z0.libs.csproj
set SlnAsmCoreCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.core/z0.asm.core.csproj
set SlnAsmOperandsCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.operands/z0.asm.operands.csproj
set SlnAsmCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm/z0.asm.csproj
set SlnAsmPrototypesCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.prototypes/z0.asm.prototypes.csproj
set SlnAsmServicesCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.services/z0.asm.services.csproj
set SlnGlueCmd=%SlnTool% %SlnPath% add %LibsRoot%/glue/z0.glue.csproj
set SlnCmdActionsCmd=%SlnTool% %SlnPath% add %LibsRoot%/cmd.actions/z0.cmd.actions.csproj
set SlnLlvmToolsCmd=%SlnTool% %SlnPath% add %LibsRoot%/llvm.tools/z0.llvm.tools.csproj
set SlnLlvmModelsCmd=%SlnTool% %SlnPath% add %LibsRoot%/llvm.tools/z0.llvm.tools.csproj
set SlnAllocCmd=%SlnTool% %SlnPath% add %LibsRoot%/alloc/z0.alloc.csproj
set SlnApiCodeCmd=%SlnTool% %SlnPath% add %LibsRoot%/api.code/z0.api.code.csproj
set SlnArchivesCmd=%SlnTool% %SlnPath% add %LibsRoot%/archives/z0.archives.csproj
set SlnAssetsCmd=%SlnTool% %SlnPath% add %LibsRoot%/assets/z0.assets.csproj
set SlnBitsCmd=%SlnTool% %SlnPath% add %LibsRoot%/bits/z0.bits.csproj
set SlnCommandsCmd=%SlnTool% %SlnPath% add %LibsRoot%/commands/z0.commands.csproj
set SlnMachinesCmd=%SlnTool% %SlnPath% add %LibsRoot%/machines/z0.machines.csproj
set SlnNumbersCmd=%SlnTool% %SlnPath% add %LibsRoot%/numbers/z0.numbers.csproj
set SlnSymbolsCmd=%SlnTool% %SlnPath% add %LibsRoot%/symbols/z0.symbols.csproj
set SlnDiagnosticsCmd=%SlnTool% %SlnPath% add %LibsRoot%/diagnostics/z0.diagnostics.csproj
set SlnApiMd=%SlnTool% %SlnPath% add %LibsRoot%/api.md/z0.api.md.csproj
set SlnDeprecatedCmd=%SlnTool% %SlnPath% add %LibsRoot%/deprecated/z0.deprecated.csproj
set SlnExprCmd=%SlnTool% %SlnPath% add %LibsRoot%/expr/z0.expr.csproj
set SlnLangCmd=%SlnTool% %SlnPath% add %LibsRoot%/lang/z0.lang.csproj
set SlnExtractCmd=%SlnTool% %SlnPath% add %LibsRoot%/extract/z0.extract.csproj
set SlnRulesCmd=%SlnTool% %SlnPath% add %LibsRoot%/rules/z0.rules.csproj
set SlnIntelCoreCmd=%SlnTool% %SlnPath% add %LibsRoot%/intel.core/z0.intel.core.csproj
set SlnIntelIntrinsicsCmd=%SlnTool% %SlnPath% add %LibsRoot%/intel.intrinsics/z0.intel.intrinsics.csproj
set SlnIntelXedCmd=%SlnTool% %SlnPath% add %LibsRoot%/intel.xed/z0.intel.xed.csproj

set SlnTestChecksCmd=%SlnTool% %SlnPath% add %TestDir%/test.checks/z0.test.checks.csproj
set SlnTestUnitsCmd=%SlnTool% %SlnPath% add %TestDir%/test.units/z0.test.units.csproj
set SlnTestShellCmd=%SlnTool% %SlnPath% add %TestDir%/test.shell/z0.test.shell.csproj

set SlnXedShellCmd=%SlnTool% %SlnPath% add %TopDir%/xed.shell/z0.xed.shell.csproj
set SlnIntelShellCmd=%SlnTool% %SlnPath% add %TopDir%/intel.shell/z0.intel.shell.csproj
set SlnCgIntelCmd=%SlnTool% %SlnPath% add %CgDir%/codegen.intel/z0.codegen.intel.csproj
set SlnCgCommonCmd=%SlnTool% %SlnPath% add %CgDir%/codegen.common/z0.codegen.common.csproj
set SlnCgLlvmCmd=%SlnTool% %SlnPath% add %CgDir%/codegen.llvm/z0.codegen.llvm.csproj
set SlnCgShellCmd=%SlnTool% %SlnPath% add %CgDir%/codegen.shell/z0.codegen.shell.csproj

set SlnAsmShellCmd=%SlnTool% %SlnPath% add %ShellRoot%\asm.shell\z0.asm.shell.csproj
set SlnCmdShellCmd=%SlnTool% %SlnPath% add %ShellRoot%\cmd\z0.cmd.csproj
set SlnWorkersCmd=%SlnTool% %SlnPath% add %ShellRoot%\workers\z0.workers.csproj
