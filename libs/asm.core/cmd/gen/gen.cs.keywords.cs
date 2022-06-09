//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {
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
                var list = Literals.items(FieldName, src.ReadLines(skipBlank:true).Storage);
                var dst = text.buffer();
                dst.Append("public static string[] ");
                CsLang.EmitArrayInitializer(list,dst);
                Write(dst.Emit());
            }
        }
    }
}