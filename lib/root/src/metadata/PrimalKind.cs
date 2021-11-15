//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Log2x8;
    using static Sign8Kind;

    using K = PrimalCode;
    using I = PrimalBits.SegPos;

    /// <summary>
    /// Defines a bitfield that identifies and describes system type primitives
    /// </summary>
    /// <remarks>
    /// [Sign8Kind:7 | PrimalKindId:3..6 | Log2x8:0..2]
    /// <remarks>
    public enum PrimalKind : byte
    {
        None = 0,

        /// <summary>
        /// Specifies a boolean value
        /// </summary>
        U1 = L1 << I.Width | K.U1 << I.KindId,

        /// <summary>
        /// Specifies a signed 8-bit integer
        /// </summary>
        I8 = L3 << I.Width | K.I8 << I.KindId | Signed,

        /// <summary>
        /// Specifies an unsigned 8-bit integer
        /// </summary>
        U8 = L3 << I.Width | K.U8 << I.KindId,

        /// <summary>
        /// Specifies a signed 16-bit integer
        /// </summary>
        I16 = L4 << I.Width | K.I16 << I.KindId | Signed,

        /// <summary>
        /// Specifies a 16-bit unicode character
        /// </summary>
        C16 = L4 << I.Width | K.C16 << I.KindId,

        /// <summary>
        /// Specifies an unsigned 16-bit integer
        /// </summary>
        U16 = L4 << I.Width | K.U16 << I.KindId,

        /// <summary>
        /// Specifies a signed 32-bit integer
        /// </summary>
        I32 = L5 << I.Width | K.I32 << I.KindId | Signed,

        /// <summary>
        /// Specifies an unsigned 32-bit integer
        /// </summary>
        U32 = L5 << I.Width | K.U32 <<  I.KindId,

        /// <summary>
        /// Specifies an unsigned 64-bit integer
        /// </summary>
        U64  = L6 << I.Width | K.U64 <<  I.KindId,

        /// <summary>
        /// Specifies a signed 64-bit integer
        /// </summary>
        I64 = L6 << I.Width | K.I64 << I.KindId | Signed,

        /// <summary>
        /// Specifies a signed 32-bit floating-point number
        /// </summary>
        F32 = L5 << I.Width | K.F32 << I.KindId,

        /// <summary>
        /// Specifies a signed 64-bit floating-point number
        /// </summary>
        F64 = L6 << I.Width | K.F64 << I.KindId,

        /// <summary>
        /// Specifies a signed 64-bit floating-point number
        /// </summary>
        F128 = L7 << I.Width | K.F128 <<  I.KindId,

        /// <summary>
        /// Specifies a 16-bit unicode character
        /// </summary>
        String = L0 << I.Width | K.C16 << I.KindId,

        /// <summary>
        /// Specifies System.Object
        /// </summary>
        Object = K.Object << I.KindId,

        /// <summary>
        /// Specifies System.DBNull
        /// </summary>
        DBNull = K.DBNull << I.KindId,

        /// <summary>
        /// Specifies System.DateTime
        /// </summary>
        DateTime = L6 << I.Width | K.DateTime << I.KindId,
    }
}