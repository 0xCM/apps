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
    public enum ClrEnumKind : byte
    {
        None = 0,

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
    }
}