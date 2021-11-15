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
    Root = 1,

    [Symbol("external")]
    External = 2,

    [Symbol("part")]
    Part = 3,

    [Symbol("math")]
    Math = 4,

    [Symbol("core")]
    Core = 5,

    [Symbol("rules")]
    Rules = 6,

    [Symbol("bit")]
    Bit = 7,

    [Symbol("files")]
    Files = 8,

    [Symbol("api")]
    Api = 9,

    [Symbol("types")]
    Types = 10,

    [Symbol("term")]
    Term = 11,

    [Symbol("cells")]
    Cells = 12,

    [Symbol("asmm")]
    AsmM = 13,

    [Symbol("asci")]
    Asci = 14,

    [Symbol("workflow")]
    Workflow = 15,

    [Symbol("processors")]
    Processors = 16,

    [Symbol("polyrand")]
    Polyrand = 17,

    [Symbol("digital")]
    Digital = 18,

    [Symbol("check")]
    Check = 19,

    [Symbol("res")]
    Res = 20,

    Open21 = 21,

    [Symbol("lang")]
    Lang = 22,

    [Symbol("hash")]
    Hash = 23,

    [Symbol("blocks")]
    Blocks = 24,

    [Symbol("commands")]
    Commands = 25,

    [Symbol("asm.data")]
    AsmData = 26,

    [Symbol("containers")]
    Containers = 27,

    [Symbol("text")]
    Text = 28,

    [Symbol("blittable")]
    Blittable = 29,

    [Symbol("ws")]
    Ws = 30,

    [Symbol("llvm.tools")]
    LlvmTools = 31,

    [Symbol("llvm.models")]
    LlvmModels = 32,

    [Symbol("seq")]
    Seq = 33,

    [Symbol("gmath")]
    GMath = 34,

    [Symbol("xml")]
    Xml = 35,

    [Symbol("models.shell")]
    ModelShell = 36,

    [Symbol("calc")]
    Calc = 37,

    [Symbol("time")]
    Time = 38,

    [Symbol("resources")]
    Resources = 39,

    [Symbol("events")]
    Events = 40,

    [Symbol("tools")]
    Tools = 41,

    [Symbol("tooling")]
    Tooling = 42,

    [Symbol("fsm")]
    Fsm = 43,

    [Symbol("apicore")]
    ApiCore= 44,

    [Symbol("interop")]
    Interop = 45,

    [Symbol("cpu")]
    Cpu = 46,

    [Symbol("llvm.tool")]
    LlvmTool = 47,

    [Symbol("gen")]
    Gen = 48,

    [Symbol("sfuncs")]
    SFuncs = 49,

    [Symbol("pipes")]
    Pipes = 50,

    [Symbol("agents")]
    Agents = 51,

    [Symbol("relations")]
    Relations = 52,

    [Symbol("asm.shell")]
    AsmShell = 53,

    [Symbol("graphs")]
    Graphs = 54,

    [Symbol("tools.shell")]
    ToolShell = 55,

    [Symbol("calc.shell")]
    CalcShell = 56,

    [Symbol("math.test")]
    MathTest = 57,

    [Symbol("clr")]
    Clr = 58,

    [Symbol("cli")]
    Cli = 59,

    [Symbol("canonical")]
    Canonical = 60,

    [Symbol("symbolic")]
    Symbolic = 61,

    [Symbol("tables")]
    Tables = 62,

    [Symbol("gather")]
    Gather = 63,

    [Symbol("spanblocks")]
    SpanBlocks = 64,

    [Symbol("minidump")]
    Minidump = 65,

    [Symbol("bits")]
    Bits = 66,

    [Symbol("bitfields")]
    Bitfields = 67,

    [Symbol("symcore")]
    SymCore = 68,

    [Symbol("cli.shell")]
    CliShell = 69,

    [Symbol("bitvectors")]
    BitVectors = 71,

    [Symbol("bitspans")]
    BitSpans = 72,

    [Symbol("bitstrings")]
    BitStrings = 73,

    [Symbol("bitgrids")]
    BitGrids = 74,

    [Symbol("bitpack")]
    BitPack = 75,

    [Symbol("settings")]
    Settings = 78,

    [Symbol("logix")]
    Logix = 79,

    [Symbol("libm")]
    LibM = 80,

    [Symbol("glue")]
    Glue = 81,

    [Symbol("machines")]
    Machines = 82,

    [Symbol("nats")]
    Nats = 83,

    [Symbol("mkl")]
    Mkl = 84,

    [Symbol("stats")]
    Stats = 85,

    [Symbol("dynamic")]
    Dynamic = 86,

    [Symbol("asm")]
    Asm = 87,

    [Symbol("asm.lang")]
    AsmLang = 88,

    [Symbol("asm.core")]
    AsmCore = 89,

    [Symbol("asm.cases")]
    AsmCases = 90,

    [Symbol("asm.run")]
    AsmRun = 91,

    [Symbol("dynamic.linq")]
    DynamicLinq = 92,

    [Symbol("capture")]
    Capture = 93,

    [Symbol("evaluate")]
    Evaluate = 94,

    [Symbol("extract")]
    Extract = 95,

    [Symbol("bitnumbers")]
    BitNumbers = 96,

    [Symbol("expr")]
    Expr = 97,

    [Symbol("workers")]
    Workers = 99,

    [Symbol("capture.checks")]
    CaptureChecks = 100,

    [Symbol("grids")]
    Grids = 101,

    [Symbol("validity")]
    Validity = 102,

    [Symbol("cpu.dsl")]
    CpuDsl = 103,

    [Symbol("bits.test")]
    BitsTest = 104,

    [Symbol("logix.test")]
    LogixTest = 105,

    [Symbol("cpu.test")]
    CpuTest = 106,

    [Symbol("services")]
    Services = 107,

    [Symbol("run")]
    Run = 108,

    [Symbol("machine")]
    Machine = 109,

    [Symbol("contral")]
    Control = 110,

    [Symbol("gen.shell")]
    GenApp = 111,

    [Symbol("asmz")]
    AsmZ = 112,

    [Symbol("lib")]
    Lib = 128,

    // ~ Generated
    // ~ -------------------------------------------------------------------------------

    [Symbol("asm.lang.g")]
    AsmLangG = 200,
}