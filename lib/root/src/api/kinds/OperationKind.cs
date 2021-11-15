//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using p = Pow2x16;

    /// <summary>
    /// Classifies an operation in various ways
    /// </summary>
    [Flags]
    public enum OperationKind : ushort
    {
        /// <summary>
        /// The empty class
        /// </summary>
        None = 0,

        /// <summary>
        /// Classifies operations of arity 0
        /// </summary>
        Nullary = p.P2ᐞ00,

        /// <summary>
        /// Classifies operations of arity 1
        /// </summary>
        Unary = p.P2ᐞ01,

        /// <summary>
        /// Classifies operations of arity 2
        /// </summary>
        Binary = p.P2ᐞ02,

        /// <summary>
        /// Classifies operations of arity 3
        /// </summary>
        Ternary = p.P2ᐞ03,

        /// <summary>
        /// Classifies operations with void return
        /// </summary>
        Action = p.P2ᐞ04,

        /// <summary>
        /// Classifies operations as those with non-void return
        /// </summary>
        Function = p.P2ᐞ05,

        /// <summary>
        /// Classifies functions for which operands and return type are homogenous
        /// </summary>
        Operator = p.P2ᐞ06,

        /// <summary>
        /// Classifies functions that return a system boolean value or a bit value
        /// </summary>
        Predicate = p.P2ᐞ07,

        /// <summary>
        /// Classifies functions that shift/rotate bits
        /// </summary>
        Shift = p.P2ᐞ08,

        /// <summary>
        /// Classifies system-level operations
        /// </summary>
        System = p.P2ᐞ09,

        /// <summary>
        /// The last pure classifier
        /// </summary>
        LastClass = System,

        /// <summary>
        /// Classifies actions that accept one argument
        /// </summary>
        Receiver = Nullary | Action,

        /// <summary>
        /// Classifies actions that accept one argument
        /// </summary>
        UnaryAction = Unary | Action,

        /// <summary>
        /// Classifies actions that accept two arguments
        /// </summary>
        BinaryAction = Binary | Action,

        /// <summary>
        /// Classifies actions that accept three arguments
        /// </summary>
        TernaryAction = Ternary | Action,

        /// <summary>
        /// Classifies functions that accept no arguments
        /// </summary>
        Emitter = Function | Nullary,

        /// <summary>
        /// Classifies functions that accept one argument
        /// </summary>
        UnaryFunc = Unary | Function,

        /// <summary>
        /// Classifies functions that accept two arguments
        /// </summary>
        BinaryFunc =  Binary | Function,

        /// <summary>
        /// Classifies functions that accept three arguments
        /// </summary>
        TernaryFunc = Ternary | Function,

        /// <summary>
        /// Classifies operators that accept one argument
        /// </summary>
        UnaryOp = Unary | Function | Operator,

        /// <summary>
        /// Classifies operators that accept two arguments
        /// </summary>
        BinaryOp = Binary | Function | Operator,

        /// <summary>
        /// Classifies operators that accept three arguments
        /// </summary>
        TernaryOp = Ternary | Function | Operator,

        /// <summary>
        /// Classifies shift functions that accept two argument types: the value to shift and the magnitude of the shift
        /// </summary>
        ShiftOp = Function | Operator,

        /// <summary>
        /// Classifies shift operators with two arguments
        /// </summary>
        UnaryShiftOp = ShiftOp | Unary,

        /// <summary>
        /// Classifies shift operators with three arguments
        /// </summary>
        BinaryShiftOp = ShiftOp | Unary,

        /// <summary>
        /// Classifies an operation as a unary predicate
        /// </summary>
        UnaryPredicate = Unary | Function | Predicate,

        /// <summary>
        /// Classifies an operation as a binary predicate
        /// </summary>
        BinaryPredicate = Binary | Function | Predicate,

        /// <summary>
        /// Classifies an operation as a ternary predicate
        /// </summary>
        TernaryPredicate = Ternary | Function | Predicate
    }
}