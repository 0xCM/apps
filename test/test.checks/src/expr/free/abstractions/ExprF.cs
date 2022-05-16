//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class FreeExpr
    {
        /// <summary>
        /// Unmanaged expression root
        /// </summary>
        /// <typeparam name="F">The concrete expression</typeparam>
        [Free]
        public abstract class Expr<F> : IFreeExpr<F>
            where F : Expr<F>
        {
            public abstract uint Size {get;}
        }
    }
}