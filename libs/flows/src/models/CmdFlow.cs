//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Record(TableId)]
    public struct CmdFlow
    {
        public static ReadOnlySpan<CmdFlow> parse(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            var counter = 0u;
            var dst = span<CmdFlow>(count);
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
                            seek(dst,counter++) = new CmdFlow(tool, FS.path(a), FS.path(b));
                    }
                }
            }

            return slice(dst,0,counter);
        }

        public const string TableId = "cmd.flow";

        public const byte FieldCount = 5;

        [Render(24)]
        public Tool Tool;

        [Render(60)]
        public @string SourceName;

        [Render(60)]
        public @string TargetName;

        [Render(80)]
        public FS.FilePath SourcePath;

        [Render(1)]
        public FS.FilePath TargetPath;

        [MethodImpl(Inline)]
        public CmdFlow(Tool tool, FS.FilePath src, FS.FilePath dst)
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

        public static CmdFlow Empty
        {
            [MethodImpl(Inline)]
            get => new CmdFlow(Tool.Empty, FS.FilePath.Empty, FS.FilePath.Empty);
        }
    }
}