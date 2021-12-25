//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ToolCmdFlow
    {
        public readonly text31 Actor;

        public readonly FS.FilePath Source;

        public readonly FS.FilePath Target;

        [MethodImpl(Inline)]
        public ToolCmdFlow(text31 tool, FS.FilePath src, FS.FilePath dst)
        {
            Actor = tool;
            Source = src;
            Target = dst;
        }

        public string Format()
            => string.Format("{0}:{1} -> {2}", Actor, Source, Target);

        public override string ToString()
            => Format();

        public static implicit operator CmdFlow<FS.FilePath>(ToolCmdFlow src)
            => new CmdFlow<FS.FilePath>(src.Actor, src.Source, src.Target);

        public static ToolCmdFlow Empty
        {
            [MethodImpl(Inline)]
            get => new ToolCmdFlow(text31.Empty, FS.FilePath.Empty, FS.FilePath.Empty);
        }
    }
}