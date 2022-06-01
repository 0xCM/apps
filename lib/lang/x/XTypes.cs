//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        [MethodImpl(Inline)]
        public static BinaryOp<T> ToBinaryOp<T>(this System.Func<T,T,T> f)
            => new BinaryOp<T>(f);

        public static TypeSpec Spec(this Type src)
            => TypeSyntax.infer(src);

        public static Index<TypeSpec> Specs(this Type[] src)
            => src.Map(TypeSyntax.infer);
    }
}