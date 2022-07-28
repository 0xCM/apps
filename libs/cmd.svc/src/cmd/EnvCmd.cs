//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    class EnvCmd : AppCmdService<EnvCmd>
    {
        ToolBoxCmd ToolBox => Wf.ToolBoxCmd();

        static EnvVars<string> vars(string name = null)
            => AppDb.Service.LoadEnv(text.ifempty(name, Environment.MachineName.ToLower()));

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

        [CmdOp("env/load")]
        void LoadEnv(CmdArgs args)
            => iter(vars(args.Count != 0 ? arg(args,0).Value : null).View, member => Write(member.Format()));

        [CmdOp("env/machine")]
        void ListMachineEnv()
            => EnvVars.machine().Iter(v => Write(v.Format()));

        [CmdOp("env/user")]
        void ListUserEnv()
            => EnvVars.user().Iter(v => Write(v.Format()));

        [CmdOp("env/process")]
        void ListProcessEnv()
            => EnvVars.user().Iter(v => Write(v.Format()));

        void EmitEnv(SysEnvKind kind)
        {
            var src = EnvVars.vars(kind);
            var file = FS.file($"{kind}".ToLower(), FileKind.Env);

        }

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

        [CmdOp("env/includes")]
        void LoadToolEnv()
            => ToolBox.EmitIncludePaths();
    }
}