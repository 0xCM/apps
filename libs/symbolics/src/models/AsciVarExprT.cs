//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct AsciVarExpr<A> : IAsciVarExpr<A>
        where A : unmanaged, IAsciSeq<A>
    {
        public readonly VarName<A> VarName;

        public readonly AsciFence Fence;

        public readonly AsciSymbol Prefix;

        [MethodImpl(Inline)]
        public AsciVarExpr(A name)
        {
            VarName = name;
        }

        [MethodImpl(Inline)]
        public AsciVarExpr(A name, AsciSymbol prefix)
        {
            VarName = name;
            Prefix = prefix;
        }

        [MethodImpl(Inline)]
        public AsciVarExpr(A name, AsciFence fence)
        {
            VarName = name;
            Fence = fence;
        }

        [MethodImpl(Inline)]
        public AsciVarExpr(A name, AsciSymbol prefix, AsciFence fence)
        {
            VarName = name;
            Prefix = prefix;
            Fence = fence;
        }

        VarName<A> IAsciVarExpr<A>.VarName
            => VarName;

        AsciFence IAsciVarExpr.Fence
            => Fence;

        AsciSymbol IAsciVarExpr.Prefix
            => Prefix;
    }

    public abstract class AsciVarExpr<V,A>
        where A : unmanaged, IAsciSeq
        where V : AsciVarExpr<V,A>, new()
    {
        /// <summary>
        /// Specifies the variable fence, if any
        /// </summary>
        public virtual Fence<AsciSymbol> Fence => Fence<AsciSymbol>.Empty;

        /// <summary>
        /// Specifies the varible prefix, if any
        /// </summary>
        public virtual AsciSymbol Prefix => AsciNull.Literal;

        /// <summary>
        /// Indicates whether the variable is prefixed
        /// </summary>
        public bool IsPrefixed => Prefix != AsciNull.Literal;

        /// <summary>
        /// Indicates whether the variable is fenced
        /// </summary>
        public bool IsFenced => Fence.Left != AsciNull.Literal && Fence.Right != AsciNull.Literal;

    }
}