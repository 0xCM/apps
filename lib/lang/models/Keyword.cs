//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LangKeyword : ITerminalExpr<Label>
    {
        public Label Value {get;}

        [MethodImpl(Inline)]
        public unsafe LangKeyword(string src)
            => Value = src;

        [MethodImpl(Inline)]
        public string Format()
            => Value.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator LangKeyword(string name)
            => new LangKeyword(name);
    }
}