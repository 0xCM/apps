//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiArityKind;

    /// <summary>
    /// Classifies generic operations of arity 0
    /// </summary>
    public readonly struct A0<T> : ILiteralKind<A0,K,T> {}

    /// <summary>
    /// Classifies parametric operations of arity 1
    /// </summary>
    public readonly struct A1<T> : ILiteralKind<A1,K,T> {}

    /// <summary>
    /// Classifies parametric operations of arity 2
    /// </summary>
    public readonly struct A2<T> : ILiteralKind<A2,K,T> {}

    /// <summary>
    /// Classifies parametric operations of arity 3
    /// </summary>
    public readonly struct A3<T> : ILiteralKind<A3,K,T> {}

    /// <summary>
    /// Classifies operations of arity 0
    /// </summary>
    public readonly struct A0 : ILiteralKind<A0,K>
    {
        public K Class => K.Nullary;
    }

    /// <summary>
    /// Classifies operations of arity 0
    /// </summary>
    public readonly struct A1 : ILiteralKind<A1,K>
    {
        public K Class => K.Unary;
    }

    /// <summary>
    /// Classifies operations of arity 0
    /// </summary>
    public readonly struct A2 : ILiteralKind<A2,K>
    {
        public K Class => K.Binary;
    }

    /// <summary>
    /// Classifies operations of arity 3
    /// </summary>
    public readonly struct A3 : ILiteralKind<A3,K>
    {
        public K Class => K.Ternary;
    }
}