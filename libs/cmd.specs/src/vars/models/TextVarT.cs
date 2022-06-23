//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TextVar<K> : ITextVar<K>
        where K : ITextVarExpr
    {
        public Name Name {get;}

        public K VarExpr {get;}

        public string Value;

        [MethodImpl(Inline)]
        public TextVar(string name, K kind)
        {
            Name = name;
            VarExpr = kind;
            Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public TextVar(string name, K kind, string val)
        {
            Name = name;
            VarExpr = kind;
            Value = val;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        string IVar<string>.Value
            => Value;

        public string Format()
            => TextExpr.FormatVariable(this);

        public override string ToString()
            => Format();
    }
}