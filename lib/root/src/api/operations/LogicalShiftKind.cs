//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines scalar shift operator classifiers
    /// </summary>
    public enum LogicalShiftKind : byte
    {
        /// <summary>
        /// Shift left logical
        /// </summary>
        Sll,

        /// <summary>
        /// Shift right logical
        /// </summary>
        Srl,

        /// <summary>
        /// Rotate left
        /// </summary>
        Rotl,

        /// <summary>
        /// Rotate rigth
        /// </summary>
        Rotr
    }
}