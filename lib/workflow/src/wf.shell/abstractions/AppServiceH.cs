//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;
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

        ConcurrentDictionary<Type,object> ServiceCache {get;}
            = new();

        protected T Service<T>(Func<T> factory)
            => (T)ServiceCache.GetOrAdd(typeof(T), key => factory());

        public IWfRuntime Wf {get; private set;}

        protected WfHost Host {get; private set;}

        public IWfDb Db {get; private set;}

        protected IProjectWs ProjectDb;

        ITextBuffer _TextBuffer;

        public EnvData Env => Wf.Env;

        protected IEnvPaths Paths => Wf.EnvPaths;

        public virtual Type ContractType
            => typeof(H);

        public Identifier HostName {get;}

        protected DevWs Ws;

        IAppServiceUtilities Util;

        protected OmniScript OmniScript => Service(Wf.OmniScript);

        public void Init(IWfRuntime wf)
        {
            var flow = wf.Creating(typeof(H).Name);
            Util = AppServiceUtilities.create(wf);
            Host = new WfSelfHost(typeof(H));
            Wf = wf;
            Db = new WfDb(wf, wf.Env.Db);
            Ws = DevWs.create(wf.Env.DevWs);
            ProjectDb = Ws.Project("db");
            OnInit();
            Initialized();
            wf.Created(flow);
        }

        protected AppService()
        {
            HostName = GetType().Name;
            _TextBuffer = text.buffer();
        }

        protected AppService(IWfRuntime wf)
            : this()
        {
            Host = new WfSelfHost(HostName);
            Wf = wf;
        }

        protected string Worker([Caller] string name = null)
            => Util.Worker(name);

        protected void RedirectEmissions(string name, FS.FolderPath dst)
            => Util.RedirectEmissions(name,dst);

        FS.FileName NameShowLog(string src, FS.FileExt ext)
            => FS.file(core.controller().Id().PartName() + "." + HostName + "." + src, ext);

        ShowLog ShowLog(FS.FileName file)
            => new ShowLog(Wf, Db.ShowLog(file));

        protected ShowLog ShowLog(FS.FileExt ext, [Caller] string name = null)
            => ShowLog(NameShowLog(name,ext));

        protected ShowLog ShowLog([Caller] string name = null, FS.FileExt? ext = null)
            => ShowLog(NameShowLog(name,ext ?? FS.Csv));

        protected bool Check<T>(Outcome<T> outcome, out T payload)
            => Util.Check(outcome, out payload);

        protected void Babble<T>(T content)
            => Util.Babble(content);

        protected void Babble(string pattern, params object[] args)
            => Util.Babble(pattern, args);

        protected void Status<T>(T content)
            => Util.Status(content);

        protected void Status(ReadOnlySpan<char> src)
            => Util.Status(src);

        protected void Status(string pattern, params object[] args)
            => Util.Status(pattern, args);

        protected void Warn<T>(T content)
            => Util.Warn(content);

        protected void Warn(string pattern, params object[] args)
            => Util.Warn(pattern, args);

        protected void Write<T>(T content)
            => Util.Write(content);

        protected void Write<T>(T content, FlairKind flair)
            => Util.Write(content, flair);

        protected void Write<T>(string name, T value, FlairKind? flair = null)
            => Util.Write(name, value, flair);

        protected void Write<T>(ReadOnlySpan<T> src, FlairKind? flair = null)
            => Util.Write(src, flair);

        protected void Write<T>(Span<T> src, FlairKind? flair = null)
            => Util.Write(src, flair);

        protected virtual void Error<T>(T content)
            => Util.Error(content);

        protected WfExecFlow<T> Running<T>(T msg, [Caller] string operation = null)
            => Util.Running(msg, operation);

        protected WfExecFlow<string> Running([Caller] string msg = null)
            => Util.Running(msg);

        protected ExecToken Ran<T>(WfExecFlow<T> flow, [Caller] string msg = null)
            => Util.Ran(flow,msg);

        protected ExecToken Ran<T,D>(WfExecFlow<T> flow, D data, [Caller] string operation = null)
            where T : IMsgPattern
            => Util.Ran(flow,data,operation);

        protected WfFileFlow EmittingFile(FS.FilePath dst)
            => Util.EmittingFile(dst);

        public ExecToken EmittedFile(WfFileFlow flow, Count count)
            => Util.EmittedFile(flow,count);

        protected void EmittedFile(WfFileFlow file, Count count, Arrow<FS.FileUri> flow)
            => Util.EmittedFile(file,count,flow);

        protected WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => Util.EmittingTable<T>(dst);

        protected ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => Util.EmittedTable(flow,count,dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, FS.FilePath dst)
            where T : struct
                => Util.TableEmit(src,dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst)
            where T : struct
                => Util.TableEmit(src,widths,dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, TextEncodingKind encoding, FS.FilePath dst)
            where T : struct
                => Util.TableEmit(src,widths,encoding,dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, StreamWriter writer, FS.FilePath dst)
            where T : struct
                => Util.TableEmit(src,widths,writer,dst);

        protected uint TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ushort rowpad, Encoding encoding, FS.FilePath dst)
            where T : struct
                => Util.TableEmit(src,widths,rowpad,encoding,dst);

        protected Outcome<uint> EmitLines(ReadOnlySpan<TextLine> src, FS.FilePath dst, TextEncodingKind encoding)
            => Util.EmitLines(src,dst,encoding);


        protected Outcome RunExe(ReadOnlySpan<ToolCmdFlow> flows)
        {
            if(ToolFlows.target(flows,FS.Exe, out var flow))
            {
                ref readonly var target = ref flow.Target;
                Write(string.Format("Executing {0}", flow.Target.ToUri()));
                var result = OmniScript.Run(target, CmdVars.Empty, true, out var response);
                if(result.Fail)
                    return result;

                for(var j=0; j<response.Length; j++)
                    Write(skip(response, j).Content);
                return true;
            }
            else
                return false;
        }


        protected FS.Files ProjectFiles(IProjectWs ws, Subject? scope)
        {
            if(scope != null)
                return ws.SrcFiles(scope.Value.Format());
            else
                return ws.SrcFiles();
        }

        protected Outcome RunProjectScript(IProjectWs ws, CmdArgs args, ScriptId script, Subject? scope = null)
        {
            var result = Outcome.Success;
            if(args.Count != 0)
            {
                result = OmniScript.RunProjectScript(ws.Project, arg(args,0).Value, script, false, out _);
                return result;
            }

            var src = ProjectFiles(ws, scope).View;
            if(result.Fail)
                return result;

            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                RunProjectScript(ws,path,script);
            }

            return result;
        }

        protected Outcome RunProjectScript(IProjectWs ws, FS.FilePath path, ScriptId script)
        {
            var srcid = path.FileName.WithoutExtension.Format();
            OmniScript.RunProjectScript(ws.Project, srcid, script, true, out var flows);
            for(var j=0; j<flows.Length; j++)
            {
                ref readonly var flow = ref skip(flows, j);
                Write(flow.Format());
            }
            return true;
        }

        protected static CmdArg arg(in CmdArgs src, int index)
        {
            if(src.IsEmpty)
                sys.@throw(EmptyArgList.Format());

            var count = src.Length;
            if(count < index - 1)
                sys.@throw(ArgSpecError.Format());
            return src[(ushort)index];
        }

        protected Outcome RunProjectScript(IProjectWs ws, ScriptId script)
        {
            OmniScript.RunProjectScript(ws.Project, script, true, out var flows);
            for(var j=0; j<flows.Length; j++)
            {
                ref readonly var flow = ref skip(flows, j);
                Write(flow.Format());
            }
            return true;
        }

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

        static MsgPattern EmptyArgList => "No arguments specified";

        static MsgPattern ArgSpecError => "Argument specification error";
    }
}