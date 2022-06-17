//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class AsmCoreCmd
    {
        CpuIdSvc CpuId => Wf.CpuId();

        [CmdOp("sde/etl")]
        Outcome LoadCpuidRows(CmdArgs args)
        {
            var result = Outcome.Success;
            var sources = AppDb.DbIn("intel").Sources("sde.cpuid");
            var targets = AppDb.DbOut("sde");
            var src = CpuId.Import(
                sources.Root,
                targets.Path("sde.cpuid.records", FileKind.Csv),
                targets.Path("sde.cpuid.bits", FileKind.Csv)
                );

            return result;
        }
    }
}