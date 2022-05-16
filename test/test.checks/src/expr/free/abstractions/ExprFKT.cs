//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class FreeExpr
    {
        /// <summary>
        /// A kinded Unmanaged expression root
        /// </summary>
        /// <typeparam name="F">The concrete expression</typeparam>
        /// <typeparam name="K">The expression kind</typeparam>
        /// <typeparam name="T">The operand type</typeparam>
        [Free]
        public abstract class Expr<F,K,T> : Expr<F,T>, IFreeExpr<F,K,T>
            where F : Expr<F,K,T>
            where K : unmanaged
            where T : unmanaged
        {
            public abstract K Kind {get;}
        }
    }
}