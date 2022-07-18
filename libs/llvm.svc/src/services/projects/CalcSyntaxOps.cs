//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectSvc
    {
        public Index<AsmSyntaxOps> CalcSyntaxOps(IProjectWsObsolete src)
        {
            var rows = LoadAsmSyntax(src);
            var count = rows.Count;
            var opLists = CalcAsmSyntaxOps(rows);
            var dst = alloc<AsmSyntaxOps>(count);
            Require.equal(count, opLists.Count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new AsmSyntaxOps(rows[i],opLists[i]);
            return dst;
        }
    }
}