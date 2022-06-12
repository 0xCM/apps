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
            var src = CpuId.Import(
                AppDb.CpuIdSources().Root,
                AppDb.SdeTargets().Path("sde.cpuid.records", FileKind.Csv),
                AppDb.SdeTargets().Path("sde.cpuid.bits", FileKind.Csv)
                );

            return result;
        }
    }
}