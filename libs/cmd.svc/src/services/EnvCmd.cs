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

        [CmdOp("app/settings")]
        void AppSetings()
            => iter(AppSettings.load(), setting => Write(setting.Format()));

        [CmdOp("env/emit/includes")]
        void LoadToolEnv()
            => ToolBox.EmitIncludePaths();

        [CmdOp("env/load")]
        void LoadEnv(CmdArgs args)
            => iter(EnvDb.vars(args.Count != 0 ? arg(args,0).Value : null).View, member => Write(member.Format()));

        [CmdOp("env/emit")]
        void EmitEnvVars()
            => EnvVars.emit();

        [CmdOp("tools/env")]
        void ShowToolEnv()
            => iter(ToolBox.LoadEnv(), s => Write(s));

        [CmdOp("tool/script")]
        Outcome ToolScript(CmdArgs args)
            => ToolBox.RunScript(arg(args,0).Value, arg(args,1).Value);

        [CmdOp("tool/configure")]
        void ConfigureTool(CmdArgs args)
            => iter(ToolBox.Configure(tool(args)), entry => Write(entry));

        static ToolId tool(CmdArgs args, byte index = 0)
            => arg(args,index).Value;

        [CmdOp("tool/config")]
        void ShowToolSettings(CmdArgs args)
            => iter(ToolBox.LoadConfig(tool(args)), entry => Write(entry));

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(ToolBox.LoadDocs(arg(args,0).Value), doc => Write(doc));
    }
}