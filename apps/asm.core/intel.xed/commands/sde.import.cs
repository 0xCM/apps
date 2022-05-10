//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class XedCmdProvider
    {
        [CmdOp("sde/import")]
        Outcome LoadCpuidRows(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = AsmTables.ImportCpuIdData(
                AppDb.CpuIdSources(),
                AppDb.SdeTarget("cpuid.records", FileKind.Csv),
                AppDb.SdeTarget("cpuid.bits", FileKind.Csv)
                );

            return result;
        }
    }
}