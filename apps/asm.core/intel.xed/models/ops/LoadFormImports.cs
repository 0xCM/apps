//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static XedModels;

    partial class IntelXed
    {
        public ReadOnlySpan<FormImport> LoadFormImports()
        {
            return Data(nameof(LoadFormImports), Load);

            Index<FormImport> Load()
            {
                var src = XedPaths.FormCatalogPath();
                var counter = 0u;
                var outcome = Outcome.Success;
                var dst = list<FormImport>();
                using var reader = src.AsciReader();
                reader.ReadLine();
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine(counter);
                    if(line.StartsWith(CommentMarker) || line.IsEmpty)
                        continue;

                    outcome = XedParsers.parse(line.Content, out FormImport row);
                    if(outcome)
                        dst.Add(row);
                    else
                    {
                        Warn(outcome.Message.Replace("{", "{{").Replace("}","}}"));
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