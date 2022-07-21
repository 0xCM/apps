//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class EnvCmd : AppCmdService<EnvCmd>
    {
        ToolBox ToolBox => Wf.ToolBox();

        void CalcRelativePaths()
        {
            var @base = FS.dir("dir1");
            var files = FS.dir("dir2").AllFiles;
            var links = Markdown.links(@base,files);
            iter(links, r=> Write(r.Format()));
        }

        [CmdOp("dir")]
        void Dir(CmdArgs args)
        {
            // var src = Archives.archive(FS.dir(arg(args,0)));
            // var files = ListedFiles.Empty;
            // if(args.Count >= 2)
            //     files = src.List(arg(args,1));
            // else
            //     files = src.List();

            // Row(files.Format());
        }

        [CmdOp("settings")]
        void Setings()
            => AppSettings.Iter(setting => Write(setting.Format(Chars.Eq)));

        [CmdOp("app/setting")]
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
            => Write(Environment.SystemPageSize);

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
    }
}