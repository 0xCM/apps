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
    ///  Defines a typed expression over a variable sequence of natural length
    /// </summary>
    /// <typeparam name="N">The sequence length type</typeparam>
    /// <typeparam name="T">The operand type</typeparam>
    public sealed class VariedExpr<N,T>  : IVariedExpr<T>
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        public ILogixExpr<T> BaseExpr {get;}

        public IVarExpr<T>[] Vars {get;}

        [MethodImpl(Inline)]
        public VariedExpr(ILogixExpr<T> baseExpr, params IVarExpr<T>[] variables)
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
   }
}