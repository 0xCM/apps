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

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;

    [WfService]
    public abstract class AppService<H> : IAppService<H>
        where H : AppService<H>, new()
    {
        /// <summary>
        /// Instantites the serice without initialization
        /// </summary>
        [MethodImpl(Inline)]
        protected static H @new() => new H();

        /// <summary>
        /// Creates and initializes the service
        /// </summary>
        /// <param name="wf">The source workflow</param>
        public static H create(IWfRuntime wf)
        {
            var service = @new();
            service.Init(wf);
            return service;
        }

        public IWfRuntime Wf {get; private set;}

        protected WfHost Host {get; private set;}

        public IWfDb Db {get; private set;}

        ITextBuffer _TextBuffer;

        public EnvData Env => Wf.Env;

        protected IEnvPaths Paths => Wf.EnvPaths;

        public virtual Type ContractType
            => typeof(H);

        public Identifier HostName {get;}

        protected DevWs Ws;

        public void Init(IWfRuntime wf)
        {
            var flow = wf.Creating(typeof(H).Name);
            Host = new WfSelfHost(typeof(H));
            Wf = wf;
            Db = new WfDb(wf, wf.Env.Db);
            Ws = DevWs.create(wf.Env.DevWs);
            OnInit();
            Initialized();
            wf.Created(flow);
        }

        protected AppService()
        {
            HostName = GetType().Name;
            _TextBuffer = TextTools.buffer();
        }

        protected string Worker([Caller] string name = null)
            => string.Format("{0,-14}",string.Format("worker({0}) >>", name));

        protected AppService(IWfRuntime wf)
            : this()
        {
            Host = new WfSelfHost(HostName);
            Wf = wf;
        }

        protected void RedirectEmissions(string name, FS.FolderPath dst)
            => Wf.RedirectEmissions(WfEmissionLog.create(name, dst));

        FS.FileName NameShowLog(string src, FS.FileExt ext)
            => FS.file(core.controller().Id().PartName() + "." + HostName + "." + src, ext);

        ShowLog ShowLog(FS.FileName file)
            => new ShowLog(Wf, Db.ShowLog(file));

        protected ShowLog ShowLog(FS.FileExt ext, [Caller] string name = null)
            => ShowLog(NameShowLog(name,ext));

        protected ShowLog ShowLog([Caller] string name = null, FS.FileExt? ext = null)
            => ShowLog(NameShowLog(name,ext ?? FS.Csv));


        protected bool Check<T>(Outcome<T> outcome, out T payload)
        {
            if(outcome.Fail)
            {
                Error(outcome.Message);
                payload = default;
                return false;
            }
            else
            {
                payload = outcome.Data;
                return true;
            }
        }

        protected void Babble<T>(T content)
            => Wf.Babble(content);

        protected void Babble(string pattern, params object[] args)
            => Wf.Babble(string.Format(pattern,args));

        protected void Status<T>(T content)
            => Wf.Status(content);

        protected void Status(ReadOnlySpan<char> src)
            => Wf.Status(new string(src));

        protected void Status(string pattern, params object[] args)
            => Wf.Status(string.Format(pattern, args));

        protected void Warn<T>(T content)
            => Wf.Warn(content);

        protected void Warn(string pattern, params object[] args)
            => Wf.Warn(string.Format(pattern,args));

        protected void Write<T>(T content)
            => Wf.Row(content, null);

        protected void Write<T>(T content, FlairKind flair)
            => Wf.Row(content,flair);

        protected void Write<T>(string name, T value, FlairKind? flair = null)
            => Wf.Row(RP.attrib(name, value), flair);

        protected void Write<T>(ReadOnlySpan<T> src, FlairKind? flair = null)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Write(skip(src,i), flair ?? FlairKind.Data);
        }

        protected void Write<T>(Span<T> src, FlairKind? flair = null)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Write(skip(src,i), flair ?? FlairKind.Data);
        }

        protected virtual void Error<T>(T content)
            => Wf.Error(content);

        protected WfExecFlow<T> Running<T>(T msg, [Caller] string operation = null)
            where T : IMsgPattern
                => Wf.Running(msg, string.Format("{0,-16} | {1}", HostName, operation));

        protected WfExecFlow<string> Running([Caller] string msg = null)
            => Wf.Running(string.Format("{0} | {1,-16}", HostName, msg));

        protected ExecToken Ran<T>(WfExecFlow<T> flow, [Caller] string msg = null)
                => Wf.Ran(flow.WithMsg(string.Format("{0,-16} | {1}", HostName, msg)));

        protected ExecToken Ran<T,D>(WfExecFlow<T> flow, D data, [Caller] string operation = null)
            where T : IMsgPattern
                => Wf.Ran(flow.WithMsg(string.Format("{0} | {1,-16} | {2}", data, HostName, operation)));

        protected WfFileFlow EmittingFile(FS.FilePath dst)
            => Wf.EmittingFile(dst);

        public ExecToken EmittedFile(WfFileFlow flow, Count count)
            => Wf.EmittedFile(flow,count);

        protected void EmittedFile(WfFileFlow file, Count count, Arrow<FS.FileUri> flow)
        {
            Wf.EmittedFile(file,count);
            Write(string.Format("flow[{0}]", flow));
        }

        protected WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => Wf.EmittingTable<T>(dst);

        protected ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => Wf.EmittedTable(flow,count, dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, FS.FilePath dst)
            where T : struct
                => Wf.TableEmit(src,dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst)
            where T : struct
                => Wf.TableEmit(src, widths, dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
                => Wf.TableEmit(src, widths, encoding, dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, StreamWriter writer, FS.FilePath dst)
            where T : struct
                => Wf.TableEmit(src, widths, writer, dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, Encoding encoding, FS.FilePath dst)
            where T : struct
                => Wf.TableEmit(src, widths, rowpad,  encoding, dst);

        protected Outcome<uint> EmitLines(ReadOnlySpan<TextLine> src, FS.FilePath dst, TextEncodingKind encoding)
            => Wf.EmitLines(src,dst,encoding);


        protected virtual void OnInit()
        {

        }

        protected virtual void Initialized()
        {

        }

        protected virtual void Disposing() { }

        public void Dispose()
        {
            Disposing();
            Wf.Disposed();
        }
    }
}