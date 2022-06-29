//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using G = ApiGranules;

    public class Toolsets : WfSvc<Toolsets>
    {
        ToolBox ToolBox => Wf.ToolBox();

        OmniScript OmniScript => Wf.OmniScript();

        public Settings Config(FS.FilePath src)
            => Settings.config(src);

        public ConstLookup<ToolId,ToolHelpDoc> LoadHelpDocs(FS.FolderPath home)
        {
            var dst = new Lookup<ToolId,ToolHelpDoc>();
            var src = ToolBox.CalcHelpPaths(home).Entries;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(src,i);
                dst.Include(entry.Key, new ToolHelpDoc(entry.Key, entry.Value));
            }
            return dst.Seal();
        }

        public Index<ToolHelpDoc> EmitHelp(FS.FolderPath home)
        {
            var result = Outcome.Success;
            var paths = ToolBox.CalcHelpPaths(home);
            var commands = ToolBox.BuildHelpCommands(home);
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