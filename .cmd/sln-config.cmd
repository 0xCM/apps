@echo off
set SlnTool=dotnet sln
set SlnPath=%DevRoot%\dev\z0\z0.sln
set SlnLiteralsCmd=%SlnTool% %SlnPath% add %LiteralRoot%/z0.literals.csproj
set SlnCmdShell=%SlnTool% %SlnPath% add %WsRoot%/cmd/z0.cmd.csproj

set SlnLibsCmd=%SlnTool% %SlnPath% add %LibsRoot%/z0.libs.csproj
set SlnZLibCmd=%SlnTool% %SlnPath% add %LibsRoot%/lib/z0.lib.csproj
set SlnLibsCoreCmd==%SlnTool% %SlnPath% add %LibsRoot%/libs.core/z0.libs.core.csproj
set SlnAsmCoreCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.core/z0.asm.core.csproj
set SlnAsmModelsCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.models/z0.asm.models.csproj
set SlnAsmOperandsCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.operands/z0.asm.operands.csproj
set SlnAsmCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm/z0.asm.csproj
set SlnAsmPrototypesCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.prototypes/z0.asm.prototypes.csproj
set SlnGlueCmd=%SlnTool% %SlnPath% add %LibsRoot%/glue/z0.glue.csproj
set SlnCmdActionsCmd=%SlnTool% %SlnPath% add %LibsRoot%/cmd.actions/z0.cmd.actions.csproj
set SlnLlvmToolsCmd=%SlnTool% %SlnPath% add %LibsRoot%/llvm.tools/z0.llvm.tools.csproj
set SlnLlvmDataCmd=%SlnTool% %SlnPath% add %LibsRoot%/llvm.data/z0.llvm.data.csproj
set SlnAllocCmd=%SlnTool% %SlnPath% add %LibsRoot%/alloc/z0.alloc.csproj
set SlnApiCodeCmd=%SlnTool% %SlnPath% add %LibsRoot%/api.code/z0.api.code.csproj
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

set SlnTestChecksCmd=%SlnTool% %SlnPath% add %TestRoot%/test.checks/z0.test.checks.csproj
set SlnTestUnitsCmd=%SlnTool% %SlnPath% add %TestRoot%/test.units/z0.test.units.csproj
set SlnTestShellCmd=%SlnTool% %SlnPath% add %TestRoot%/test.shell/z0.test.shell.csproj

set SlnCgIntelCmd=%SlnTool% %SlnPath% add %CgRoot%/cg.intel/z0.cg.intel.csproj
set SlnCgCommonCmd=%SlnTool% %SlnPath% add %CgRoot%/cg.common/z0.cg.common.csproj
set SlnCgLlvmCmd=%SlnTool% %SlnPath% add %CgRoot%/cg.llvm/z0.cg.llvm.csproj
set SlnCgShellCmd=%SlnTool% %SlnPath% add %CgRoot%/cg.shell/z0.cg.shell.csproj
set SlnCgTestCmd=%SlnTool% %SlnPath% add %CgRoot%/cg.test/z0.cg.test.csproj

set SlnXedShellCmd=%SlnTool% %SlnPath% add %ShellRoot%\xed.shell\z0.xed.shell.csproj
set SlnIntelShellCmd=%SlnTool% %SlnPath% add %ShellRoot%\intel\z0.intel.csproj
set SlnAsmShellCmd=%SlnTool% %SlnPath% add %ShellRoot%\asm.shell\z0.asm.shell.csproj
set SlnWorkersCmd=%SlnTool% %SlnPath% add %ShellRoot%\workers\z0.workers.csproj

