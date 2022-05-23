//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    partial class ProjectCmd
    {
        CsLang CsLang => Service(Wf.CsLang);

        public static ItemList<Constant<T>> items<T>(string name, T[] src)
            => new (name, src.Mapi((i,x) => new ListItem<Constant<T>>((uint)i,x)));

        [CmdOp("gen/cs/keywords")]
        void GenCsKeywords()
        {
            var src = ProjectDb.Source("ms","ms.cs.keywords", FS.List);
            const string FieldName = "CsKeywordList";
            if(!src.Exists)
            {
                Error(FS.missing(src));
            }
            else
            {
                var list = items(FieldName, src.ReadLines(skipBlank:true).Storage);
                var dst = text.buffer();
                dst.Append("public static string[] ");
                CsLang.EmitArrayInitializer(list,dst);
                Write(dst.Emit());
            }
        }
    }
}