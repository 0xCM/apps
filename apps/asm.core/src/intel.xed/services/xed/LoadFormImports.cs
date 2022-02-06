//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static XedModels;

    partial class IntelXed
    {
        public ReadOnlySpan<XedFormImport> LoadFormImports()
        {
            return Data(nameof(LoadFormImports), Load);

            Index<XedFormImport> Load()
            {
                var src = XedPaths.FormCatalogPath();
                var counter = 0u;
                var outcome = Outcome.Success;
                var dst = list<XedFormImport>();
                using var reader = src.AsciReader();
                reader.ReadLine();
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine(counter);
                    if(line.StartsWith(CommentMarker) || line.IsEmpty)
                        continue;

                    outcome = XedModels.parse(line, out var row);
                    if(outcome)
                        dst.Add(row);
                    else
                    {
                        Warn(outcome.Message);
                    }

                    counter++;
                }
                if(outcome)
                    return dst.ToArray();
                else
                    return default;
            }
        }
    }
}