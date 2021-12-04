//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;

    partial class LlvmDataLoader
    {
        public Index<TextLine> LoadLinedRecords()
        {
            return (Index<TextLine>)DataSets.GetOrAdd(nameof(LoadLinedRecords), key => Load());

            Index<TextLine> Load()
            {
                using var reader = LlvmPaths.RecordImport(Datasets.X86Lined, FS.Txt).Utf8LineReader();
                return reader.ReadAll().ToArray();
            }
        }
    }
}