//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a <see cref='ClrPrimitiveKind'/> subset that corresponds to primal types that can be used as compile-time literals
    /// </summary>
    [SymSource("clr")]
    public enum ClrLiteralKind : byte
    {
        None = 0,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.U1'/>
        /// </summary>
        U1 = ClrPrimitiveKind.U1,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.U8'/>
        /// </summary>
        U8 = ClrPrimitiveKind.U8,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.U16'/>
        /// </summary>
        U16 = ClrPrimitiveKind.U16,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.U32'/>
        /// </summary>
        U32 = ClrPrimitiveKind.U32,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.U64'/>
        /// </summary>
        U64 = ClrPrimitiveKind.U64,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.I8'/>
        /// </summary>
        I8 = ClrPrimitiveKind.I8,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.I16'/>
        /// </summary>
        I16 = ClrPrimitiveKind.I16,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.I32'/>
        /// </summary>
        I32 = ClrPrimitiveKind.I32,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.I64'/>
        /// </summary>
        I64 = ClrPrimitiveKind.I64,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.F32'/>
        /// </summary>
        F32 = ClrPrimitiveKind.F32,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.F64'/>
        /// </summary>
        F64 = ClrPrimitiveKind.F64,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.F128'/>
        /// </summary>
        F128 = ClrPrimitiveKind.F128,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.C16'/>
        /// </summary>
        C16 = ClrPrimitiveKind.C16,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.String'/>
        /// </summary>
        String = ClrPrimitiveKind.String,
    }
}