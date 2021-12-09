//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public LlvmList SelectList(string id)
        {
            return (LlvmList)DataSets.GetOrAdd("llvm.lists." + id, key => Load());

            LlvmList Load()
            {
                //id = text.remove(id, "llvm.lists.");
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