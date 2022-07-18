//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    public class Scripts
    {
        public static CmdLine script(FS.FilePath path, ScriptKind kind)
        {
            return kind switch{
                ScriptKind.Cmd => cmd(path),
                ScriptKind.Ps => pwsh(path),
                _ => Z0.CmdLine.Empty
            };
        }

        public static CmdLine script(FS.FilePath path, ScriptKind kind, string args)
        {
            return kind switch{
                ScriptKind.Cmd => cmd(path, args),
                ScriptKind.Ps => pwsh(path, args),
                _ => Z0.CmdLine.Empty
            };
        }

        public static CmdLine pwsh(FS.FilePath src, string args)
            => string.Format("pwsh {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine cmd(FS.FilePath src, string args)
            => string.Format("cmd /c {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine pwsh(FS.FilePath src)
            => string.Format("pwsh {0}", src.Format(PathSeparator.BS));

        public static CmdLine cmd(FS.FilePath src)
            => string.Format("cmd /c {0}", src.Format(PathSeparator.BS));

        public static FS.FilePath path(IToolWs ws, Actor tool, ScriptId script, ScriptKind kind)
            => Scripts.tool(ws, tool, script, kind switch{
                ScriptKind.Cmd => FileKind.Cmd,
                ScriptKind.Ps => FileKind.Ps1,
                _ => FileKind.None
            });

        static FS.FilePath tool(IToolWs ws, Actor tool, ScriptId script, FileKind kind)
            => home(ws, tool) + FS.file(script.Format(), kind);

        static FS.FolderPath home(IToolWs ws, Actor tool)
            => ws.ScriptDir() + FS.folder(tool.Format()) + FS.folder(scripts);
    }
}