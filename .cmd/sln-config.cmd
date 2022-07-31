@REM @echo off
@REM set SlnTool=dotnet sln
@REM set SlnPath=%DevRoot%\dev\z0\z0.sln
@REM set SlnLiteralsCmd=%SlnTool% %SlnPath% add %LiteralRoot%/z0.literals.csproj
@REM set SlnCmdShell=%SlnTool% %SlnPath% add %WsRoot%/cmd/z0.cmd.csproj

@REM set SlnLibsCmd=%SlnTool% %SlnPath% add %LibsRoot%/z0.libs.csproj
@REM set SlnZLibCmd=%SlnTool% %SlnPath% add %LibsRoot%/lib/z0.lib.csproj
@REM set SlnLibsCoreCmd==%SlnTool% %SlnPath% add %LibsRoot%/libs.core/z0.libs.core.csproj
@REM set SlnAsmCoreCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.core/z0.asm.core.csproj
@REM set SlnAsmModelsCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.models/z0.asm.models.csproj
@REM set SlnAsmOperandsCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.operands/z0.asm.operands.csproj
@REM set SlnAsmCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm/z0.asm.csproj
@REM set SlnAsmPrototypesCmd=%SlnTool% %SlnPath% add %LibsRoot%/asm.prototypes/z0.asm.prototypes.csproj
@REM set SlnGlueCmd=%SlnTool% %SlnPath% add %LibsRoot%/glue/z0.glue.csproj
@REM set SlnCmdActionsCmd=%SlnTool% %SlnPath% add %LibsRoot%/cmd.actions/z0.cmd.actions.csproj
@REM set SlnLlvmToolsCmd=%SlnTool% %SlnPath% add %LibsRoot%/llvm.tools/z0.llvm.tools.csproj
@REM set SlnLlvmDataCmd=%SlnTool% %SlnPath% add %LibsRoot%/llvm.data/z0.llvm.data.csproj
@REM set SlnAllocCmd=%SlnTool% %SlnPath% add %LibsRoot%/alloc/z0.alloc.csproj
@REM set SlnApiCodeCmd=%SlnTool% %SlnPath% add %LibsRoot%/api.code/z0.api.code.csproj
@REM set SlnAssetsCmd=%SlnTool% %SlnPath% add %LibsRoot%/assets/z0.assets.csproj
@REM set SlnBitsCmd=%SlnTool% %SlnPath% add %LibsRoot%/bits/z0.bits.csproj
@REM set SlnCommandsCmd=%SlnTool% %SlnPath% add %LibsRoot%/commands/z0.commands.csproj
@REM set SlnMachinesCmd=%SlnTool% %SlnPath% add %LibsRoot%/machines/z0.machines.csproj
@REM set SlnNumbersCmd=%SlnTool% %SlnPath% add %LibsRoot%/numbers/z0.numbers.csproj
@REM set SlnSymbolsCmd=%SlnTool% %SlnPath% add %LibsRoot%/symbols/z0.symbols.csproj
@REM set SlnDiagnosticsCmd=%SlnTool% %SlnPath% add %LibsRoot%/diagnostics/z0.diagnostics.csproj
@REM set SlnApiMd=%SlnTool% %SlnPath% add %LibsRoot%/api.md/z0.api.md.csproj
@REM set SlnDeprecatedCmd=%SlnTool% %SlnPath% add %LibsRoot%/deprecated/z0.deprecated.csproj
@REM set SlnExprCmd=%SlnTool% %SlnPath% add %LibsRoot%/expr/z0.expr.csproj
@REM set SlnLangCmd=%SlnTool% %SlnPath% add %LibsRoot%/lang/z0.lang.csproj
@REM set SlnExtractCmd=%SlnTool% %SlnPath% add %LibsRoot%/extract/z0.extract.csproj
@REM set SlnRulesCmd=%SlnTool% %SlnPath% add %LibsRoot%/rules/z0.rules.csproj
@REM set SlnIntelCoreCmd=%SlnTool% %SlnPath% add %LibsRoot%/intel.core/z0.intel.core.csproj
@REM set SlnIntelIntrinsicsCmd=%SlnTool% %SlnPath% add %LibsRoot%/intel.intrinsics/z0.intel.intrinsics.csproj
@REM set SlnIntelXedCmd=%SlnTool% %SlnPath% add %LibsRoot%/intel.xed/z0.intel.xed.csproj

@REM set SlnTestChecksCmd=%SlnTool% %SlnPath% add %TestRoot%/test.checks/z0.test.checks.csproj
@REM set SlnTestUnitsCmd=%SlnTool% %SlnPath% add %TestRoot%/test.units/z0.test.units.csproj
@REM set SlnTestShellCmd=%SlnTool% %SlnPath% add %TestRoot%/test.shell/z0.test.shell.csproj

@REM set SlnCgIntelCmd=%SlnTool% %SlnPath% add %CgRoot%/cg.intel/z0.cg.intel.csproj
@REM set SlnCgCommonCmd=%SlnTool% %SlnPath% add %CgRoot%/cg.common/z0.cg.common.csproj
@REM set SlnCgLlvmCmd=%SlnTool% %SlnPath% add %CgRoot%/cg.llvm/z0.cg.llvm.csproj
@REM set SlnCgShellCmd=%SlnTool% %SlnPath% add %CgRoot%/cg.shell/z0.cg.shell.csproj
@REM set SlnCgTestCmd=%SlnTool% %SlnPath% add %CgRoot%/cg.test/z0.cg.test.csproj

@REM set SlnXedShellCmd=%SlnTool% %SlnPath% add %ShellRoot%\xed.shell\z0.xed.shell.csproj
@REM set SlnIntelShellCmd=%SlnTool% %SlnPath% add %ShellRoot%\intel\z0.intel.csproj
@REM set SlnAsmShellCmd=%SlnTool% %SlnPath% add %ShellRoot%\asm.shell\z0.asm.shell.csproj
@REM set SlnWorkersCmd=%SlnTool% %SlnPath% add %ShellRoot%\workers\z0.workers.csproj
