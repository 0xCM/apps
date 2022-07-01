//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class WfSvc<S> : AppService<S>
        where S : WfSvc<S>, new()
    {
        ConcurrentDictionary<ProjectId,WsContext> _Context = new();

        IWsProject _Project;

        Option<IToolCmdShell> Shell;

        protected Outcome SelectTool(ToolId tool)
        {
            var result = Outcome.Success;
            if(Shell.IsNone())
            {
                result = (false, "Target shell unspecified");
                return result;
            }

            return Shell.Value.SelectTool(tool);
        }

        public WsCatalog ProjectFiles {get; protected set;}

        protected WfSvc()
        {

        }

        protected static CmdArg arg(in CmdArgs src, int index)
            => ShellCmd.arg(src, index);

        protected static AppDb AppDb => AppDb.Service;

        protected IDbArchive DbArchive => Archives.archive(FS.dir(AppSettings.Find(SettingNames.DbRoot)));

        protected ToolWs ToolWs => new ToolWs(AppDb.Toolbase());

        public Settings ShellSettings()
            => Settings.table(Settings.path());

        protected void LoadProjectInner(IWsProject ws)
        {
            _Project = Require.notnull(ws);
            ProjectFiles = WsCatalog.load(ws);
        }


        [MethodImpl(Inline)]
        public IWsProject Project()
        {
            if(_Project == null)
            {
                Errors.Throw("Project is null");
            }
            return _Project;
        }

        protected WsContext Context()
        {
            var project = Project();
            return _Context.GetOrAdd(project.Id, _ => WsContext.load(project));
        }

        [CmdOp("project/home")]
        protected void ProjectHome()
            => Write(Context().Project.Home());

        [CmdOp("project/files")]
        protected void ListProjectFiles(CmdArgs args)
        {
            if(args.Count != 0)
                iter(Context().Catalog.Entries(arg(args,0)), file => Write(file.Format()));
            else
                iter(Context().Catalog.Entries(), file => Write(file.Format()));
        }

        [CmdOp("project")]
        public Outcome LoadProject(CmdArgs args)
            => LoadProjectSources(AppDb.LlvmModel(arg(args,0).Value));

        protected Outcome LoadProjectSources(IWsProject ws)
        {
            var result = Outcome.Success;
            if(ws == null)
                result = Outcome.fail("Project unspecified");
            else
            {
                Status($"Loading project from {ws.Home()}");

                LoadProjectInner(ws);

                var dir = ws.Home();
                if(dir.Exists)
                    Files(ws.SrcFiles());
            }
            return result;
        }

        protected Outcome LoadProject(IWsProject src)
        {
            var result = Outcome.Success;
            if(src == null)
                result = Outcome.fail("Project unspecified");
            else
            {
                var dir = src.Home();
                result = dir.Exists;
                if(result)
                    Files(src.SrcFiles());
                else
                    result = Outcome.fail($"{src.Project.Id} not found");;
            }
            return result;
        }

        public void Babble<T>(T content)
            => WfMsg.Babble(content);

        public new void Babble(string pattern, params object[] args)
            => WfMsg.Babble(pattern, args);

        public new void Status<T>(T content, FlairKind flair = FlairKind.Status)
            => WfMsg.Status(content, flair);

        public new void Status(ReadOnlySpan<char> src, FlairKind flair = FlairKind.Status)
            => WfMsg.Status(src, flair);

        public new void Status(FlairKind flair, string pattern, params object[] args)
            => WfMsg.Status(pattern, flair, args);

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

        public void Write<T>(T content, FlairKind flair)
            => WfMsg.Write(content, flair);

        public void Row<T>(T content)
            => WfMsg.Row(content);

        public void Row<T>(T content, FlairKind flair)
            => WfMsg.Row(content, flair);

        public void Write(string content, FlairKind flair)
            => WfMsg.Write(content, flair);

        public void Write<T>(string name, T value, FlairKind flair)
            => WfMsg.Write(name, value, flair);

        public void Write<T>(string name, T value)
            => WfMsg.Write(name, value);

        public new WfExecFlow<T> Running<T>(T msg)
            => WfMsg.Running(msg);

        public new WfExecFlow<string> Running([CallerName] string msg = null)
            => WfMsg.Running(msg);

        public new ExecToken Ran<T>(WfExecFlow<T> flow, [CallerName] string msg = null)
            => WfMsg.Ran(flow,msg);

        public ExecToken Ran<T>(WfExecFlow<T> flow, string msg, FlairKind flair = FlairKind.Ran)
            => WfMsg.Ran(flow, msg, flair);

        public ExecToken Ran<T,D>(WfExecFlow<T> src, D data)
            => WfMsg.Ran(src, data);

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
                => WfEmit.TableEmit(src, widths, encoding, dst);

        public void FileEmit<T>(T src, Count count, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            EmittedFile(emitting, count);
        }

        public void FileEmit<T>(T src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            EmittedFile(emitting, 0);
        }

        public void FileEmit<T>(T src, string msg, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            Write(string.Format("{0,-12} | {1}", "Emitting", dst.ToUri()), FlairKind.Running);
            using var emitter = dst.Writer(encoding);
            emitter.Write(src.ToString());
            Write(string.Format("{0,-12} | {1}", "Emitted", dst.ToUri()), FlairKind.Ran);
            Write(string.Format("{0,-12} | {1}", "Description", msg), FlairKind.Ran);
        }

        public ExecToken FileEmit<T>(ReadOnlySpan<T> lines, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer(encoding);
            var count = lines.Length;
            for(var i=0; i<count; i++)
                writer.AppendLine(skip(lines,i));
            var emitted = EmittedFile(emitting, count);
            return emitted;
        }

        public ExecToken TableEmit<T>(ReadOnlySpan<T> rows, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci,
            ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
        {
            var emitting = EmittingTable<T>(dst);
            var formatter = RecordFormatters.create(typeof(T), rowpad, fk);
            using var writer = dst.Writer(encoding);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<rows.Length; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));
            return EmittedTable(emitting, rows.Length, dst);
        }

        public ExecToken TableEmit<T>(Index<T> rows, FS.FilePath dst,
            TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
                    => TableEmit(rows.View, dst, encoding, rowpad, fk);

        public ExecToken TableEmit<T>(T[] rows, FS.FilePath dst,
            TextEncodingKind encoding = TextEncodingKind.Asci, ushort rowpad = 0, RecordFormatKind fk = RecordFormatKind.Tablular)
                where T : struct
                    => TableEmit(@readonly(rows), dst, encoding, rowpad, fk);
    }

}