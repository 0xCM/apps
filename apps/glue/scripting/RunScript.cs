//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class RunScript : CmdReactor<RunScriptCmd>
    {
        protected override CmdResult Run(RunScriptCmd cmd)
        {
            var result = ScriptProcess.create(WinCmd.script(cmd.ScriptPath)).Wait();
            return Cmd.ok(cmd);
        }

        public ScriptProcess Launch(FS.FilePath path, string args)
        {
            var cmd = new CmdLine(string.Format("{0} \"{1}\"", path.Format(PathSeparator.BS), args));
            var flow = Wf.Running(string.Format("Launching {0}", cmd.Format()));
            var process = ScriptProcess.create(cmd);
            Wf.Ran(flow, string.Format("Launched {0}", process.ProcessId));
            return process;
        }
    }
}