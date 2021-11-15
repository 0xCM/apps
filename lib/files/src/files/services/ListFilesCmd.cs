//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Cmd(CmdName)]
    public struct ListFilesCmd : ICmd<ListFilesCmd>
    {
        public const string CmdName = "list-files";

        public string ListName;

        public FS.FolderPath SourceDir;

        public Index<FS.FileExt> Extensions;

        public bool FileUriMode;

        public FS.FilePath TargetPath;

        public uint EmissionLimit;

        public ListFormatKind ListFormat;
    }

    public enum ListFormatKind : byte
    {
        None,

        Csv,

        Markdown
    }
}