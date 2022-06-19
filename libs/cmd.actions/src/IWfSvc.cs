//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfSvc
    {
        void Babble<T>(T content);

        void Babble(string pattern, params object[] args);

        void Status<T>(T content, FlairKind flair = FlairKind.Status);

        void Status(ReadOnlySpan<char> src, FlairKind flair = FlairKind.Status);

        void Status(FlairKind flair, string pattern, params object[] args);

        void Status(string pattern, params object[] args);

        void Warn<T>(T content);

        void Warn(string pattern, params object[] args);

        void Error<T>(T content);

        void Write<T>(T content);

        void Write<T>(T content, FlairKind flair);

        void Write(string content, FlairKind flair);

        void Write<T>(string name, T value, FlairKind flair);

        void Write<T>(string name, T value);

        WfExecFlow<T> Running<T>(T msg);

        WfExecFlow<string> Running([CallerName] string msg = null);

        ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null);

        ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran);

        WfFileWritten EmittingFile(FS.FilePath dst);

        ExecToken EmittedFile(WfFileWritten flow, Count count);

        WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct;

        ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct;


        void TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct;

        void FileEmit<T>(T src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        void FileEmit<T>(T src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        void FileEmit<T>(T src, string msg, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken FileEmit<T>(ReadOnlySpan<T> lines, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci);

        ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct;

        ExecToken TableEmit<T>(Index<T> rows, FS.FilePath dst,
                    TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                        where T : struct;

        ExecToken TableEmit<T>(T[] rows, FS.FilePath dst,
            TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct;
    }
}