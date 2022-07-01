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
        /// <typeparam name="T">The operand type</typeparam>
        [Free]
        public abstract class Expr<F,T> : Expr<F>
            where F : Expr<F,T>
            where T : unmanaged
        {

        }
    }
}