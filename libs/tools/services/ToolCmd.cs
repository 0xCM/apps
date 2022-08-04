//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class ToolCmdSvc : AppCmdService<ToolCmdSvc>
    {
        Tooling Tooling => Wf.Tooling();

        static readonly Toolbase TB = new();

        [CmdOp("tools/includes")]
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

        [CmdOp("tools")]
        void ListTools()
        {
            var tools = TB.Tools();
            var dst = AppDb.App().Path("tools", FileKind.Log);
            var emitting = Emitter.EmittingFile(dst);
            var counter = 0u;

            using var emitter = dst.Emitter();
            for(var i=0; i<tools.Count; i++)
            {
                ref readonly var tool = ref tools[i];
                var location = tool.Location;                
                var docs = tool.Docs().Files();
                emitter.AppendLine(RP.PageBreak120);
                emitter.AppendLine($"Tool={tool.Name}");             
                emitter.AppendLine($"Home={tool.Location.Root}");
                emitter.AppendLine("[Docs]");
                iter(docs, doc => emitter.AppendLine(doc.ToUri().Format()));
                counter += (4 + docs.Count);

                var envpath = tool.Location.Path(tool.Name, FileKind.Env);
                if(envpath.Exists)
                {
                    emitter.AppendLine("[Env]");
                    emitter.AppendLine($"ConfigPath={envpath.ToUri()}");
                    var settings = Tooling.config(envpath);
                    emitter.WriteLine("Settings=[");
                    settings.Iter(setting => emitter.IndentLineFormat(4, "{0},", setting.Format(Chars.Eq)));
                    emitter.WriteLine("]");
                    counter += (2 + settings.Count);
                }
            }

            EmittedFile(emitting, counter);
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