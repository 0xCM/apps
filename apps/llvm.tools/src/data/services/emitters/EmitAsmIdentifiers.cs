//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataEmitter
    {
        public AsmIdentifiers EmitAsmIdentifiers()
        {
            var src = DataProvider.DiscoverAsmIdentifiers();
            var values = src.Values;
            var items = values.Select(x => new LlvmListItem(x.Id, x.InstName.Format())).ToArray();
            var dst = LlvmPaths.Table("llvm.asm.AsmId");
            EmitList(new LlvmList(dst, items), dst);
            return src;
        }
    }
}