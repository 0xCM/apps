//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WfEmit
    {
        public IWfRuntime Wf {get;}

        readonly Type HostType;

        readonly IWfEventTarget EventLog;

        public WfEmit(IWfRuntime wf, Type host)
        {
            Wf = wf;
            HostType = host;
            EventLog = wf.EventLog;
        }

        public WfEmit(IWfSvc svc)
        {
            Wf = svc.Wf;
            HostType = svc.HostType;
            EventLog = svc.Wf.EventLog;
        }

        public void Dispose()
        {

        }

        public void Babble<T>(T content)
            => Wf.Babble(HostType, content);

        public void Babble(string pattern, params object[] args)
            => Wf.Babble(HostType, string.Format(pattern,args));

        public void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => Wf.Status(HostType, content, flair);

        public void Status(ReadOnlySpan<char> src, FlairKind flair = FlairKind.Status)
            => Wf.Status(HostType, new string(src), flair);

        public void Status(FlairKind flair, string pattern, params object[] args)
            => Wf.Status(HostType, string.Format(pattern, args));

        public void Status(string pattern, params object[] args)
            => Wf.Status(HostType, string.Format(pattern, args));

        public void Warn<T>(T content)
            => Wf.Warn(HostType, content);

        public void Warn(string pattern, params object[] args)
            => Wf.Warn(HostType, string.Format(pattern, args));

        public void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Wf.Error(HostType, core.require(content), caller, file, line);

        public void Write<T>(T content)
            => Wf.Data(HostType, content);

        public void Write<T>(T content, FlairKind flair)
            => Wf.Data(HostType, content, flair);

        public void Row<T>(T content)
            => Wf.Row(content);

        public void Row<T>(T content, FlairKind flair)
            => Wf.Row(content, flair);

        public void Write(string content, FlairKind flair)
            => Wf.Data(HostType, content, flair);

        public void Write<T>(string name, T value, FlairKind flair)
            => Wf.Data(HostType, RpOps.attrib(name, value), flair);

        public void Write<T>(string name, T value)
            => Wf.Data(HostType, RpOps.attrib(name, value));

        public ExecToken Completed<T>(WfExecFlow<T> flow, Type host, Exception e, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine]int? line = null)
            => Wf.Completed(flow,host,e, caller, file, line);

        public ExecToken Completed<T>(WfExecFlow<T> flow, Type host, Exception e, EventOrigin origin)
            => Wf.Completed(flow,host,e, origin);

        public WfExecFlow<T> Running<T>(T msg)
            => Wf.Running(HostType, msg);

        public WfExecFlow<string> Running([CallerName] string msg = null)
            => Wf.Running(HostType, msg);

        public ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => Wf.Ran(HostType, flow.WithMsg(msg));

        public ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
            => Wf.Ran(HostType, flow.WithMsg(msg), flair);

        public ExecToken Ran<T,D>(WfExecFlow<T> src, D data, FlairKind flair = FlairKind.Ran)
            => Wf.Ran(src, data, flair);

        public FileWritten EmittingFile(FS.FilePath dst)
            => Wf.EmittingFile(HostType, dst);

        public ExecToken EmittedFile(FileWritten flow, Count count)
            => Wf.EmittedFile(HostType, flow, count);

        public ExecToken EmittedFile(FileWritten flow, int count)
            => Wf.EmittedFile(HostType, flow, count);

        public ExecToken EmittedFile(FileWritten flow, uint count)
            => Wf.EmittedFile(HostType, flow, count);

        public ExecToken EmittedFile<T>(FileWritten flow, T msg)
            => Wf.EmittedFile(flow, msg);

        public ExecToken EmittedBytes(FileWritten flow, ByteSize size)
            => EmittedFile(flow, AppMsg.EmittedBytes.Capture(size, flow.Target));

        public WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => Wf.EmittingTable<T>(HostType, dst);

        public ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => Wf.EmittedTable(HostType, flow,count, dst);

        public ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, 
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
        {
            var emitting = EmittingTable<T>(dst);            
            Tables.emit(rows, dst, encoding, rowpad, fk);
            return EmittedTable(emitting, rows.Length);
        }

        public ExecToken TableEmit<T>(Index<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, 
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
                    => TableEmit(rows.View, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(T[] rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, 
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
                    => TableEmit(@readonly(rows), dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(ReadOnlySeq<T> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, 
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
                    => TableEmit(src.View, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(Seq<T> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, 
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
                    => TableEmit(src.View, dst, encoding, rowpad, fk);

         public ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FS.FilePath dst, TextEncodingKind encoding)
            where T : struct
        {
            var emitting = EmittingTable<T>(dst);
            var formatter = RecordFormatters.create(typeof(T));
            using var writer = dst.Emitter(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
            return EmittedTable(emitting, rows.Length, dst);
        }

        public ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
        {
            var flow = Wf.EmittingTable<T>(HostType, dst);
            var spec = Tables.rowspec<T>(widths, z16);
            var count = Tables.emit(src, spec, encoding, dst);
            return Wf.EmittedTable(HostType, flow,count);
        }

        public ExecToken FileEmit<T>(T src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            return EmittedFile(emitting, count);
        }

        public ExecToken FileEmit<T>(T src, FS.FilePath dst, ByteSize size, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            return EmittedFile(emitting, size);
        }

        public ExecToken FileEmit<T>(T src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            return EmittedFile(emitting, 0);
        }

        public ExecToken FileEmit<T>(T src, string msg, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            Write(string.Format("{0,-12} | {1}", "Emitting", dst.ToUri()), FlairKind.Running);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            Write(string.Format("{0,-12} | {1}", "Emitted", dst.ToUri()), FlairKind.Ran);
            Write(string.Format("{0,-12} | {1}", "Description", msg), FlairKind.Ran);
            return EmittedFile(emitting, 0);
        }

        public ExecToken FileEmit<T>(ReadOnlySpan<T> lines, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer(encoding);
            var count = lines.Length;
            for (var i = 0; i < count; i++)
                writer.AppendLine(skip(lines, i));
            return EmittedFile(emitting, count);
        }

        public ExecToken FileEmit(string src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Utf8)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(src);
            return EmittedFile(emitting, count);
        }
    }
}