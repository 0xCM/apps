//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Record(TableId)]
    public struct ToolCmdFlow
    {
        public static ReadOnlySpan<ToolCmdFlow> parse(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var counter = 0u;
            var dst = span<ToolCmdFlow>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(src,i);
                if(line.IsEmpty)
                    continue;

                var content = line.Content;
                var j = text.index(content, Chars.Colon);
                if(j >= 0)
                {
                    ToolId tool = text.left(content, j);
                    var flow = text.unfence(text.right(content,j), RenderFence.Bracketed);

                    j = text.index(flow, "--");
                    if(j == NotFound)
                        j = text.index(flow, "->");

                    if(j>=0)
                    {
                        var a = text.left(flow,j).Trim();
                        var b = text.right(flow,j+2).Trim();
                        if(nonempty(a) && nonempty(b))
                            seek(dst,counter++) = new ToolCmdFlow(tool, FS.path(a), FS.path(b));
                    }
                }
            }

            return slice(dst,0,counter);
        }

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