//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines a typed comparison expression
    /// </summary>
    public readonly struct ComparisonExpr<T> : IComparisonExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The operator kind
        /// </summary>
        public ApiComparisonClass ComparisonKind {get;}

        /// <summary>
        /// The left expression
        /// </summary>
        public ILogixExpr<T> LeftArg {get;}

        /// <summary>
        /// The right expression
        /// </summary>
        public ILogixExpr<T> RightArg {get;}

        /// <summary>
        /// The variables upon which the operands depend
        /// </summary>
        Index<IVarExpr<T>> _Vars {get;}

        [MethodImpl(Inline)]
        public ComparisonExpr(ApiComparisonClass kind, ILogixExpr<T> lhs, ILogixExpr<T> rhs, params IVarExpr<T>[] vars)
        {
            ComparisonKind = kind;
            LeftArg = lhs;
            RightArg = rhs;
            _Vars = vars;
        }

        public uint VarCount
        {
            [MethodImpl(Inline)]
            get => _Vars.Count;
        }

        public IVarExpr<T>[] Vars
        {
            [MethodImpl(Inline)]
            get => _Vars.Storage;
        }

        public void SetVars(params ILogixExpr<T>[] values)
        {
            var count = min(_Vars.Length, values.Length);
            if(count != 0)
            {
                ref readonly var src = ref first(values);
                for(var i=0; i<count; i++)
                    _Vars[i].Set(skip(values,i));
            }
        }

        public void SetVars(params T[] values)
        {
            var count = min(_Vars.Length, values.Length);
            if(count != 0)
            {
                ref readonly var src = ref first(values);
                for(var i=0; i<count; i++)
                    _Vars[i].Set(skip(values,i));
            }
        }

        [MethodImpl(Inline)]
        public void SetVar(int index, T value)
            => _Vars[index].Set(value);

        public string Format()
            => ComparisonKind.Format(LeftArg, RightArg);

        public override string ToString()
            => Format();
    }
}