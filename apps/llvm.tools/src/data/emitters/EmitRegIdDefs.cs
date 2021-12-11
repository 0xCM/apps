//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataEmitter
    {
        public LlvmList EmitRegIdDefs()
        {
            var values = DataProvider.DiscoverRegIdDefs().Values;
            var items = values.Select(x => new LlvmListItem(x.Id, x.InstName)).ToArray();
            var dst = LlvmPaths.Table("llvm.asm.RegId");
            var list = new LlvmList(dst,items);
            EmitList(list, dst);
            return list;
        }
    }
}