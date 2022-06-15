//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfMsg : IService, IDisposable
    {
        IWfRuntime Wf {get;}

        void Babble<T>(T content)
            => Wf.Babble(HostType, content);

        void Babble(string pattern, params object[] args)
            => Wf.Babble(HostType, string.Format(pattern,args));

        void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => Wf.Status(HostType, content, flair);

        void Status(ReadOnlySpan<char> src, FlairKind flair = FlairKind.Status)
            => Wf.Status(HostType, new string(src), flair);

        void Status(string pattern, params object[] args)
            => Wf.Status(HostType, string.Format(pattern, args));

        void Status(string pattern, FlairKind flair, params object[] args)
            => Wf.Status(HostType, string.Format(pattern, args), flair);

        void Warn<T>(T content)
            => Wf.Warn(HostType, content);

        void Warn(string pattern, params object[] args)
            => Wf.Warn(HostType, string.Format(pattern,args));

        void Error<T>(T content)
            => Wf.Error(HostType, core.require(content));

        void Write<T>(T content)
            => Wf.Row(HostType, content, null);

        void Write<T>(T content, FlairKind flair)
            => Wf.Row(HostType, content, flair);

        void Write<T>(string name, T value, FlairKind? flair = null)
            => Wf.Row(HostType, RP.attrib(name, value), flair);

        WfExecFlow<Type> Creating(Type host)
            => Wf.Creating(host);

        ExecToken Created(WfExecFlow<Type> flow)
            => Wf.Created(flow);

        WfExecFlow<T> Running<T>(T msg)
            => Wf.Running(HostType, msg);

        WfExecFlow<string> Running([CallerName] string msg = null)
            => Wf.Running(HostType, msg);

        ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => Wf.Ran(HostType, flow.WithMsg(msg));

        ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
            => Wf.Ran(HostType, flow.WithMsg(msg), flair);

        WfFileWritten EmittingFile(FS.FilePath dst)
            => Wf.EmittingFile(HostType, dst);

        ExecToken EmittedFile(WfFileWritten flow, Count count)
            => Wf.EmittedFile(HostType, flow, count);

        void EmittedFile(WfFileWritten file, Count count, Arrow<FS.FileUri> flow)
            => Wf.EmittedFile(HostType, file,count);

        WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => Wf.EmittingTable<T>(HostType, dst);

        ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => Wf.EmittedTable(HostType, flow,count, dst);
    }
}