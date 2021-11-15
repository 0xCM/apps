//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Id = ApiClassKind;

    /// <summary>
    /// Classifies binary boolean and bitwise logical operations
    /// </summary>
    [ApiClass]
    public enum ApiBitLogicClass : ushort
    {
        /// <summary>
        /// The empty identity which, unfortunately conflicts with the inescapable defintion of 'False'
        /// </summary>
        None = 0b000,

        /// <summary>
        /// Classifies a logical  binary operator false(a,b) := bv(0000)
        /// </summary>
        False = Id.None,

        /// <summary>
        /// Classifies a logical binary operator and(a,b) := bv(1000)
        /// </summary>
        And = Id.And,

        /// <summary>
        /// Classifies a logical binary operator cnotimply(a,b) := and(a, ~b) = bv(0010)
        /// </summary>
        CNonImpl = Id.CNonImpl,

        /// <summary>
        /// Classifies a logical binary operator left(a,b) := a = bv(1010)
        /// </summary>
        LProject = Id.LProject,

        /// <summary>
        /// Identifies a logical binary operator notimply(a,b) := and(~a, b) = bv(0100)
        /// </summary>
        NonImpl = Id.NonImpl,

        /// <summary>
        /// Classifies a logical binary operator right(a,b) := b = bv(1100)
        /// </summary>
        RProject = Id.RProject,

        /// <summary>
        /// Classifies a logical binary operator xor(a,b) := bv(0110)
        /// </summary>
        Xor = Id.Xor,

        /// <summary>
        /// Classifies a logical binary operator or(a,b) := bv(1110)
        /// </summary>
        Or = Id.Or,

        /// <summary>
        /// Classifies a logical binary operator that computes nor(a,b) := not(or(a,b)) = bv(0001)
        /// </summary>
        Nor = Id.Nor,

        /// <summary>
        /// Classifies a binary operator xnor(a,b) := not(xor(a,b)) = bv(1001)
        /// </summary>
        Xnor = Id.Xnor,

        /// <summary>
        /// Classifies a logical binary operator rnot(a,b) := not(b) = bv(0011)
        /// </summary>
        RNot = Id.RNot,

        /// <summary>
        /// Classifies a logical binary operator imply(a,b) := or(a, not(b)) = bv(1011)
        /// </summary>
        Impl = Id.Impl,

        /// <summary>
        /// Classifies a logical binary operator lnot(a,b) := not(a) = bv(0101)
        /// </summary>
        LNot = Id.LNot,

        /// <summary>
        /// Classifies a logical binary operator cimpl(a,b) := or(not(a), b) = bv(1101)
        /// </summary>
        CImpl = Id.CImpl,

        /// <summary>
        /// Classifies a logical binary operator nand(a,b) := not(and(a,b)) = bv(0111)
        /// </summary>
        Nand = Id.Nand,

        /// <summary>
        /// Classifies a logical binary operator true(a,b) = bv(1111)
        /// </summary>
        True = Id.True,

        /// <summary>
        /// Classifies a logical unary negation operator
        /// </summary>
        Not = Id.Not,

        /// <summary>
        /// Classifies a ternary select operator
        /// </summary>
        Select = Id.Select,

        XorNot = Id.XorNot
    }
}