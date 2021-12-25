//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public struct WsVars
    {
        public static WsVars create()
            => new WsVars();

        public FS.FolderPath SrcDir;

        public FS.FileName SrcFile;

        public FS.FolderPath DstDir;

        public string SrcId;

        public CmdVars ToCmdVars()
            => Cmd.vars(
            (nameof(SrcDir), SrcDir.IsNonEmpty ? SrcDir.Format(PathSeparator.BS) : EmptyString),
            (nameof(SrcFile), SrcFile.IsNonEmpty ? SrcFile.Format() : EmptyString),
            (nameof(DstDir), DstDir.IsNonEmpty ? DstDir.Format(PathSeparator.BS) : EmptyString),
            (nameof(SrcId), SrcId ?? EmptyString)
            );
    }
}