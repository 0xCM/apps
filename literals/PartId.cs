//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using Z0;

[SymSource("parts")]
public enum PartId : byte
{
    None = 0,

    [Symbol("root")]
    Root,

    [Symbol("asm.operands")]
    AsmOperands,

    [Symbol("part")]
    Part,

    [Symbol("agents")]
    Agents,

    [Symbol("symbols")]
    Symbols,

    [Symbol("cmd.actions")]
    CmdActions,

    [Symbol("cmd.specs")]
    CmdSpecs,

    [Symbol("cmd.exec")]
    CmdExec,

    [Symbol("cmd.svc")]
    CmdSvc,

    [Symbol("cmd.flows")]
    CmdFlows,

    [Symbol("cmd.checks")]
    CmdChecks,

    [Symbol("cmd.tools")]
    CmdTools,

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

    [Symbol("circuits")]
    Circuits,

    [Symbol("text.sized")]
    SizedText,

    [Symbol("tools")]
    Tools,

    [Symbol("interop")]
    Interop,

    [Symbol("test.units")]
    TestUnits,

    [Symbol("bits")]
    Bits,

    [Symbol("deprecated")]
    Deprecated,

    [Symbol("nats")]
    Nats,

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

    [Symbol("render")]
    Render,

    [Symbol("native")]
    Native,

    [Symbol("capture.checks")]
    CaptureChecks,

    [Symbol("diagnosics")]
    Diagnostics,

    [Symbol("cpu.dsl")]
    CpuDsl,

    [Symbol("bits.test")]
    BitsTest,

    [Symbol("graphs")]
    Graphs,

    [Symbol("cpu.test")]
    CpuTest,

    [Symbol("archives.core")]
    Archives,

    [Symbol("memory")]
    Memory,

    [Symbol("db")]
    Db,

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

    [Symbol("fsm")]
    Fsm,

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

    [Symbol("lines")]
    Lines,

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

    [Symbol("containers")]
    Containers,

    [Symbol("emath")]
    EMath,

    [Symbol("templates")]
    Templates,

    [Symbol("digital")]
    Digital,

    [Symbol("models")]
    Models,

    // ~ Generated 100 .. 127
    // ~ -------------------------------------------------------------------------------

    [Symbol("codegen.common")]
    CgCommon = 100,

    [Symbol("codegen.intel")]
    CgIntel,

    [Symbol("codegen.llvm")]
    CgLlvm,

    [Symbol("cg.libs")]
    CgLibs,

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