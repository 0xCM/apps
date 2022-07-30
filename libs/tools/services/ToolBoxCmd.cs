//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class ToolBoxCmd : AppCmdService<ToolBoxCmd>
    {
        Tooling Tooling => Wf.Tooling();

        [CmdOp("env/includes")]
        void LoadToolEnv()
            => Tooling.EmitIncludePaths();        

        [CmdOp("llvm/toolset")]
        void LlvmConfig(CmdArgs args)
        {
            // d:/views/llvm/llvm.config
            var path = FS.path(arg(args,0));
            var Lookup = Tooling.config(path);
            Lookup.Iter(setting => Write(setting.Format(Chars.Colon)));
        }

        [CmdOp("tools/env")]
        void ShowToolEnv()
            => iter(Tooling.LoadEnv(), s => Write(s));

        [CmdOp("tool/script")]
        Outcome ToolScript(CmdArgs args)
            => Tooling.RunScript(arg(args,0).Value, arg(args,1).Value);

        [CmdOp("tool/setup")]
        void ConfigureTool(CmdArgs args)
            => Tooling.Setup(Tooling.tool(args));

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(Tooling.LoadDocs(arg(args,0).Value), doc => Write(doc));

        [CmdOp("tool/config")]
        void ToolConfig(CmdArgs args)
        {
            var tool = arg(args,0);
            var src = AppDb.Toolbase().Sources(tool).Path(tool, FileKind.Config);
            Write($"{tool}:{src.ToUri()}");
            var settings = Tooling.config(src);
            var count = settings.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var setting = ref settings[i];
                Write($"{setting}");
            }
        }
    }
}