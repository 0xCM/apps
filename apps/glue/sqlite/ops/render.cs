//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Sqlite
    {
        public static void render(Command src, ITextEmitter dst)
            => dst.AppendLine(src.Content);

        public static void render(ReadOnlySpan<Command> src, ITextEmitter dst)
            => iter(src, cmd => render(cmd,dst));
    }
}