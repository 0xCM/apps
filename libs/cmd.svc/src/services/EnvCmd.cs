//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;
    using static core;

    public class EnvCmd : AppCmdService<EnvCmd>
    {
        public Settings LoadSettings()
        {
            var path = ToolWs.Toolbase.Path(FS.file("tools", FileKind.Env));
            return AppSettings.Load(path.ReadNumberedLines());
        }

        [CmdOp("settings")]
        void AppSetings()
        {
            var src = AppDb.Settings();
            iter(src, setting => Write(setting.Format()));
        }

        public void EmitEnvIncldes()
        {
            var result = Outcome.Success;
            var settings = LoadSettings();
            var env = EnvDb.tools(settings);
            var dst = ProjectDb.Log("env", FS.Log);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var headers = env.HeaderIncludes();
            writer.WriteLine("Header Includes");
            writer.WriteLine(RP.PageBreak120);
            iter(headers, h => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Header", h.Exists ? "Found" : "Mising", h)));
            writer.WriteLine();

            var libs = env.LibIncludes();
            writer.WriteLine("Lib Includes");
            writer.WriteLine(RP.PageBreak120);
            iter(libs, lib => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Lib", lib.Exists ? "Found" : "Mising", lib)));

            EmittedFile(emitting, 2);
        }

        [CmdOp("env/emit/includes")]
        void LoadToolEnv()
            => EmitEnvIncldes();

        [CmdOp("env/load")]
        Outcome LoadEnv(CmdArgs args)
        {
            var name = Environment.MachineName.ToLower();
            if(args.Count != 0)
                name = arg(args,0).Value.Format();

            var set = AppDb.LoadEnv(name);
            iter(set, member => Write(member.Format()));

            return true;
        }

        [CmdOp("env/emit")]
        void EmitEnvVars()
        {
            TableEmit(EnvDb.records(EnvSets.vars(), machine), AppDb.Env().Table<EnvSettingRow>(machine));
        }

        Settings UpdateToolEnv()
        {
            var path = ToolWs.Toolbase.Path(FS.file("show-env-config", FS.Cmd));
            var cmd = CmdScript.cmdline(path.Format(PathSeparator.BS));
            return AppSettings.Load(OmniScript.RunCmd(cmd));
        }

        protected new Settings LoadToolEnv(string name)
        {
            var path = ToolWs.Toolbase.Path(FS.file(name, FileKind.Env));
            return AppSettings.Load(path.ReadNumberedLines());
        }

        [CmdOp("toolbox/tools")]
        protected Outcome ShowToolEnv(CmdArgs args)
        {
            var settings = LoadToolEnv(tools);
            iter(settings, s => Write(s));
            return true;
        }

        [CmdOp("toolbox/script")]
        protected Outcome ToolScript(CmdArgs args)
        {
            var tool = (ToolId)arg(args,0).Value;
            var script = ToolWs.Script(tool, arg(args,1).Value);
            if(!script.Exists)
                return (false, FS.missing(script));
            else
                return OmniScript.Run(script, out var _);
        }

        [CmdOp("toolbox/config")]
        protected Outcome ConfigureTool(CmdArgs args)
        {
            var result = Outcome.Success;
            var id = tool(args);
            var script = ToolWs.ConfigScript(id);
            result = OmniScript.Run(script, out var _);
            var logpath = ToolWs.ConfigLog(id);
            using var reader = logpath.AsciLineReader();
            var line = AsciLine.Empty;
            while(reader.Next(out line))
            {
                Write(line.Format());
            }

            return result;
        }

        [CmdOp("toolbox/help")]
        protected void ShowToolHelp(CmdArgs args)
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

        [CmdOp("toolbox/settings")]
        Outcome ShowToolSettings(CmdArgs args)
        {
            var id = tool(args);
            var src = ToolWs.Config(id);
            if(!src.Exists)
                return (false,FS.missing(src));
            iter(ToolWs.settings(src), setting => Write(setting));
            return true;
        }

        [CmdOp("toolbox/docs")]
        protected Outcome ToolDocs(CmdArgs args)
        {
            var tool = (ToolId)arg(args,0).Value;
            var path = FS.FilePath.Empty;
            if(args.Length > 1)
                path = ToolWs.Service.ToolDocs(tool) + FS.file(arg(args,1));
            else
                path = ToolWs.Service.ToolDocs(tool) + FS.file(tool.Format(), FS.Help);

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