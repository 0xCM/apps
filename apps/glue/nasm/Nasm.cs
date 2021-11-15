//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    [ApiHost]
    public sealed partial class Nasm : ToolService<Nasm>
    {
        readonly BitFormatter<byte> BitFormat;

        public Nasm()
            : base(Toolspace.nasm)
        {
            BitFormat = BitRender.formatter<byte>(4);
        }

        public static MsgPattern<Count> ParsingNasmListEntries => "Parsing list entries from {0} lines";

        public static MsgPattern<Count> ParsedNasmListEntries => "Parsing {0} list entries";

        public static MsgPattern<FS.FileUri> ReadingNasmListing => "Reading nasm listing from {0}";

        public static MsgPattern<Count,FS.FileUri> ReadNasmListing => "Read {0} nasm list lines from {1}";
   }
}