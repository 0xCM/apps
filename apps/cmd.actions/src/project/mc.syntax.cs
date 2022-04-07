//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("mc/syntax")]
        Outcome McSyntax(CmdArgs args)
        {
            var rows = ProjectData.LoadAsmSyntax(Project());
            var count = rows.Count;
            var opLists = ProjectData.CalcAsmSyntaxOps(rows);
            Require.equal(count, opLists.Count);

            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref rows[i];
                ref readonly var oplist = ref opLists[i];
                var content = row.Syntax;
                Write(string.Format("{0,-8} | {1,-64} | {2}",
                    row.Seq,
                    row.Asm,
                    oplist.Delimit(Chars.Space)
                    ));
            }

            return true;
        }
    }
}