//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

using Z0;

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

    [Symbol("cmd.actions")]
    CmdActions,

    [Symbol("asm.prototypes")]
    AsmPrototypes,

    [Symbol("polyrand")]
    Polyrand,

    [Symbol("test.checks")]
    Checks,

    [Symbol("res")]
    Res,

    [Symbol("machines.x86")]
    X86Machine,

    [Symbol("lines")]
    Lines,

    [Symbol("numbers")]
    Numbers,

    [Symbol("ws")]
    Ws,

    [Symbol("llvm.tools")]
    LlvmTools,

    [Symbol("llvm.models")]
    LlvmModels,

    [Symbol("calc")]
    Calc,

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

    [Symbol("bitvectors")]
    BitVectors,

    [Symbol("bitspans")]
    BitSpans,

    [Symbol("settings")]
    Settings,

    [Symbol("logix")]
    Logix,

    [Symbol("libm")]
    LibM,

    [Symbol("glue")]
    Glue,

    [Symbol("mkl")]
    Mkl,

    [Symbol("asm")]
    Asm,

    [Symbol("asm.lang")]
    AsmLang,

    [Symbol("asm.core")]
    AsmCore,

    [Symbol("dynamic.linq")]
    DynamicLinq,

    [Symbol("capture")]
    Capture,

    [Symbol("evaluate")]
    Evaluate,

    [Symbol("capture.checks")]
    CaptureChecks,

    [Symbol("validity")]
    Validity,

    [Symbol("cpu.dsl")]
    CpuDsl,

    [Symbol("bits.test")]
    BitsTest,

    [Symbol("cpu.test")]
    CpuTest,

    [Symbol("services")]
    Services,

    [Symbol("lib")]
    Lib,

    [Symbol("test")]
    LibTest,

    [Symbol("expr")]
    Expr,

    [Symbol("intel.intrinsics")]
    IntelIntrinsics,

    [Symbol("intel.xed")]
    IntelXed,

    [Symbol("intel.sdm")]
    IntelSdm,

    [Symbol("intel.sde")]
    IntelSde,

    // ~ Generated 64 .. 127
    // ~ -------------------------------------------------------------------------------

    [Symbol("codegen.common")]
    CgCommon = 100,

    [Symbol("codegen.intel")]
    CgIntel = CgCommon + 1,

    [Symbol("codegen.llvm")]
    CgLlvm = CgIntel + 1,

    // ~ Shells : 128 ..
    // ~ -------------------------------------------------------------------------------

    [Symbol("gen.shell")]
    CgShell = (byte)Pow2.T07,

    [Symbol("codegen.test")]
    CgTest = CgShell + 1,

    [Symbol("asm.shell")]
    AsmShell = CgTest + 1,

    [Symbol("tools.shell")]
    ToolShell = AsmShell + 1,

    [Symbol("calc.shell")]
    CalcShell = ToolShell + 1,

    [Symbol("asmz")]
    AsmZ = CalcShell + 1,

    [Symbol("run")]
    Run = AsmZ + 1,

    [Symbol("test.runner")]
    TestRunner = Run + 1,

    [Symbol("xed.shell")]
    XedShell = TestRunner + 1,

    [Symbol("cmd.shell")]
    CmdShell = XedShell + 1,

    [Symbol("asm.run")]
    AsmRun = CmdShell + 1,

    [Symbol("machines")]
    Machines = AsmRun + 1,

    [Symbol("llvm.tool")]
    LlvmTool = Machines + 1,

    [Symbol("cmd")]
    Cmd = LlvmTool + 1,

    [Symbol("contral")]
    Control = Cmd + 1,

    [Symbol("machine")]
    Machine = Control + 1,

    [Symbol("workers")]
    Workers = Machine + 1,
}