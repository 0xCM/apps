//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;

    using static core;
    using static llvm.LlvmSubtarget;

    partial class ProjectSvc
    {
        public Index<AsmSyntaxOps> CalcSyntaxOps(IProjectWs project)
        {
            var rows = LoadAsmSyntax(project);
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