//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataEmitter
    {
        public RegIdentifiers EmitRegIdentifiers()
        {
            var src = DataProvider.DiscoverRegIdentifiers();
            var values = src.Values;
            var items = values.Select(x => new LlvmListItem(x.Id, x.RegName.Format())).ToArray();
            var dst = LlvmPaths.Table("llvm.asm.RegId");
            var list = new LlvmList(dst,items);
            EmitList(list, dst);
            return src;
        }
    }
}