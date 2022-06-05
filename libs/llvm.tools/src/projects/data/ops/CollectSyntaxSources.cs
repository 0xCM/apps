//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectDataServices
    {
        public Index<McAsmDoc> CollectSyntaxDocs(WsContext context)
        {
            var src = SynAsmSources(context.Project).View;
            var count = src.Length;
            var dst = list<McAsmDoc>();
            for(var i=0; i<count; i++)
                dst.Add(CalcMcAsmDoc(context.Ref(skip(src,i))));
            return dst.ToArray();
        }
    }
}