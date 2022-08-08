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

        [CmdOp("tools")]
        void ListTools()
        {
            var tools = TB.Tools();
            //var dst = AppDb.App().Path("tools", FileKind.Log);
            var dst = TB.Location.Path("inventory",FileKind.Env);
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
                    var settings = Tooling.settings(envpath);
                    emitter.WriteLine("Settings={");
                    emitter.Write(settings.Format(4));
                    emitter.WriteLine("}");
                    counter += 2*6;
                }
            }

            EmittedFile(emitting, counter);
        }

        [CmdOp("tool/cmd")]
        void ExecToolCmd(CmdArgs args)
        {
            var tool = TB.Tool(arg(args,0).Value);

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

        [CmdOp("tool/env")]
        void ToolConfig(CmdArgs args)
        {
            var tool = TB.Tool(arg(args,0).Value);
            var path = tool.EnvPath();
            var settings = Tooling.settings(path);
            Row(settings.Format());
        }

        void Link(CmdArgs args)
        {
            var src = FS.dir(arg(args,0).Value);
            var dst = FS.dir(arg(args,1).Value);
            var cmd = Tools.mklink(src,dst);
            
        }
    }
}