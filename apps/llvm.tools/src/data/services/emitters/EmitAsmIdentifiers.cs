//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmDataEmitter
    {
        public LlvmList EmitAsmIdentifiers()
        {
            var values = DataProvider.DiscoverAsmIdentifiers().Values;
            var items = values.Select(x => new LlvmListItem(x.Id, x.InstName.Format())).ToArray();
            var dst = LlvmPaths.Table("llvm.asm.AsmId");
            var list = new LlvmList(dst, items);
            EmitList(list, dst);
            return list;
        }
    }
}