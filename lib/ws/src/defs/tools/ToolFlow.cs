//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ToolFlow
    {
        public readonly text15 Tool;

        public readonly FS.FilePath Source;

        public readonly FS.FilePath Target;

        [MethodImpl(Inline)]
        public ToolFlow(text15 tool, FS.FilePath src, FS.FilePath dst)
        {
            Tool = tool;
            Source = src;
            Target = dst;
        }

        public string Format()
            => string.Format("{0}:{1} -> {2}", Tool, Source, Target);

        public override string ToString()
            => Format();

        public static ToolFlow Empty
        {
            get => new ToolFlow(text15.Empty, FS.FilePath.Empty, FS.FilePath.Empty);
        }
    }
}