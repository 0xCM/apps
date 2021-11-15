//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a variable-dependent typed expression
    /// </summary>
    /// <typeparam name="T">The operand type</typeparam>
    public sealed class VariedExpr<T> : IVariedExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// A variable-dependent expression
        /// </summary>
        public ILogixExpr<T> BaseExpr {get;}

        /// <summary>
        /// The variables upon which the expression depends
        /// </summary>
        public IVarExpr<T>[] Vars {get;}

        [MethodImpl(Inline)]
        public VariedExpr(ILogixExpr<T> baseExpr, params VariableExpr<T>[] variables)
        {
            BaseExpr = baseExpr;
            Vars = variables;
        }

        [MethodImpl(Inline)]
        public void SetVars(params T[] values)
            => VariedExpr.Set(this, values.Map(v => (new LiteralExpr<T>(v) as ILiteralExpr<T>)));

        [MethodImpl(Inline)]
        public void SetVars(params ILogixExpr<T>[] values)
            => VariedExpr.Set(this,values);

        public string Format()
            => string.Empty;

        [MethodImpl(Inline)]
        public void SetVars(params IVarExpr<T>[] values)
            => VariedExpr.Set(this,values);
    }
}