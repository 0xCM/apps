//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

/// <summary>
/// Defines identifiers for assemblies that comprise this ... monstrosity?
/// </summary>
public enum PartId : byte
{
    None = 0,

    [Symbol("root")]
    Root,

    [Symbol("asm.operands")]
    AsmOperands,

    [Symbol("part")]
    Part,

    [Symbol("asm.services")]
    AsmServices,

    [Symbol("core")]
    Core,

    [Symbol("generated")]
    Generated,

    [Symbol("apps.core")]
    AppCore,

    [Symbol("symbols")]
    Symbols,

    [Symbol("cmd.actions")]
    CmdActions,

    [Symbol("asm.prototypes")]
    AsmPrototypes,

    [Symbol("polyrand")]
    Polyrand,

    [Symbol("test.checks")]
    Checks,

    [Symbol("machines.x86")]
    X86Machine,

    [Symbol("assets")]
    Assets,

    [Symbol("numbers")]
    Numbers,

    [Symbol("cli")]
    Cli,

    [Symbol("llvm.tools")]
    LlvmTools,

    [Symbol("llvm.data")]
    LlvmData,

    [Symbol("calcs")]
    Calcs,

    [Symbol("resources")]
    Resources,

    [Symbol("tools")]
    Tools,

    [Symbol("tooling")]
    Tooling,

    [Symbol("apicore")]
    ApiCore,

    [Symbol("interop")]
    Interop,

    [Symbol("cpu")]
    Cpu,

    [Symbol("gen")]
    Gen,

    [Symbol("agents")]
    Agents,

    [Symbol("test.units")]
    TestUnits,

    [Symbol("bits")]
    Bits,

    [Symbol("deprecated")]
    Deprecated,

    [Symbol("bitspans")]
    BitSpans,

    [Symbol("settings")]
    Settings,

    [Symbol("logix")]
    Logix,

    [Symbol("libm")]
    LibM,

    [Symbol("libs")]
    Libs,

    [Symbol("glue")]
    Glue,

    [Symbol("mkl")]
    Mkl,

    [Symbol("asm")]
    Asm,

    [Symbol("lang")]
    Lang,

    [Symbol("asm.core")]
    AsmCore,

    [Symbol("asm.models")]
    AsmModels,

    [Symbol("dynamic.linq")]
    DynamicLinq,

    [Symbol("capture")]
    Capture,

    [Symbol("evaluate")]
    Evaluate,

    [Symbol("capture.checks")]
    CaptureChecks,

    [Symbol("diagnosics")]
    Diagnostics,

    [Symbol("cpu.dsl")]
    CpuDsl,

    [Symbol("bits.test")]
    BitsTest,

    [Symbol("cpu.test")]
    CpuTest,

    [Symbol("archives.core")]
    Archives,

    [Symbol("archives.memory")]
    MemoryArchives,

    [Symbol("archives.modules")]
    ModuleArchives,

    [Symbol("services")]
    Services,

    [Symbol("literals")]
    Literals,

    [Symbol("lib")]
    Lib,

    [Symbol("test")]
    LibTest,

    [Symbol("libs.root")]
    LibsRoot,

    [Symbol("expr")]
    Expr,

    [Symbol("extract")]
    Extract,

    [Symbol("intel.core")]
    IntelCore,

    [Symbol("intel.intrinsics")]
    IntelIntrinsics,

    [Symbol("intel.xed")]
    IntelXed,

    [Symbol("intel.sdm")]
    IntelSdm,

    [Symbol("intel.sde")]
    IntelSde,

    [Symbol("alloc")]
    Alloc,

    [Symbol("commands")]
    Commands,

    [Symbol("api.code")]
    ApiCode,

    [Symbol("api.md")]
    ApiMd,

    [Symbol("rules")]
    Rules,

    // ~ Generated 100 .. 127
    // ~ -------------------------------------------------------------------------------

    [Symbol("codegen.common")]
    CgCommon = 100,

    [Symbol("codegen.intel")]
    CgIntel,

    [Symbol("codegen.llvm")]
    CgLlvm,

    // ~ Shells : 128 ..
    // ~ -------------------------------------------------------------------------------

    [Symbol("gen.shell")]
    CgShell = 128,

    [Symbol("intel.shell")]
    IntelShell,

    [Symbol("xed.shell")]
    XedShell,

    [Symbol("cmd.shell")]
    CmdShell,

    [Symbol("codegen.test")]
    CgTest,

    [Symbol("asm.shell")]
    AsmShell,

    [Symbol("tools.shell")]
    ToolShell,

    [Symbol("calc.shell")]
    CalcShell,

    [Symbol("asmz")]
    AsmZ,

    [Symbol("run")]
    Run,

    [Symbol("test.runner")]
    TestRunner,

    [Symbol("asm.run")]
    AsmRun,

    [Symbol("machines")]
    Machines,

    [Symbol("llvm.tool")]
    LlvmTool,

    [Symbol("cmd")]
    Cmd,

    [Symbol("contral")]
    Control,

    [Symbol("machine")]
    Machine,

    [Symbol("workers")]
    Workers,
}