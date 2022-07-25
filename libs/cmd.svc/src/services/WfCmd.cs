//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public class WfCmd : AppCmdService<WfCmd>
    {
        ToolBox ToolBox => Wf.ToolBox();

        [CmdOp("files")]
        protected void ListFiles(CmdArgs args)
        {
            var src = FS.dir(arg(args,0));
            var files = FS.listing(src);
            iter(files, file => Write(file.Path));
            TableEmit(files, AppDb.App().Table<ListedFile>());
        }

        [CmdOp("settings")]
        void Setings()
            => AppSettings.Iter(setting => Write(setting.Format(Chars.Eq)));

        [CmdOp("setting")]
        Outcome Setting(CmdArgs args)
        {
            var name = arg(args,0).Value;
            var result = Outcome.Success;
            if(AppSettings.Find(name, out var value))
            {
                Write($"{name}:{value}");
            }
            else
            {
                result = (false, $"Setting '{name}' not found");
            }
            return result;
        }

        void CalcRelativePaths()
        {
            var @base = FS.dir("dir1");
            var files = FS.dir("dir2").AllFiles;
            var links = Markdown.links(@base,files);
            iter(links, r=> Write(r.Format()));
        }

        [CmdOp("jobs/types")]
        void ListJobTypes()
        {
            var db = AppDb.DbRoot();
            Write(db.Root);
            Write(RpOps.PageBreak80);
            var jobs = db.Sources("jobs");
            Write($"Jobs: {jobs.Root}");

            jobs.Root.Folders(true).Iter(f => Write(f.Format()));
        }

        [CmdOp("app/deps")]
        void Deps()
        {
            var src = JsonDeps.parse(ExecutingPart.Component);
            src.RuntimeLibs().Iter(x => Write(x));
        }

        [CmdOp("app/deploy")]
        void Deploy()
        {
            var dst = ApiPack.create().Context().Targets("bin");
            var src = ExecutingPart.Component.Path().FolderPath;
            Archives.robocopy(src,dst.Root);
        }

        [CmdOp("env/includes")]
        void LoadToolEnv()
            => ToolBox.EmitIncludePaths();

        static EnvVars<string> vars(string name = null)
            => AppDb.Service.LoadEnv(text.ifempty(name, Environment.MachineName.ToLower()));

        [CmdOp("env/load")]
        void LoadEnv(CmdArgs args)
            => iter(vars(args.Count != 0 ? arg(args,0).Value : null).View, member => Write(member.Format()));

        [CmdOp("env/list")]
        void ListMachineEnv()
            => EnvVars.machine().Iter(v => Write(v.Format()));

        [CmdOp("env")]
        Outcome EmitEnv(CmdArgs args)
        {
            var result = Outcome.Success;
            if(args.Count == 0)
                EnvVars.emit(SysEnvKind.Process);
            else
            {
                var name = arg(args,0);
                var kind = SysEnvKind.Process;
                var parser = EnumParser<SysEnvKind>.Service;
                result = parser.Parse(name, out kind);
                if(result)
                    EnvVars.emit(kind);
            }
            return result;
        }

        [CmdOp("env/cwd")]
        void Cwd()
            => Write(FS.dir(Environment.CurrentDirectory));

        [CmdOp("process/origin")]
        void ProcessOrigin()
            => Write(FS.path(Environment.ProcessPath));

        [CmdOp("process/id")]
        void ProcessId()
            => Write(Environment.ProcessId);

        [CmdOp("process/home")]
        void ProcessHome()
            => Write(FS.path(ExecutingPart.Component.Location).FolderPath);

        [CmdOp("process/working-set")]
        void WorkingSet()
            => Write(((ByteSize)Environment.WorkingSet));

        [CmdOp("process/stack")]
        void Stack()
            => Write(Environment.StackTrace);

        [CmdOp("pid")]
        void PID()
            => Write(Environment.ProcessId);

        [CmdOp("sys/pagesize")]
        void PageSize()
            => Write(Environment.SystemPageSize);

        [CmdOp("sys/ticks")]
        void Ticks()
            => Write(Environment.TickCount64);

        [CmdOp("cmd")]
        protected void RunCmd(CmdArgs args)
        {
            var count = Demand.gt(args.Count,0u);
            var spec = text.emitter();
            for(var i=0; i<args.Count; i++)
            {
                if(i != 0)
                    spec.Append(Chars.Space);
                spec.Append(args[i].Value);
            }

            var cmd = Cmd.cmd(spec.Emit());
            Status($"Executing '{cmd}'");
            CmdLines.Start(cmd);
        }

        [CmdOp("pwsh")]
        protected void RunPwshCmd(CmdArgs args)
        {
            var cmd = Cmd.pwsh(Cmd.join(args));
            Status($"Executing '{cmd}'");
            CmdLines.Start(cmd);
        }

        [CmdOp("launchers")]
        protected void Launchers(CmdArgs args)
        {
            var src = AppDb.Control().Sources("launch").Files(FileKind.Ps1);
            iter(src, file => Write(file.FileName.WithoutExtension));
        }

        [CmdOp("launch")]
        protected void LaunchTargets(CmdArgs args)
        {
            var scripts = args.Map(x => AppDb.Control().Sources("launch").Path(FS.file(x.Value, FileKind.Ps1)));
            iter(scripts, script => {
                Status($"Launching target defined by {script.ToUri()}", FlairKind.Running);
                var cmd = Scripts.pwsh(script);
                CmdLines.Start(cmd);
                Status($"Launch script {script.ToUri()} executing", FlairKind.Ran);
            });
        }
    }
}