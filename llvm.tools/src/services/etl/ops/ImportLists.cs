//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmRecordEtl
    {
        public ReadOnlySpan<ItemList<string>> ImportLists()
        {
            var svc = Wf.Assets();
            var input = LlvmPaths.ListSourceFiles().View;
            var count = input.Length;
            var lists = list<ItemList<string>>();
            for(var i=0; i<count; i++)
            {
                ref readonly var src = ref skip(input,i);
                var name = src.FileName.WithoutExtension.Format();
                var items = FS.listed(src);
                lists.Add(items);
                svc.EmitTable(name, items.View, LlvmPaths.ListImportPath(name));
            }

            return lists.ViewDeposited();
        }
    }
}