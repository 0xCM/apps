//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static Root;
    using static core;

    partial class CliEmitter
    {
        public void ClearImageContent()
        {
            var dir = ImageHexDir;
            var flow = Wf.Running($"Clearing content from <{dir}>");
            var dst = list<FS.FilePath>();
            dir.Clear(dst);
            Wf.Ran(flow, $"Cleared <{dst.Count}> files from <{dir}>");
        }

        FS.FolderPath ImageHexDir => ProjectDb.Subdir(ImageHexScope);

        FS.FilePath ImageHexPath(string id) => ProjectDb.TablePath<HexCsv>(ImageHexScope, id);

        public void EmitImageContent()
        {
            var flow = Running(nameof(EmitImageContent));
            ClearImageContent();
            iter(ApiRuntimeCatalog.Components, c => EmitImageContent(c));
            Ran(flow);
        }


        public void LoadImageContent(FS.FilePath src)
        {
            HexCsvReader.create(Wf).Load(src);
        }

        [Op]
        public MemoryRange EmitImageContent(Assembly src)
        {
            var rowsize = HexCsv.RowDataSize;
            var dst =  ImageHexPath(src.GetSimpleName());
            var flow = EmittingTable<HexCsv>(dst);
            var @base = ImageMemory.@base(src);
            var formatter = HexDataFormatter.create(@base, rowsize);
            var path = FS.path(src.Location);
            using var stream = path.Utf8Reader();
            using var reader = stream.BinaryReader();
            using var writer = dst.Writer();
            writer.WriteLine(string.Concat($"Address".PadRight(12), RP.SpacedPipe, "Data"));
            var buffer = alloc<byte>(rowsize);
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

            EmittedTable<HexCsv>(flow, lines);
            return (@base, @base + offset);
        }

        [MethodImpl(Inline), Op]
        uint Read(BinaryReader src, Span<byte> dst)
            => (uint)src.Read(dst);
    }
}