//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class FreeExpr
    {
        /// <summary>
        /// Characterizes an unmanaged expression
        /// </summary>
        [Free]
        public interface IFreeExpr : ITextual, INullity, Z0.IExpr
        {
            uint Size {get;}
        }

        /// <summary>
        /// Characterizes an unmanaged expression reification
        /// </summary>
        /// <typeparam name="F">The concrete expression type</typeparam>
        [Free]
        public interface IFreeExpr<F> : IFreeExpr
            where F : IFreeExpr<F>
        {
        }

        /// <summary>
        /// Characterizes an unmanaged expression reification with unmanaged <typeparamref name='T'/> operands
        /// </summary>
        /// <typeparam name="F">The expression kind</typeparam>
        /// <typeparam name="T">The operand type</typeparam>
        [Free]
        public interface IFreeExpr<F,T> : IFreeExpr<F>
            where F : IFreeExpr<F,T>
            where T : unmanaged
        {
            uint IFreeExpr.Size
                => size<T>();
        }

        /// <summary>
        /// Characterizes a kinded unmanaged expression reification with unmanaged <typeparamref name='T'/> operands
        /// </summary>
        /// <typeparam name="F">The expression kind</typeparam>
        /// <typeparam name="T">The operand type</typeparam>
        [Free]
        public interface IFreeExpr<F,K,T> : IFreeExpr<F,T>, IKinded<K>
            where F : IFreeExpr<F,T>
            where T : unmanaged
            where K : unmanaged
        {

        }
    }
}