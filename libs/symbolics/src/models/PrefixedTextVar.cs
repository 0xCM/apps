//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a <see cref='ITextVar'/> that has a prefixed identifier
    /// </summary>
    public class PrefixedTextVar : ITextVar
    {
        public string Value;

        public Name Name {get;}

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Name.Hash;
        }

        @string ISysVar<@string>.Value
            => Value;

        public VarKind Kind {get;}

        ITextVarExpr ITextVar.Expr
            => Kind;

        public PrefixedTextVar(char prefix, string name)
        {
            Name = name;
            Kind = new VarKind(prefix);
            Value = EmptyString;
        }

        public PrefixedTextVar(char prefix, string name, string value)
            : this(prefix,name)
        {
            Name = name;
            Kind = new VarKind(prefix);
            Value = value;
        }

        public string Format()
            => TextExpr.format(this);

        public sealed class VarKind : TextVarExpr<VarKind>
        {
            public override char Prefix {get;}

            public VarKind(char prefix)
            {
                Prefix = prefix;
            }
        }
    }
}