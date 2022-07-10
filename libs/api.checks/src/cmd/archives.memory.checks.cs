//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AppCmd
    {
        ToolBox ToolBox => Wf.ToolBox();

        [CmdOp("archives/memory/check")]
        void CheckMemoryArchives()
        {

        }

        [CmdOp("tools/env")]
        void ShowToolEnv()
            => iter(ToolBox.LoadEnv(), s => Write(s));

        [CmdOp("tool/script")]
        Outcome ToolScript(CmdArgs args)
            => ToolBox.RunScript(arg(args,0).Value, arg(args,1).Value);

        [CmdOp("tool/setup")]
        void ConfigureTool(CmdArgs args)
            => iter(ToolBox.Setup(tool(args)), entry => Write(entry));

        static Actor tool(CmdArgs args, byte index = 0)
            => arg(args,index).Value;

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(ToolBox.LoadDocs(arg(args,0).Value), doc => Write(doc));

        [CmdOp("tool/config")]
        void ToolConfig(CmdArgs args)
        {
            var tool = arg(args,0);
            var src = AppDb.Toolbase().Sources(tool).Path(tool, FileKind.Config);
            Write($"{tool}:{src.ToUri()}");
            var settings = ToolWs.config(src);
            var count = settings.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var setting = ref settings[i];
                Write($"{setting}");
            }
        }
    }
}