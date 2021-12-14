//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    partial class LlvmCmd
    {
        [CmdOp("sources/ms/cs/keywords")]
        Outcome CsKeywords(CmdArgs args)
        {
            var src = ProjectDb.Source("ms","ms.cs.keywords", FS.List);
            if(!src.Exists)
            {
                Error(FS.missing(src));
            }
            else
            {
                var items = new ItemList<Constant<string>>("CsKeywordList", mapi(src.ReadLines(), (i,line) => new ListItem<Constant<string>>((uint)i,text.trim(line))));
                var dst = text.buffer();
                items.RenderArraySyntax(dst);
                Write(dst.Emit());

            }
            return true;

        }
    }
}

namespace Z0
{

    public static partial class XTend
    {
        public static void RenderArraySyntax<T>(this ItemList<Constant<T>> src, ITextBuffer dst)
        {
            var count = src.Count;
            var keyword = CsKeywords.keyword(typeof(T));
            dst.AppendFormat("{0} = new {1}[{2}]{{", src.Name, keyword, count);
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref src[i];

                dst.AppendFormat("{0},", item.Value.Format());
            }
            dst.Append("};");
        }
    }
}