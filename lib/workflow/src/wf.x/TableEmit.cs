//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;
    using System.Text;

    using static Root;
    using static core;

    partial class XTend
    {
        public static uint TableEmit<T>(this IWfRuntime Wf, ReadOnlySpan<T> src, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(dst);
            var spec = Tables.rowspec<T>();
            var count = Tables.emit(src, spec, dst);
            Wf.EmittedTable(flow,count);
            return count;
        }

        public static uint TableEmit<T>(this IWfRuntime Wf, ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, dst);
            Wf.EmittedTable(flow,count);
            return count;
        }

        public static uint TableEmit<T>(this IWfRuntime Wf, ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, encoding, dst);
            Wf.EmittedTable(flow,count);
            return count;
        }

        public static uint TableEmit<T>(this IWfRuntime Wf, ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, StreamWriter writer, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, writer);
            Wf.EmittedTable(flow,count);
            return count;
        }

        public static uint TableEmit<T>(this IWfRuntime Wf, ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, Encoding encoding, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(dst);
            var spec = Tables.rowspec<T>(widths, rowpad);
            var count = Tables.emit(src, spec, encoding, dst);
            Wf.EmittedTable(flow, count);
            return count;
        }

        public static Outcome<uint> EmitLines(this IWfRuntime Wf, ReadOnlySpan<TextLine> src, FS.FilePath dst, TextEncodingKind encoding)
        {
            using var writer = dst.Writer(encoding);
            var count = (uint)src.Length;
            var emitting = Wf.EmittingFile(dst);
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(src,i));
            Wf.EmittedFile(emitting,count);
            return count;
        }
    }
}