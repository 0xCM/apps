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
        public Identifier Name {get;}

        public Constant<T> Value {get;}

        [MethodImpl(Inline)]
        public Literal(Identifier name, Constant<T> value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => string.Format("{0} = {1}", Name, Value.Format());

        public override string ToString()
            => Format();
    }
}