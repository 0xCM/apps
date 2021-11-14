//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    public struct VcInfo
    {
        public FS.FolderPath VsRoot;

        public FS.FolderPath ToolRoot;

        public VersionSpec Version;

        public FS.FolderPath ToolVersionRoot;

        public static VcInfo Empty
            => default;

        public bool IsEmpty
            => ToolRoot.IsEmpty;
    }
}