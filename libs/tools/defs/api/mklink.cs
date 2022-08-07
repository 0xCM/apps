//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Tools
    {
        public static MkLinkCmd mklink(FS.FolderPath src, FS.FolderPath dst)
            => new MkLinkCmd(MkLinkCmd.Flag.Directory, src.ToUri(), dst.ToUri());
    }
}