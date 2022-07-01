//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfMsg : IService, IDisposable
    {
        IWfRuntime Wf {get;}

        EventId Raise<E>(in E e)
            where E : IWfEvent
                => Wf.Raise(e);

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

        void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Wf.Error(HostType, core.require(content), caller, file, line);

        void Write<T>(T content)
            => Wf.Data(HostType, content);

        void Write<T>(T content, FlairKind flair)
            => Wf.Data(HostType, content, flair);

        void Write(string content, FlairKind flair)
            => Wf.Data(HostType, content, flair);

        void Write<T>(string name, T value)
            => Wf.Data(HostType, RP.attrib(name, value));

        void Write<T>(string name, T value, FlairKind flair)
            => Wf.Data(HostType, RP.attrib(name, value), flair);

        void Row<T>(T content)
            => Wf.Row(content);

        void Row<T>(T content, FlairKind flair)
            => Wf.Row(content, flair);

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

        ExecToken Ran<T,D>(WfExecFlow<T> src, D data, FlairKind flair = FlairKind.Ran)
            => Wf.Ran(src, data, flair);

        WfFileWritten EmittingFile(FS.FilePath dst)
            => Wf.EmittingFile(HostType, dst);

        ExecToken EmittedFile(WfFileWritten flow, Count count)
            => Wf.EmittedFile(HostType, flow, count);

        WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => Wf.EmittingTable<T>(HostType, dst);

        ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => Wf.EmittedTable(HostType, flow,count, dst);
    }
}