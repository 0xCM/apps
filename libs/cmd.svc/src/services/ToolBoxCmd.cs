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
        Settings UpdateToolEnv()
        {
            var path = ToolWs.BoolBox.Path(FS.file("show-env-config", FS.Cmd));
            var cmd = CmdScript.cmdline(path.Format(PathSeparator.BS));
            return AppSettings.Load(OmniScript.RunCmd(cmd));
        }

    }
}
