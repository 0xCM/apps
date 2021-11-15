//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Id = ApiClassKind;

    /// <summary>
    /// Identifies bitwise shift operators
    /// </summary>
    [ApiClass]
    public enum ApiBitShiftClass : ushort
    {
        /// <summary>
        /// The empty identity
        /// </summary>
        None = 0,

        /// <summary>
        /// Identifies a logical left-shift operator
        /// </summary>
        Sll = Id.Sll,

        /// <summary>
        /// Identifies a variable logical left-shift operator
        /// </summary>
        Sllv = Id.Sllv,

        /// <summary>
        /// Identifies a logical right-shift operator
        /// </summary>
        Srl = Id.Srl,

        /// <summary>
        /// Identifies a variable logical right-shift operator
        /// </summary>
        Srlv = Id.Srlv,

        /// <summary>
        /// Identifies an arithmetic left-shift operator
        /// </summary>
        Sal = Id.Sal,

        /// <summary>
        /// Identifies an arithmetic right-shift operator
        /// </summary>
        Sra = Id.Sra,

        /// <summary>
        /// Identifies a left circular shift operator
        /// </summary>
        Rotl = Id.Rotl,

        /// <summary>
        /// Identifies a right circular shift operator
        /// </summary>
        Rotr  = Id.Rotr,

        /// <summary>
        /// Identifies a segmented right circular shift operator with potentially varying shift amounts per segment
        /// </summary>
        Rotrv  = Id.Rotrv,

        /// <summary>
        /// Identifies a segmented left circular shift operator with potentially varying shift amounts per segment
        /// </summary>
        Rotlv  = Id.Rotlv,

        /// <summary>
        /// Identifies a composite shift operator of the form a^(a << offset)
        /// </summary>
        XorSl = Id.XorSl,

        /// <summary>
        /// Identifies a composite shift operator of the form a^(a >> offset)
        /// </summary>
        XorSr = Id.XorSr,

        /// <summary>
        /// Identifies a composite shift operator of the form a ^ ((a << offset) ^ (a >> offset))
        /// </summary>
        Xors = Id.Xors,

        Bsrl = Id.Bsrl,

        Bsll = Id.Bsll,

        Rotrx = Id.Rotrx,

        Rotlx = Id.Rotlx,

        Sllx = Id.Sllx,

        Srlx = Id.Srlx,
    }
}