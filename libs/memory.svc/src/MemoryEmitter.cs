//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    public sealed class MemoryEmitter : WfSvc<MemoryEmitter>, IMemoryEmitter
    {
        const byte Bpl = 40;

        public static void emit(MemoryRange src, StreamWriter dst, byte bpl)
            => HexDataFormatter.create(src.Min, bpl).FormatLines(cover<byte>(src.Min, src.Size), line => dst.WriteLine(line));

        public static void emit(MemoryRange src, FS.FilePath dst, byte bpl)
        {
            using var writer = dst.Writer();
            emit(src, writer, bpl);
        }

        public static void emit(MemoryAddress @base, ByteSize size, FS.FilePath dst, byte bpl = Bpl)
            => emit((@base,  @base + size), dst, bpl);

        [Op]
        public unsafe static uint emit(MemorySeg src, uint bpl, FS.FilePath dst)
        {
            var line = text.emitter();
            using var writer = dst.Writer();
            var pSrc = src.BaseAddress.Pointer<byte>();
            var last =  src.LastAddress.Pointer<byte>();
            var current = MemoryAddress.Zero;
            var offset = 1;
            var restart = true;

            while(pSrc++ <= last)
            {
                current = (MemoryAddress)pSrc;

                if(restart)
                {
                    line.Append(string.Format("0x{0} ", current.Format()));
                    restart = false;
                }

                line.Append(string.Format("{0} ", HexFormatter.format<W8,byte>(*pSrc)));

                if(offset % bpl == 0)
                {
                    writer.WriteLine(line.Emit());
                    restart = true;
                }

                offset++;
            }
            writer.WriteLine(line.Emit());
            return (uint)offset;
        }

        public unsafe uint Emit(MemorySeg src, uint bpl, FS.FilePath dst)
        {
            var flow = Wf.EmittingFile(dst);
            var size = emit(src, bpl, dst);
            Wf.EmittedFile(flow,size);
            return size;
        }

        public void DumpImages(FS.FolderPath src, FS.FolderPath dst, bool pll = true)
        {
            var files = src.Files(FS.Dll);
            iter(files, file => DumpImage(file,dst), pll);
        }

        public void DumpImage(FS.FilePath src, FS.FolderPath dst)
        {
            using var file = MemoryFiles.map(src);
            var target = dst + FS.file(file.Path.FileName.Name, FS.Hex);
            var flow = Wf.EmittingFile(target);
            Emit(file.BaseAddress, file.Size, target);
            EmittedFile(flow, (uint)file.Size);
        }

        public void Emit(MemoryRange src, StreamWriter dst, byte bpl = Bpl)
            => emit(src, dst, bpl);

        public void Emit(MemoryRange src, FS.FilePath dst, byte bpl = Bpl)
            => emit(src, dst, bpl);

        public void Emit(MemoryAddress @base, ByteSize size, FS.FilePath dst, byte bpl = Bpl)
            => emit((@base,  @base + size), dst, bpl);

        public unsafe void EmitPaged(MemoryRange src, StreamWriter dst, byte bpl = Bpl)
        {
            memory.liberate(src);
            var buffer = span<byte>(PageSize);
            var pages = (uint)(src.Size/PageSize);
            var reader = MemoryReader.create<byte>(src);
            var offset = 0ul;
            var @base = src.Min;

            Status($"Length = {src.Size} | Pages={pages} | Base={src.Min} | End = {src.Max}");

            var formatter = HexDataFormatter.create(src.Min, bpl);
            dst.WriteLine(text.concat($"Address".PadRight(12), RpOps.SpacedPipe, "Data"));
            for(var i=0; i<pages; i++)
            {
                var size = reader.Read((int)offset, PageSize, buffer);
                Babble($"Read {size} bytes");
                var content = slice(buffer, size);
                var lines = formatter.FormatLines(content);
                var kLines = lines.Length;
                for(var j =0; j<kLines; j++)
                    dst.WriteLine(skip(lines,j));

                offset += PageSize;

                if(size < PageSize || offset >= src.Size)
                    break;
            }
        }

        public void EmitPaged(MemoryRange src, FS.FilePath dst, byte bpl = Bpl)
        {
            using var writer = dst.Writer();
            EmitPaged(src, writer, bpl);
        }

        public void EmitPaged(MemoryAddress @base, ByteSize size, FS.FilePath dst, byte bpl = Bpl)
            => EmitPaged((@base,  @base + size), dst, bpl);
    }
}