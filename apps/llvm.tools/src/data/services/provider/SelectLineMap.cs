//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public LineMap<Identifier> SelectLineMap(FS.FilePath src)
            => (LineMap<Identifier>)DataSets.GetOrAdd(src.Format(), _ => DataLoader.LoadLineMap(src));
    }
}