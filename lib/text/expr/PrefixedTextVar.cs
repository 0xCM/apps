//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public class PrefixedTextVar : ITextVar
    {
        public string Value;

        public string Name {get;}

        string IVar<string>.Value
            => Value;

        public VarKind Kind {get;}

        ITextVarKind ITextVar.VarKind
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
            => TextExpr.FormatVariable(this);

        public sealed class VarKind : TextVarKind<VarKind>
        {
            public override char Prefix {get;}

            public VarKind(char prefix)
            {
                Prefix = prefix;
            }
        }
    }
}