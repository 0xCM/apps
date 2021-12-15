//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines character representations of the partitions identified by the NumericClass kind
    /// </summary>
    public enum NumericIndicator : ushort
    {
        None = 0,        
        
        /// <summary>
        /// 105: Indicates a signed integral type
        /// </summary>
        Signed = (ushort)IDI.Signed,

        /// <summary>
        /// 102: Indicates a floating-point type
        /// </summary>
        Float = (ushort)IDI.Float,

        /// <summary>
        /// 117: Indicates an unsigned integral type
        /// </summary>
        Unsigned =  (ushort)IDI.Unsigned,
    }
}