//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;

    partial class LlvmDataProvider
    {
        public Index<TextLine> SelectX86SourceRecords()
            => SelectSourceRecords(Datasets.X86);

        public Index<TextLine> SelectSourceRecords(string id)
        {
            return (Index<TextLine>)DataSets.GetOrAdd(nameof(SelectSourceRecords), key => Load());

            Index<TextLine> Load()
            {
                using var reader = LlvmPaths.DataSourcePath(id).Utf8LineReader();
                return reader.ReadAll().ToArray();
            }
        }
    }
}