//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class AsmCoreCmd
    {
        CpuIdSvc CpuId => Service(Wf.CpuId);

        [CmdOp("sde/import")]
        Outcome LoadCpuidRows(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = CpuId.Import(
                AppDb.CpuIdSources(),
                AppDb.SdeTargets().Path("cpuid.records", FileKind.Csv),
                AppDb.SdeTargets().Path("cpuid.bits", FileKind.Csv)
                );

            return result;
        }
    }
}