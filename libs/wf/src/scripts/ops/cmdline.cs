//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CmdScripts
    {
        public static CmdLine cmdline(FS.FilePath path, ScriptKind kind, string args)
        {
            return kind switch{
                ScriptKind.Cmd => cmd(path, args),
                ScriptKind.Ps => pwsh(path, args),
                _ => Z0.CmdLine.Empty
            };
        }

        public static CmdLine cmdline(FS.FilePath path, ScriptKind kind)
        {
            return kind switch{
                ScriptKind.Cmd => cmd(path),
                ScriptKind.Ps => pwsh(path),
                _ => Z0.CmdLine.Empty
            };
        }
    }
}