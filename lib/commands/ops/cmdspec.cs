//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Cmd
    {
        [Op, MethodImpl(Inline)]
        public static CmdSpec cmdspec(string name, CmdArgs args)
            => new CmdSpec(name, args);

        [Op]
        public static CmdSpec cmdspec(ReadOnlySpan<char> src)
        {
            var i = SQ.index(src, Chars.Space);
            if(i < 0)
                return new CmdSpec(text.format(src), CmdArgs.Empty);
            else
            {
                var name = text.format(text.left(src,i));
                var _args = text.format(text.right(src,i)).Split(Chars.Space);
                return new CmdSpec(name, args(_args));
            }
        }
    }
}