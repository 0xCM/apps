//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WinCmd
    {
        [Op]
        public static CmdLine dir(FS.FolderPath src)
            => string.Format("cmd /c dir {0} /s/b", src.Format(PathSeparator.BS));

        [Op]
        public static CmdLine script(FS.FilePath src)
            => string.Format("cmd /c {0}", src.Format(PathSeparator.BS));

        public static CmdLine script(string src)
            => script(FS.path(src));

        public static CmdLine dir(string src)
            => dir(FS.dir(src));

    }
}