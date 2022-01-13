//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Record(TableId)]
    public struct ToolCmdFlow
    {
        public const string TableId = "cmd.flow";

        public const byte FieldCount = 5;

        public Tool Tool;

        public @string SourceName;

        public @string TargetName;

        public FS.FilePath SourcePath;

        public FS.FilePath TargetPath;

        [MethodImpl(Inline)]
        public ToolCmdFlow(Tool tool, FS.FilePath src, FS.FilePath dst)
        {
            Tool = tool;
            SourceName = src.FileName.Format();
            TargetName = dst.FileName.Format();
            SourcePath = src;
            TargetPath = dst;
        }

        public string Format()
            => string.Format("{0}:{1} -> {2}", Tool, SourceName, TargetName);

        public override string ToString()
            => Format();

        public static implicit operator CmdFlow<FS.FilePath>(ToolCmdFlow src)
            => new CmdFlow<FS.FilePath>(src.Tool, src.SourcePath, src.TargetPath);

        public static ToolCmdFlow Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmdFlow(Tool.Empty, FS.FilePath.Empty, FS.FilePath.Empty);
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{24,60,60,80,1};
    }
}