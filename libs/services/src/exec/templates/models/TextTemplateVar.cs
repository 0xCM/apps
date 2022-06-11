//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class TextTemplateVar : ITextVar
    {
        public static VarKind Kind = new VarKind();

        public sealed class VarKind : TextVarExpr<VarKind>
        {
            public override Fence<char> Fence
                => ((char)SymNotKind.Lt, (char)SymNotKind.Gt);
        }

        public readonly VarSymbol Name;

        public string Value;

        [MethodImpl(Inline)]
        public TextTemplateVar(string name)
        {
            Name = name;
            Value = EmptyString;
        }

        [MethodImpl(Inline)]
        public TextTemplateVar(string name, string val)
        {
            Name = name;
            Value = val;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => text.empty(Value);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => text.nonempty(Value);
        }

        VarSymbol IVar.Name
            => Name;

        string IVar<string>.Value
            => Value;

        ITextVarExpr ITextVar.VarExpr
            => Kind;

        public string Format()
            => TextExpr.FormatVariable(this);

        public override string ToString()
            => Format();
    }
}