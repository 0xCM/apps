//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class PolyBits
    {
        public Index<BfModel> BvCalc(DbSources sources, string filter)
            => bitvectors(sources.Files(FileKind.Csv).Where(f => f.FileName.StartsWith(filter)));
    }
}