//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public class TextVar<K> : ITextVar<K>
        where K : ITextVarKind
    {
        public string Name {get;}

        public K VarKind {get;}

        public string Value;

        [MethodImpl(Inline)]
        public TextVar(string name, K kind)
        {
            Name = name;
            VarKind = kind;
            Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public TextVar(string name, K kind, string val)
        {
            Name = name;
            VarKind = kind;
            Value = val;
        }

        string IVar<string>.Value
            => Value;

        public string Format()
            => TextExpr.FormatVariable(this);

        public override string ToString()
            => Format();
    }
}