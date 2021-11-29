//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

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

    public record ListFilesResult : CmdResult<ListFilesCmd,FS.Files>
    {
        [MethodImpl(Inline)]
        public ListFilesResult(in ListFilesCmd cmd, FS.Files data)
        {
            Cmd = cmd;
            Payload = data;
            Succeeded = true;
            Message = EmptyString;
        }

       [MethodImpl(Inline)]
       public ListFilesResult(in ListFilesCmd cmd, TextBlock error)
        {
            Cmd = cmd;
            Payload = FS.Files.Empty;
            Succeeded = false;
            Message = error;
        }
    }

    public enum ListFormatKind : byte
    {
        None,

        Csv,

        Markdown
    }
}