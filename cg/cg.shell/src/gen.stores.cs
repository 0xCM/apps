//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class GenCmdProvider
    {
        CsLang CsLang => Wf.CsLang();

        [CmdOp("gen/enum/cs/keywords")]
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
                CsLang.EmitArrayInitializer(items,dst);
                Write(dst.Emit());

            }
            return true;
        }

        [CmdOp("gen/stores")]
        Outcome GenStores(CmdArgs args)
        {
            var assets = Parts.GenApp.Assets;
            var stores = assets.DataStoresTemplate().Utf8();
            var store = assets.DataStoreTemplate().Utf8();
            //var path = AppDb.CgStagePath("DataStores", FileKind.Cs);
            var path = FS.FilePath.Empty;

            var buffer = text.buffer();
            buffer.AppendLine(stores);

            var count = 1024;
            for(var i=1; i<=count; i++)
            {
                buffer.AppendLine();
                buffer.AppendLine(expand(store, i));
            }

            FileEmit(buffer.Emit(), count,path);
            return true;
        }

        static string expand(string src, params object[] ops)
        {
            var dst = src;
            var slots = mapi(ops, (i,op) => text.enclose(i, "`{", "}`"));
            for(var i=0; i<slots.Length; i++)
            {
                ref readonly var slot = ref skip(slots,i);
                ref readonly var op = ref skip(ops,i);
                dst = text.replace(dst, slot, op?.ToString() ?? EmptyString);
            }
            return dst;
        }
    }
}