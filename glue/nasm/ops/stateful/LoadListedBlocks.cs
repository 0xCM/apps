//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using static core;

    partial class Nasm
    {
        public Index<NasmCodeBlock> LoadListedBlocks(FS.FilePath path)
        {
            if(!path.Exists)
            {
                Wf.Error(FS.Msg.DoesNotExist.Format(path));
                return Index<NasmCodeBlock>.Empty;
            }

            var flow = Wf.Running(string.Format("Listing blocks from {0}", path.ToUri()));
            var listing = ReadListing(path);
            var buffer = alloc<NasmListEntry>(listing.LineCount);
            var count = ParseListing(listing, buffer);
            var output = slice(span(buffer), 0, count);
            var blocks = list<LabeledBlocks>();
            var collector = new LabeledBlocks(NasmLabel.Empty, new());
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(output,i);
                var kind = Nasm.kind(entry);
                if(kind == NasmListLineKind.Label)
                {
                    var label = new NasmLabel(entry.LineNumber, entry.Label);
                    if(collector.IsNonEmpty)
                        blocks.Add(collector);
                    collector = new LabeledBlocks(label, new());

                }
                else if(kind == NasmListLineKind.Encoding)
                {
                    var encoding = new NasmEncoding();
                    encoding.Encoded = entry.Encoding;
                    encoding.LineNumber = entry.LineNumber;
                    encoding.Offset  = entry.Offset;
                    encoding.SourceText = entry.SourceText;
                    collector.Code.Add(encoding);
                }
            }
            if(collector.IsNonEmpty)
                blocks.Add(collector);
            var results = blocks.Map(x => x.ToBlock());
            Wf.Ran(flow, string.Format("Constructed {0} blocks from {1}", results.Length, path.ToUri()));
            return results;
        }
    }
}