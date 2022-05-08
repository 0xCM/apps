//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class AppServices : AppService<AppServices>
    {

        // public new IWfMessaging WfMsg
        // {
        //     [MethodImpl(Inline)]
        //     get => WfMsg;
        // }

        // public new IWfTableOps TableOps
        // {
        //     [MethodImpl(Inline)]
        //     get => TableOps;
        // }

        public new void Babble<T>(T content)
            => WfMsg.Babble(content);

        protected new void Babble(string pattern, params object[] args)
            => WfMsg.Babble(pattern, args);

        protected new void Status<T>(T content)
            => WfMsg.Status(content);

        public new void Status(ReadOnlySpan<char> src)
            => WfMsg.Status(src);

        public new void Status(string pattern, params object[] args)
            => WfMsg.Status(pattern, args);

        public new void Warn<T>(T content)
            => WfMsg.Warn(content);

        public new void Warn(string pattern, params object[] args)
            => WfMsg.Warn(pattern, args);

        public new void Error<T>(T content)
            => WfMsg.Error(content);

        public new void Write<T>(T content)
            => WfMsg.Write(content);

        public new void Write<T>(T content, FlairKind flair)
            => WfMsg.Write(content, flair);

        public new void Write<T>(string name, T value, FlairKind? flair = null)
            => WfMsg.Write(name, value, flair);

        public new WfExecFlow<T> Running<T>(T msg)
            => WfMsg.Running(msg);

        public new WfExecFlow<string> Running([CallerName] string msg = null)
            => WfMsg.Running(msg);

        public new ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => WfMsg.Ran(flow,msg);

        public new ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
            => WfMsg.Ran(flow, msg, flair);

        public new WfFileWritten EmittingFile(FS.FilePath dst)
            => WfMsg.EmittingFile(dst);

        public new ExecToken EmittedFile(WfFileWritten flow, Count count)
            => WfMsg.EmittedFile(flow,count);

        public new WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => WfMsg.EmittingTable<T>(dst);

        public new ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => WfMsg.EmittedTable(flow,count, dst);

        public void TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableOps.TableEmit(src, widths, encoding, dst);

        public void FileEmit<T>(T src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => TableOps.FileEmit(src.ToString(), count, dst, encoding);

        public void TableEmit<T>(ReadOnlySpan<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
        {
            var emitting = EmittingTable<T>(dst);
            var formatter = RecordFormatter.create(typeof(T));
            using var emitter = dst.Emitter(encoding);
            emitter.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                emitter.WriteLine(formatter.Format(skip(rows,i)));
            EmittedTable(emitting, rows.Length, dst);
        }

        public void TableEmit<T>(Index<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(rows.View, dst, encoding);

        public void TableEmit<T>(T[] rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(@readonly(rows), dst, encoding);

        public void TableEmit<T>(Span<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(@readonly(rows), dst, encoding);
    }
}