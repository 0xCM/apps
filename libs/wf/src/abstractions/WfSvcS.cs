//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class WfSvc<S> : AppService<S>, IWfSvc
        where S : WfSvc<S>, new()
    {
        ConcurrentDictionary<ProjectId, FileFlowContext> _Context = new();

        public FileCatalog ProjectFiles { get; protected set; }

        protected IProjectDb ProjectDb;

        protected static bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.get().PllExec();
        }

        protected OmniScript OmniScript => Wf.OmniScript();

        protected WfSvc()
        {

        }

        public WfEmit Emitter {get; private set;}

        protected override void OnInit()
        {
            base.OnInit();
            Emitter = new WfEmit(this);
            ProjectDb = ProjectDbWs.create(FS.dir("d:/drives/z/db/targets"));
        }

        protected static CmdArg arg(in CmdArgs src, int index)
            => Cmd.arg(src, index);

        protected static AppDb AppDb => AppDb.Service;

        [MethodImpl(Inline)]
        public IWsProject Project()
            => WfSvc.project();

        protected void Try(Action f, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
        {
            try
            {
                f();
            }
            catch (Exception e)
            {
                Error(e, caller, file, line);
            }
        }

        protected FileFlowContext Context()
        {
            var project = Project();
            return _Context.GetOrAdd(project.Id, _ => FlowContext.create(project));
        }

        [CmdOp("project/home")]
        protected void ProjectHome()
            => Write(Context().Project.Home());

        [CmdOp("project/files")]
        protected void ListProjectFiles(CmdArgs args)
        {
            if (args.Count != 0)
                iter(Context().Files.Docs(arg(args, 0)), file => Write(file.Format()));
            else
                iter(Context().Files.Docs(), file => Write(file.Format()));
        }

        [CmdOp("project")]
        public Outcome LoadProject(CmdArgs args)
            => LoadProjectSources(AppDb.EtlSource(arg(args, 0).Value));

        protected Outcome LoadProjectSources(IWsProject ws)
        {
            var result = Outcome.Success;
            if (ws == null)
                result = Outcome.fail("Project unspecified");
            else
            {
                Status($"Loading project from {ws.Home()}");
                WfSvc.project(ws);
                ProjectFiles = FileCatalog.load(WfSvc.project().ProjectFiles().Storage.ToSortedSpan());
                var dir = ws.Home();
                if (dir.Exists)
                    Files(ws.SrcFiles());
                Status($"Project={WfSvc.project()}");
            }
            return result;
        }

        protected Outcome LoadProject(IWsProject src)
        {
            var result = Outcome.Success;
            if (src == null)
                result = Outcome.fail("Project unspecified");
            else
            {
                var dir = src.Home();
                result = dir.Exists;
                if (result)
                    Files(src.SrcFiles());
                else
                    result = Outcome.fail($"{src.Project.Id} not found"); ;
            }
            return result;
        }

        public void Babble<T>(T content)
            => Emitter.Babble(content);

        public new void Babble(string pattern, params object[] args)
            => Emitter.Babble(pattern, args);

        public new void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => Emitter.Status(content, flair);

        public new void Status(ReadOnlySpan<char> src, FlairKind flair = FlairKind.Status)
            => Emitter.Status(src, flair);

        public new void Status(FlairKind flair, string pattern, params object[] args)
            => Emitter.Status(pattern, flair, args);

        public new void Status(string pattern, params object[] args)
            => Emitter.Status(pattern, args);

        public new void Warn<T>(T content)
            => Emitter.Warn(content);

        public new void Warn(string pattern, params object[] args)
            => Emitter.Warn(pattern, args);

        public new void Error<T>(T content, [CallerName] string caller = null, [CallerFile] string file = null, [CallerLine] int? line = null)
            => Emitter.Error(content, caller, file, line);

        public new void Write<T>(T content)
            => Emitter.Write(content);

        public void Write<T>(T content, FlairKind flair)
            => Emitter.Write(content, flair);

        public void Row<T>(T content)
            => Emitter.Row(content);

        public void Row<T>(T content, FlairKind flair)
            => Emitter.Row(content, flair);

        public void Write(string content, FlairKind flair)
            => Emitter.Write(content, flair);

        public void Write<T>(string name, T value, FlairKind flair)
            => Emitter.Write(name, value, flair);

        public void Write<T>(string name, T value)
            => Emitter.Write(name, value);

        public new WfExecFlow<T> Running<T>(T msg)
            => Emitter.Running(msg);

        public new WfExecFlow<string> Running([CallerName] string msg = null)
            => Emitter.Running(msg);

        public new ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => Emitter.Ran(flow, msg);

        public ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
            => Emitter.Ran(flow, msg, flair);

        public ExecToken Ran<T, D>(WfExecFlow<T> src, D data)
            => Emitter.Ran(src, data);

        public new WfFileWritten EmittingFile(FS.FilePath dst)
            => Emitter.EmittingFile(dst);

        public new ExecToken EmittedFile(WfFileWritten flow, Count count)
            => Emitter.EmittedFile(flow, count);

        public ExecToken EmittedFile(WfFileWritten flow, int count)
            => Emitter.EmittedFile(flow, count);

        public ExecToken EmittedFile(WfFileWritten flow, uint count)
            => Emitter.EmittedFile(flow, count);

        public ExecToken EmittedFile<T>(WfFileWritten flow, T msg)
            => Emitter.EmittedFile(flow, msg);

        public ExecToken EmittedBytes(WfFileWritten flow, ByteSize size)
            => Emitter.EmittedBytes(flow, size);

        public new WfTableFlow<T> EmittingTable<T>(FS.FilePath dst)
            where T : struct
                => Emitter.EmittingTable<T>(dst);

        public new ExecToken EmittedTable<T>(WfTableFlow<T> flow, Count count, FS.FilePath? dst = null)
            where T : struct
                => Emitter.EmittedTable(flow, count, dst);

        public ExecToken FileEmit<T>(T src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Emitter.FileEmit(src, count, dst, encoding);

        public ExecToken FileEmit<T>(T src, FS.FilePath dst, ByteSize size, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Emitter.FileEmit(src, dst, size, encoding);

        public ExecToken FileEmit<T>(T src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Emitter.FileEmit(src, dst, encoding);

        public ExecToken FileEmit<T>(T src, string msg, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Emitter.FileEmit(src, msg, dst, encoding);

        public ExecToken FileEmit<T>(ReadOnlySpan<T> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            => Emitter.FileEmit(src, dst, encoding);

        public ExecToken TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => Emitter.TableEmit(src, widths, encoding, dst);

        public ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
                => Emitter.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(Index<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
                => Emitter.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(T[] rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
            where T : struct
            => Emitter.TableEmit(rows, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(ReadOnlySeq<T> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
            => Emitter.TableEmit(src, dst, encoding);

        public ExecToken TableEmit<T>(Seq<T> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => Emitter.TableEmit(src, dst, encoding);
    }
}