//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Keyword : ITerminalExpr<Label>
    {
        public Label Value {get;}

        [MethodImpl(Inline)]
        public unsafe Keyword(string src)
            => Value = src;

        [MethodImpl(Inline)]
        public string Format()
            => Value.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Keyword(string name)
            => new Keyword(name);
    }
}