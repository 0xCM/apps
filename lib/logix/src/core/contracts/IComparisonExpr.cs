//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a claim that two variable-dependent comparison expressions are equivalent
    /// </summary>
    public interface IComparisonExpr : ILogicExpr
    {
        /// <summary>
        /// The left expression
        /// </summary>
        ILogicExpr Lhs {get;}

        /// <summary>
        /// The right expression
        /// </summary>
        ILogicExpr Rhs {get;}

        /// <summary>
        /// Variables upon which the expression depends
        /// </summary>
        ILogicVarExpr[] Vars {get;}
    }

    /// <summary>
    /// Characterizes a claim that two variable-dependent typed comparison expressions are equivalent
    /// </summary>
    public interface IComparisonExpr<T> : ILogixExpr<T>
        where T : unmanaged
    {
        /// <summary>
        /// The left expression
        /// </summary>
        ILogixExpr<T> LeftArg {get;}

        /// <summary>
        /// The right expression
        /// </summary>
        ILogixExpr<T> RightArg {get;}

        /// <summary>
        /// Variables upon which the expression depends
        /// </summary>
        IVarExpr<T>[] Vars {get;}

        /// <summary>
        /// The sort of comparison to be applied
        /// </summary>
        ApiComparisonClass ComparisonKind {get;}
    }

    /// <summary>
    /// Characterizes a comparison expression that evaluates as a predicate where a single bit, or bitvector,
    /// characterizes the evaluation result. This is in contradistinction to the more general typed comparison expression
    /// where the result is predicated on the type and may be scalar/vector/etc in nature
    /// </summary>
    /// <typeparam name="T">The type over which the comparison is defined</typeparam>
    public interface IComparisonPredExpr<T> : IComparisonExpr<T>
        where T : unmanaged
    {

    }
}