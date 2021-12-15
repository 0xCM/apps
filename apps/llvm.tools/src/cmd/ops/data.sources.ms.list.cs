//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        Generators Generators => Service(Wf.Generators);

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
                Generators.EmitArrayInitializer(items,dst);
                Write(dst.Emit());

            }
            return true;
        }
    }
}