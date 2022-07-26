//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Scripts
    {
        public static CmdLine script(FS.FilePath path, ScriptKind kind)
        {
            return kind switch{
                ScriptKind.Cmd => Scripts.cmd(path),
                ScriptKind.Ps => Scripts.pwsh(path),
                _ => Z0.CmdLine.Empty
            };
        }

        public static CmdLine script(FS.FilePath path, ScriptKind kind, string args)
        {
            return kind switch{
                ScriptKind.Cmd => Scripts.cmd(path, args),
                ScriptKind.Ps => Scripts.pwsh(path, args),
                _ => Z0.CmdLine.Empty
            };
        }

        public static CmdLine cmd(string spec)
            => string.Format($"cmd.exe /c {spec}");

        public static CmdLine pwsh(FS.FilePath src, string args)
            => string.Format("pwsh.exe {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine cmd(FS.FilePath src, string args)
            => string.Format("cmd.exe /c {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine pwsh(FS.FilePath src)
            => string.Format("pwsh.exe {0}", src.Format(PathSeparator.BS));

        public static CmdLine cmd(FS.FilePath src)
            => string.Format("cmd.exe /c {0}", src.Format(PathSeparator.BS));

    }
}