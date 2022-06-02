//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using Z0.Strings;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/gen/check")]
        void GenXedCode()
        {
            var table = IFormTypeST.Strings.Kinded<InstFormType>();
            var count = table.EntryCount;
            for(var i=z16; i<count; i++)
            {
                var entry = table.String(i);
                if(i != 0)
                {
                    Require.equal(i, (ushort)entry.Kind);
                    Require.equal(entry.Kind.ToString(), entry.Format());
                }
            }

            var spec = SymTables.expressions<InstFormType>(
                indexNs:"Z0",
                tableNs:"Z0.Strings",
                emitIndex:false,
                parametric:false
                );

            var dst = AppDb.CgTarget(CgTarget.Intel);
            Status($"Validatd {count} entries");
        }
    }
}