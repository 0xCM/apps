//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    public interface IWfEmitters : IWfMsg
    {
         ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
        {
            var emitting = EmittingTable<T>(dst);
            var formatter = RecordFormatter.create(typeof(T));
            using var writer = dst.Emitter(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
            return EmittedTable(emitting, rows.Length, dst);
        }

        ExecToken TableEmit<T>(Index<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(rows.View, dst, encoding);

        ExecToken TableEmit<T>(T[] rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(@readonly(rows), dst, encoding);

        ExecToken TableEmit<T>(Span<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(@readonly(rows), dst, encoding);

        // uint TableEmit<T>(ReadOnlySpan<T> src, FS.FilePath dst)
        //     where T : struct
        // {
        //     var flow = Wf.EmittingTable<T>(HostType,dst);
        //     var spec = Tables.rowspec<T>();
        //     var count = Tables.emit(src, spec, dst);
        //     Wf.EmittedTable(HostType,flow,count);
        //     return count;
        // }

        uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(HostType, dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, dst);
            Wf.EmittedTable(HostType, flow,count);
            return count;
        }

        uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(HostType, dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, encoding, dst);
            Wf.EmittedTable(HostType, flow,count);
            return count;
        }

        uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, StreamWriter writer, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(HostType, dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, writer);
            Wf.EmittedTable(HostType, flow,count);
            return count;
        }

        uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(HostType, dst);
            var spec = Tables.rowspec<T>(widths, rowpad);
            var count = Tables.emit(src, spec, encoding, dst);
            Wf.EmittedTable(HostType, flow, count);
            return count;
        }

        void FileEmit(string src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Utf8)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(src);
            EmittedFile(emitting, count);
        }
    }
}