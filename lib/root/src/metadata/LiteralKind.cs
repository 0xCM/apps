//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a <see cref='PrimalKind'/> subset that corresponds to primal types that can be used as compile-time literals
    /// </summary>
    public enum LiteralKind : byte
    {
        None = 0,

        /// <summary>
        /// An alias for <see cref='PrimalKind.U1'/>
        /// </summary>
        U1 = PrimalKind.U1,

        /// <summary>
        /// An alias for <see cref='PrimalKind.U8'/>
        /// </summary>
        U8 = PrimalKind.U8,

        /// <summary>
        /// An alias for <see cref='PrimalKind.U16'/>
        /// </summary>
        U16 = PrimalKind.U16,

        /// <summary>
        /// An alias for <see cref='PrimalKind.U32'/>
        /// </summary>
        U32 = PrimalKind.U32,

        /// <summary>
        /// An alias for <see cref='PrimalKind.U64'/>
        /// </summary>
        U64 = PrimalKind.U64,

        /// <summary>
        /// An alias for <see cref='PrimalKind.I8'/>
        /// </summary>
        I8 = PrimalKind.I8,

        /// <summary>
        /// An alias for <see cref='PrimalKind.I16'/>
        /// </summary>
        I16 = PrimalKind.I16,

        /// <summary>
        /// An alias for <see cref='PrimalKind.I32'/>
        /// </summary>
        I32 = PrimalKind.I32,

        /// <summary>
        /// An alias for <see cref='PrimalKind.I64'/>
        /// </summary>
        I64 = PrimalKind.I64,

        /// <summary>
        /// An alias for <see cref='PrimalKind.F32'/>
        /// </summary>
        F32 = PrimalKind.F32,

        /// <summary>
        /// An alias for <see cref='PrimalKind.F64'/>
        /// </summary>
        F64 = PrimalKind.F64,

        /// <summary>
        /// An alias for <see cref='PrimalKind.F128'/>
        /// </summary>
        F128 = PrimalKind.F128,

        /// <summary>
        /// An alias for <see cref='PrimalKind.C16'/>
        /// </summary>
        C16 = PrimalKind.C16,

        /// <summary>
        /// An alias for <see cref='PrimalKind.String'/>
        /// </summary>
        String = PrimalKind.String,
    }
}