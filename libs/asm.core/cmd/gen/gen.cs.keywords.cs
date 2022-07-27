//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("gen/cs/keywords")]
        void GenCsKeywords()
        {
            var src = AppDb.App().Path("ms.cs.keywords", FileKind.List);
            const string FieldName = "CsKeywordList";
            if(!src.Exists)
            {
                Error(FS.missing(src));
            }
            else
            {
                var list = ItemLists.constants(FieldName, src.ReadLines(skipBlank:true).Storage);
                var dst = text.buffer();
                dst.Append("public static string[] ");
                CsLang.EmitArrayInitializer(list,dst);
                Write(dst.Emit());
            }
        }
    }
}