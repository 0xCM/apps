//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    public interface IWfTableOps : IWfMessaging
    {
        uint TableEmit<T>(ReadOnlySpan<T> src, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(HostType,dst);
            var spec = Tables.rowspec<T>();
            var count = Tables.emit(src, spec, dst);
            Wf.EmittedTable(HostType,flow,count);
            return count;
        }

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