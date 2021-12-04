//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Restricts the numeric kind classifier to reflect the numeric kinds
    /// that an Enum type may refine
    /// </summary>
    [SymSource("clr")]
    public enum ClrEnumKind : byte
    {
        None = 0,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.U8'/>
        /// </summary>
        [Symbol("u8", "Specifies an unsigned 8-bit refinement")]
        U8 = ClrPrimitiveKind.U8,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.U16'/>
        /// </summary>
        [Symbol("u16", "Specifies an unsigned 16-bit refinement")]
        U16 = ClrPrimitiveKind.U16,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.U32'/>
        /// </summary>
        [Symbol("u32", "Specifies an unsigned 32-bit refinement")]
        U32 = ClrPrimitiveKind.U32,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.U64'/>
        /// </summary>
        [Symbol("u64", "Specifies an unsigned 64-bit refinement")]
        U64 = ClrPrimitiveKind.U64,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.I8'/>
        /// </summary>
        [Symbol("i8", "Specifies a signed 8-bit refinement")]
        I8 = ClrPrimitiveKind.I8,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.I16'/>
        /// </summary>
        [Symbol("i16", "Specifies a signed 16-bit refinement")]
        I16 = ClrPrimitiveKind.I16,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.I32'/>
        /// </summary>
        [Symbol("i32", "Specifies a signed 32-bit refinement")]
        I32 = ClrPrimitiveKind.I32,

        /// <summary>
        /// An alias for <see cref='ClrPrimitiveKind.I64'/>
        /// </summary>
        [Symbol("i64", "Specifies a signed 64-bit refinement")]
        I64 = ClrPrimitiveKind.I64,
    }
}