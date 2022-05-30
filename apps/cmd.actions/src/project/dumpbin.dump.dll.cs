//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("tool/config")]
        public Outcome ConfigureTool(CmdArgs args)
        {
            var result = Outcome.Success;
            ToolId tool = arg(args,0).Value;
            var script = Tools.ConfigScript(tool);
            result = OmniScript.Run(script, out var _);
            var logpath = Tools.ConfigLog(tool);
            using var reader = logpath.AsciLineReader();
            while(reader.Next(out var line))
            {
                Write(line.Format());
            }

            return result;
        }

        [CmdOp("dumpbin/dump/dll")]
        Outcome DumpDll(CmdArgs args)
            => DumpBin.DumpModules(Project(), FileModuleKind.Dll);
   }
}