//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataLoader
    {
        public Index<LlvmList> LoadLists()
            => LlvmPaths.ListNames().Map(LoadList);

        public LlvmList LoadList(string id)
        {
            return (LlvmList)DataSets.GetOrAdd("llvm.lists." + id, key => Load());

            LlvmList Load()
            {
                id = text.begins(id, "llvm.lists.") ? id : "llvm.lists." + id;
                var dst = list<LlvmListItem>();
                var path = LlvmPaths.ListImportPath(id);
                using var reader = path.Utf8LineReader();
                var counter = 0u;
                while(reader.Next(out var line))
                {
                    if(counter++ == 0)
                        continue;
                    else
                    {
                        var parts = line.Content.SplitClean(Chars.Pipe);
                        if(parts.Length != 2)
                        {
                            Wf.Error(Tables.FieldCountMismatch.Format(parts.Length, 2));
                            break;
                        }
                        DataParser.parse(skip(parts,0), out uint key);
                        dst.Add((key, skip(parts,1)));
                    }
                }
                return (path, dst.ToArray());
            }
        }
    }
}