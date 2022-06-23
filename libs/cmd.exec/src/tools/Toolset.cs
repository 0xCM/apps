//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class Toolset : WfSvc<Toolset>
    {
        ToolBox ToolBox => Wf.ToolBox();

        FS.FolderPath Root;

        ConstLookup<ToolId,ToolHelpDoc> HelpDocs;

        OmniScript OmniScript => Wf.OmniScript();

        public Toolset()
        {

        }

        protected override void Initialized()
        {
            Root = AppDb.Toolbase().Targets("llvm").Root;
            InitHelpDocs();
        }

        void InitHelpDocs()
        {
            var dst = new Lookup<ToolId,ToolHelpDoc>();
            var src = ToolBox.CalcHelpPaths(Root).Entries;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(src,i);
                dst.Include(entry.Key, new ToolHelpDoc(entry.Key, entry.Value));
            }
            HelpDocs = dst.Seal();
        }

        public Index<ToolHelpDoc> Help()
        {
            var dst = list<ToolHelpDoc>();
            var tools = HelpDocs.Keys;
            foreach(var tool in tools)
            {
                if(HelpDocs.Find(tool, out var doc))
                    dst.Add(doc.Load());
            }
            return dst.ToArray();
        }

        public ToolHelpDoc Help(ToolId tool)
        {
            if(HelpDocs.Find(tool, out var doc))
                return doc.Load();
            else
                return ToolHelpDoc.Empty;
        }

        public Outcome Help(ToolId tool, out ToolHelpDoc doc)
            => HelpDocs.Find(tool, out doc);

        public Index<ToolHelpDoc> EmitHelp()
        {
            var result = Outcome.Success;
            var paths = ToolBox.CalcHelpPaths(Root);
            var commands = ToolBox.BuildHelpCommands(Root);
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