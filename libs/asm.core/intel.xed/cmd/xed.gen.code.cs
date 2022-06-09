//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    // using Z0.Strings;

    // partial class AsmCoreCmd
    // {
    //     [CmdOp("xed/gen/code")]
    //     void GenXedCode()
    //     {

    //         //Status($"Validatd {count} entries");

    //         var spec = Symbolic.expr<InstFormType>(
    //             indexNs:"Z0",
    //             tableNs:"Z0.Strings",
    //             emitIndex:false,
    //             parametric:false
    //             );

    //         var table = CsLang.EmitStringTable(spec, AppDb.CgTargets(CgTarget.Intel, "stringtables"));
    //         var count = table.EntryCount;
    //         for(var i=z16; i<count; i++)
    //         {
    //             if(i != 0)
    //             {
    //                 var entry = table.String(i);
    //                 ref readonly var name = ref table.Names[i];
    //                 Require.equal(text.format(table.String(i)), name);
    //             }
    //         }
    //     }

    //     [CmdOp("xed/gen/check")]
    //     void CheckStringTables()
    //     {
    //         var table = InstFormTypeST.Strings.Kinded<InstFormType>();
    //         var count = table.EntryCount;
    //         for(var i=z16; i<count; i++)
    //         {
    //             var entry = table.String(i);
    //             if(i != 0)
    //             {
    //                 Require.equal(i, (ushort)entry.Kind);
    //                 Require.equal(entry.Kind.ToString(), entry.Format());
    //             }
    //         }
    //     }
    // }
}