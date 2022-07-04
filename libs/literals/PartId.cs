//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[SymSource("parts")]
public enum PartId : byte
{
    None = 0,

    [Symbol("part")]
    Part,

    [Symbol("root")]
    Root,

    [Symbol("asm.operands")]
    AsmOperands,

    [Symbol("asm.svc")]
    AsmSvc,

    [Symbol("asm.prototypes")]
    AsmPrototypes,

    [Symbol("asm.checks")]
    AsmChecks,

    [Symbol("asm")]
    Asm,

    [Symbol("asm.core")]
    AsmCore,

    [Symbol("asm.models")]
    AsmModels,

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

    [Symbol("queues.checks")]
    QueueChecks,

    [Symbol("cmd.svc")]
    CmdSvc,

    [Symbol("cmd.flows")]
    CmdFlows,

    [Symbol("cmd.checks")]
    CmdChecks,

    [Symbol("cmd.tools")]
    CmdTools,


    [Symbol("files")]
    Files,

    [Symbol("validity")]
    Validity,

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

    [Symbol("clr.checks")]
    ClrChecks,

    [Symbol("clr.query")]
    ClrQuery,

    [Symbol("clr.cil")]
    ClrCil,

    [Symbol("llvm.tools")]
    LlvmTools,

    [Symbol("llvm.labs")]
    LlvmLabs,

    [Symbol("llvm.svc")]
    LlvmSvc,

    [Symbol("llvm.checks")]
    LlvmChecks,

    [Symbol("calcs")]
    Calcs,

    [Symbol("circuits")]
    Circuits,

    [Symbol("text.sized")]
    SizedText,

    [Symbol("dynamic")]
    Dynamic,

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

    [Symbol("lang")]
    Lang,


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

    [Symbol("queues")]
    Queues,

    [Symbol("diagnosics")]
    Diagnostics,

    [Symbol("graphs")]
    Graphs,

    [Symbol("cpu.test")]
    CpuTest,

    [Symbol("archives.core")]
    Archives,

    [Symbol("memory")]
    Memory,

    [Symbol("memory.svc")]
    MemorySvc,

    [Symbol("memory.checks")]
    MemoryChecks,

    [Symbol("monadic")]
    Monadic,

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

    [Symbol("commands")]
    Commands,

    [Symbol("api.code")]
    ApiCode,

    [Symbol("api.md")]
    ApiMd,

    [Symbol("api.cmd")]
    ApiCmd,

    [Symbol("api.checks")]
    ApiChecks,

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

    [Symbol("wf")]
    Wf,

    [Symbol("imagine")]
    Imagine,

    [Symbol("sys")]
    Sys,

    [Symbol("pow2")]
    Pow2,

    [Symbol("linq")]
    Linq,

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

    [Symbol("tools.shell")]
    ToolShell,

    [Symbol("calc.shell")]
    CalcShell,

    [Symbol("calc.checks")]
    CalcChecks,

    [Symbol("run")]
    Run,

    [Symbol("test.runner")]
    TestRunner,

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