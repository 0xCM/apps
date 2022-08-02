//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial class CliEmitter
    {
        public void EmitImageContent(IApiPack dst)
        {
            var flow = Running();
            iter(ApiMd.Assemblies, c => EmitImageContent(c,dst));
            Ran(flow);
        }

        [Op]
        public MemoryRange EmitImageContent(Assembly src, IApiPack pack, byte bpl = HexCsvRow.BPL)
        {
            var dst =  pack.Metadata("image.content").PrefixedTable<HexCsvRow>(src.GetSimpleName());
            var flow = EmittingTable<HexCsvRow>(dst);
            var @base = ImageMemory.@base(src);
            var formatter = HexDataFormatter.create(@base, bpl);
            var path = FS.path(src.Location);
            using var stream = path.Utf8Reader();
            using var reader = stream.BinaryReader();
            using var writer = dst.Writer();
            writer.WriteLine(string.Concat($"Address".PadRight(16), RpOps.SpacedPipe, "Data"));
            var buffer = sys.alloc<byte>(bpl);
            var k = Read(reader, buffer);
            var offset = MemoryAddress.Zero;
            var lines = 0;
            while(k != 0)
            {
                writer.WriteLine(formatter.FormatLine(buffer, offset, Chars.Pipe));

                offset += k;
                lines++;

                buffer.Clear();
                k = Read(reader, buffer);
            }

            EmittedTable(flow, lines);
            return (@base, @base + offset);
        }

        [MethodImpl(Inline), Op]
        uint Read(BinaryReader src, Span<byte> dst)
            => (uint)src.Read(dst);
    }
}