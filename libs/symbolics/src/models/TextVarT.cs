//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TextVar<E> : ITextVar
        where E : IEquatable<E>, IComparable<E>, ITextVarExpr, new()
    {
        public Name Name {get;}

        public E VarExpr {get;}

        public string Value;

        [MethodImpl(Inline)]
        public TextVar(string name, E kind)
        {
            Name = name;
            VarExpr = kind;
            Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public TextVar(string name, E kind, string val)
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

        @string ISysVar<@string>.Value
            => Value;

        ITextVarExpr ITextVar.Expr
            => VarExpr;

        public string Format()
            => TextExpr.format(this);

        public override string ToString()
            => Format();
    }
}