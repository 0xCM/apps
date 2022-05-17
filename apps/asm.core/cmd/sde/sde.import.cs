//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class AsmCoreCmd
    {
        [CmdOp("sde/import")]
        Outcome LoadCpuidRows(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = AsmTables.ImportCpuIdData(
                AppDb.CpuIdSources(),
                AppDb.SdeTargets().Path("cpuid.records", FileKind.Csv),
                AppDb.SdeTargets().Path("cpuid.bits", FileKind.Csv)
                );

            return result;
        }


    }
}