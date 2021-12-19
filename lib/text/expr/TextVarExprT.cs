//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class TextVarExpr<T> : ITextVarExpr
        where T : TextVarExpr<T>
    {
        public virtual bool IsFenced => Fence.Left != AsciNull.Literal && Fence.Right != AsciNull.Literal;

        public virtual Fence<char> Fence => Fence<char>.Empty;

        public virtual char Prefix => AsciNull.Literal;

        public virtual bool IsPrefixed => Prefix != AsciNull.Literal;
    }
}