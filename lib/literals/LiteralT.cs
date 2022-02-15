//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a literal value which, by definition, is a named constant
    /// </summary>
    [StructLayout(LayoutKind.Sequential), DataType(TypeSyntax.Literal)]
    public readonly struct Literal<T> : ILiteralExpr<T>
    {
        public string Name {get;}

        public Constant<T> Value {get;}

        [MethodImpl(Inline)]
        public Literal(string name, Constant<T> value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => ExprFormatters.format(this);

        public override string ToString()
            => Format();
    }
}