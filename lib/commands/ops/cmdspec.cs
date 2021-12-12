//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using SQ = SymbolicQuery;

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
                var name = text.format(SQ.left(src,i));
                var _args = text.format(SQ.right(src,i)).Split(Chars.Space);
                return new CmdSpec(name, args(_args));
            }
        }
    }
}