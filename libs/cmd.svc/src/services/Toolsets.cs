//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class Toolsets : WfSvc<Toolsets>
    {
        ToolBox ToolBox => Wf.ToolBox();

        OmniScript OmniScript => Wf.OmniScript();

        public SettingLookup Config(FS.FilePath src)
            => Settings.lookup(src,Chars.Colon);

        public ConstLookup<ToolIdOld,ToolHelpDoc> LoadHelpDocs(IDbSources src)
        {
            var dst = dict<ToolIdOld,ToolHelpDoc>();
            var files = src.Files(FileKind.Help);
            iter(files, file =>{
                var fmt = file.FileName.Format();
                var i = text.index(fmt, Chars.Dot);
                if(i > 0)
                {
                    var tool = text.left(fmt,i);
                    dst.TryAdd(tool, new ToolHelpDoc(tool, file, file.ReadAsci()));
                }
            });
            return dst;
        }

        public Index<ToolHelpDoc> EmitHelp(IToolWs ws)
        {
            var result = Outcome.Success;
            var paths = ToolBox.CalcHelpPaths(ws.Home);
            var commands = ToolBox.BuildHelpCommands(ws);
            var count = commands.Length;
            var docs = list<ToolHelpDoc>();
            for(var i=0; i<count; i++)
            {
                ref readonly var cmd = ref commands[i];
                var tool = cmd.Tool;
                result = OmniScript.Run(cmd.Command, CmdVars.Empty, out var response);
                if(result.Fail)
                {
                    Error(result.Message);
                    continue;
                }

                Babble(string.Format("Executed '{0}'", cmd.Format()));

                if(paths.Find(tool, out var path))
                {
                    var length = response.Length;
                    var emitting = EmittingFile(path);
                    using var writer = path.UnicodeWriter();
                    for(var j=0; j<length; j++)
                        writer.WriteLine(skip(response, j).Content);
                    EmittedFile(emitting,length);

                    docs.Add(new ToolHelpDoc(tool,path));
                }
                else
                    Warn(string.Format("{0} has no help path", tool));
            }

            return docs.ToArray();
        }
    }
}