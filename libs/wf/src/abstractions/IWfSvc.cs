//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfSvc : IAppService
    {
        void Babble<T>(T content);

        void Babble(string pattern, params object[] args);

        ExecToken EmittedBytes(WfFileWritten flow, ByteSize size);

        ExecToken EmittedFile(WfFileWritten flow, Count count);

        ExecToken EmittedFile(WfFileWritten flow, int count);

        ExecToken EmittedFile(WfFileWritten flow, uint count);

        ExecToken EmittedFile<T>(WfFileWritten flow, T msg);

        ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct;

        WfFileWritten EmittingFile(FS.FilePath dst);

        WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct;

        void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null);

        void FileEmit<T>(T src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        void FileEmit<T>(T src, FS.FilePath dst, ByteSize size, TextEncodingKind encoding = TextEncodingKind.Asci);

        void FileEmit<T>(T src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        void FileEmit<T>(T src, string msg, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        void FileEmit<T>(ReadOnlySpan<T> lines, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        Outcome LoadProject(CmdArgs args);

        IWsProject Project();

        ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null);

        ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran);

        ExecToken Ran<T, D>(WfExecFlow<T> src, D data);

        void Row<T>(T content);

        void Row<T>(T content, FlairKind flair);

        WfExecFlow<T> Running<T>(T msg);

        WfExecFlow<string> Running([CallerName] string msg = null);

        void Status<T>(T content, FlairKind flair = FlairKind.Status);

        void Status(ReadOnlySpan<char> src, FlairKind flair = FlairKind.Status);

        void Status(FlairKind flair, string pattern, params object[] args);

        void Status(string pattern, params object[] args);

        void TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci) where T : struct;

        void TableEmit<T>(ReadOnlySpan<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        void TableEmit<T>(Index<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        void TableEmit<T>(T[] rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular) where T : struct;

        void TableEmit<T>(ReadOnlySeq<T> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci) where T : struct;

        void TableEmit<T>(Seq<T> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci) where T : struct;

        void Warn<T>(T content);

        void Warn(string pattern, params object[] args);

        void Write<T>(T content);

        void Write<T>(T content, FlairKind flair);

        void Write(string content, FlairKind flair);

        void Write<T>(string name, T value, FlairKind flair);

        void Write<T>(string name, T value);
    }
}