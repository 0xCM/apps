//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmDataLoader
    {
        public Index<TextLine> LoadSourceRecords(string id)
        {
            return (Index<TextLine>)DataSets.GetOrAdd(nameof(LoadSourceRecords), key => Load());

            Index<TextLine> Load()
            {
                using var reader = LlvmPaths.DataSourcePath(id).Utf8LineReader();
                return reader.ReadAll().ToArray();
            }
        }
    }
}