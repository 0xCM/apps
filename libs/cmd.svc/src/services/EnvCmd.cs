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
        void EmitMachineEnv()
            => EnvVars.emit();
    }
}