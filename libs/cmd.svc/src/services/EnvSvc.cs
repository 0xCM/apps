//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    using static core;

    public class EnvSvc : AppCmdService<EnvSvc>
    {
        [CmdOp("env/svc/load")]
        protected new Outcome LoadEnv(CmdArgs args)
        {
            var name = Environment.MachineName.ToLower();
            if(args.Count != 0)
                name = arg(args,0).Value.Format();

            var set = AppDb.LoadEnv(name);
            iter(set, member => Write(member.Format()));

            return true;
        }

        [CmdOp("env/svc/emit")]
        protected new void EmitEnvVars()
        {
            TableEmit(EnvDb.records(Environs.vars(), machine), AppDb.Env().Table<EnvSettingRow>(machine));
        }

        protected new Settings UpdateToolEnv()
        {
            var path = ToolWs.Service.Toolbase.Path(FS.file("show-env-config", FS.Cmd));
            var cmd = CmdScript.cmdline(path.Format(PathSeparator.BS));
            return AppSettings.Load(OmniScript.RunCmd(cmd));
        }

        protected new Settings LoadToolEnv(string name)
        {
            var path = ToolWs.Service.Toolbase.Path(FS.file(name, FileKind.Env));
            return AppSettings.Load(path.ReadNumberedLines());
        }

        [CmdOp("env/svc/tools")]
        protected new Outcome ShowToolEnv(CmdArgs args)
        {
            var settings = LoadToolEnv(tools);
            iter(settings, s => Write(s));
            return true;
        }

        [CmdOp("env/tools/script")]
        protected new Outcome ToolScript(CmdArgs args)
        {
            var tool = (ToolId)arg(args,0).Value;
            var script = ToolWs.Script(tool, arg(args,1).Value);
            if(!script.Exists)
                return (false, FS.missing(script));
            else
                return OmniScript.Run(script, out var _);
        }

        [CmdOp("env/tools/config")]
        protected new Outcome ConfigureTool(CmdArgs args)
        {
            var result = Outcome.Success;
            ToolId tool = arg(args,0).Value;
            var script = ToolWs.Service.ConfigScript(tool);
            result = OmniScript.Run(script, out var _);
            var logpath = ToolWs.ConfigLog(tool);
            using var reader = logpath.AsciLineReader();
            var line = AsciLine.Empty;
            while(reader.Next(out line))
            {
                Write(line.Format());
            }

            return result;
        }

        [CmdOp("env/tools/help")]
        protected new void ShowToolHelp(CmdArgs args)
        {
            var result = Outcome.Success;
            var tool = (ToolId)arg(args,0).Value;
            var docs = ToolWs.Service.ToolDocs(tool);
            var doc = docs + FS.file(tool.Format(),FS.Help);
            if(doc.Exists)
            {
                using var reader = doc.Utf8LineReader();
                while(reader.Next(out var line))
                    Write(line.Content);
            }
        }

        static ToolId tool(CmdArgs args, byte index = 0)
            => arg(args,index).Value;

        static FS.FileName config(ToolId tool)
            => FS.file(tool,FileKind.Config);

        [CmdOp("env/tools/settings")]
        protected new Outcome ShowToolSettings(CmdArgs args)
        {
            var id = tool(args);
            var src = ToolWs.Service.Logs(arg(args,0).Value) + FS.file("config", FS.Log);
            if(!src.Exists)
                return (false,FS.missing(src));
            iter(ToolWs.settings(src), setting => Write(setting));
            return true;
        }

        [CmdOp("env/tools/docs")]
        protected new Outcome ToolDocs(CmdArgs args)
        {
            var tool = (ToolId)arg(args,0).Value;
            var path = FS.FilePath.Empty;
            if(args.Length > 1)
                path = ToolWs.Service.ToolDocs(tool) + FS.file(arg(args,1));
            else
            {

                path = ToolWs.Service.ToolDocs(tool) + FS.file(tool.Format(), FS.Help);
            }

            if(path.Exists)
            {
                Write(path.ReadText());
                return true;
            }
            else
                return (false, FS.missing(path));
        }

    }
}