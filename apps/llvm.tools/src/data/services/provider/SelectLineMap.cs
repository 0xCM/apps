//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataProvider
    {
        public LineMap<Identifier> SelectLineMap(FS.FilePath src)
        {
            return (LineMap<Identifier>)DataSets.GetOrAdd(src.Format(), key => TableLoader.LoadLineMap(src));
        }
    }
}