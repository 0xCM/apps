//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using static Root;

    public class TextVar
    {
        public readonly string Name;

        public string Value;

        [MethodImpl(Inline)]
        public TextVar(string name)
        {
            Name = name;
            Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public TextVar(string name, string val)
        {
            Name = name;
            Value = val;
        }

        public string Format()
            => text.empty(Value) ? string.Format("$({0})", Name) : Value;

        public override string ToString()
            => Format();
    }
}