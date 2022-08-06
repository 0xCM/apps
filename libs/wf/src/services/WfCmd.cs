//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    using static Algs;

    public class WfCmd : AppCmdService<WfCmd>
    {
        [CmdOp("files")]
        void ListFiles(CmdArgs args)
        {
            var src = FS.dir(arg(args,0));
            var files = FS.listing(src);
            TableEmit(files, AppDb.Catalogs("files").Table<ListedFile>(Archives.identifier(src)));
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

        [CmdOp("env/thread")]
        Outcome ShowThread(CmdArgs args)
        {
            var id = Kernel32.GetCurrentThreadId();
            Wf.Data(string.Format("ThreadId:{0}", id));
            return true;
        }

        [CmdOp("app/deploy")]
        void Deploy()
        {
            var dst = AppDb.Tools("z0/cmd").Targets().Root;
            var src = ExecutingPart.Component.Path().FolderPath;
            Archives.robocopy(src,dst);
        }

        [CmdOp("process/origin")]
        void ProcessOrigin()
            => Write(FS.path(Environment.ProcessPath));

        [CmdOp("cmd")]
        protected void RunCmd(CmdArgs args)
            => CmdScripts.start(args);

        [CmdOp("tool")]
        void RunTool(CmdArgs args)
        {
            var tool = arg(args,0).Value;
            var script = arg(args,1).Value;
            var count = args.Count - 2;
            var _args = count > 0 ? sys.alloc<string>(count) : sys.empty<string>();
            var path = AppDb.Toolbase($"{tool}/scripts").Path(FS.file(script,FileKind.Cmd));
            var emitter = text.emitter();
            var j=2;
            for(var i=0; i<count; i++, j++)
            {
                emitter.Append(Chars.Space);
                emitter.Append(args[i].Value);
            }
            
            var cmd = Cmd.cmdline(path,CmdKind.Tool, emitter.Emit());        
            CmdScripts.start(cmd);        
        }

        [CmdOp("cmd/copy")]
        void Copy(CmdArgs args)
        {
            var src = FS.dir(arg(args,0).Value);
            var dst = FS.dir(arg(args,1).Value);
            Archives.robocopy(src,dst);
        }

        [CmdOp("pwsh")]
        protected void RunPwshCmd(CmdArgs args)
        {
            var cmd = Cmd.pwsh(Cmd.join(args));
            Status($"Executing '{cmd}'");
            CmdScripts.start(cmd);
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
                var cmd = CmdScripts.pwsh(script);
                CmdScripts.start(cmd);
                Status($"Launch script {script.ToUri()} executing", FlairKind.Ran);
            });
        }

        [CmdOp("settings")]
        void ReadSettings(CmdArgs args)
        {
            var src = AppSettings.load();
            iter(src, setting => Write(setting.Format()));
        }

        [CmdOp("setting")]
        Outcome Setting(CmdArgs args)
        {
            var name = arg(args,0).Value;
            var result = Outcome.Success;
            if(AppSettings.Service().Find(name, out var value))
            {
                Write($"{name}:{value}");
            }
            else
            {
                result = (false, $"Setting '{name}' not found");
            }
            return result;
        }

        [CmdOp("memory")]
        Outcome ShowMemHex(CmdArgs args)
        {
            var address = MemoryAddress.Zero;
            var result = DataParser.parse(arg(args,0), out address);
            if(result)
            {

                var size = 16u;
                if(args.Count >= 2)
                    result = DataParser.parse(arg(args,1), out size);

                if(result)
                {
                    ref readonly var src = ref address.Ref<byte>();
                    var data = Algs.cover(src,size);
                    var hex = data.FormatHex();
                    Write(string.Format("{0,-16}: {1}", address, hex));
                }

            }
            return result;
        }

        [CmdOp("env")]
        void EmitEnv(CmdArgs args)
        {
            var dst = AppDb.Env().Root;
            EnvVars.emit(Emitter,SysEnvKind.Process, dst);
            EnvVars.emit(Emitter,SysEnvKind.User, dst);
            EnvVars.emit(Emitter,SysEnvKind.Machine, dst);
        }

        [CmdOp("env/machine")]
        void EmitMachineEnv()
            => EnvVars.emit(Emitter, SysEnvKind.Machine, AppDb.Env().Root);

        [CmdOp("env/user")]
        void EmitUserEnv()
            => EnvVars.emit(Emitter, SysEnvKind.User, AppDb.Env().Root);

        [CmdOp("env/process")]
        void EmitProcessEnv()
            => EnvVars.emit(Emitter, SysEnvKind.Process, AppDb.Env().Root);

        [CmdOp("env/pid")]
        void ProcessId()
            => Write(Environment.ProcessId);

        [CmdOp("env/cpucore")]
        void ShowCurrentCore()
        {
            Write(string.Format("Cpu:{0}", Kernel32.GetCurrentProcessorNumber()));
        }

        void ShowMemory()
        {
            var info = WinMem.basic();
            var formatter = Tables.formatter<BasicMemoryInfo>(16,RecordFormatKind.KeyValuePairs);
            Wf.Data(formatter.Format(info));
        }

        [CmdOp("env/stack")]
        void Stack()
            => Write(Environment.StackTrace);

        [CmdOp("env/pagesize")]
        void PageSize()
            => Write(Environment.SystemPageSize);

        [CmdOp("env/ticks")]
        void Ticks()
            => Write(Environment.TickCount64);

        [CmdOp("process/location")]
        void ProcessHome()
            => Write(FS.path(ExecutingPart.Component.Location).FolderPath);

        [CmdOp("env/mem-physical")]
        void WorkingSet()
            => Write(((ByteSize)Environment.WorkingSet));

        [CmdOp("env/args")]
        void CmdlLineArgs()
            => iter(Environment.GetCommandLineArgs(), arg => Write(arg));

        [CmdOp("env/cwd")]
        void Cwd()
            => Write(FS.dir(Environment.CurrentDirectory)); 

        [CmdOp("mem/query")]
        void QueryMemory(CmdArgs args)
        {            
            var @base = ExecutingPart.Process.Adapt().BaseAddress;
            if(args.Count != 0)
            {
                var result = DataParser.parse(args[0].Value, out @base);
                if(result.Fail)
                {
                    Error($"Could not parse ${args[0].Value} as an address");
                    return;
                }
            }

            var basic = BasicMemoryInfo.Empty;
            WinMem.vquery(@base, ref basic);
            Write(basic.ToString());
        }
    }
}