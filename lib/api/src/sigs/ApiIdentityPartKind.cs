//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum ApiIdentityPartKind : ushort
    {
        None = 0,

        /// <summary>
        /// The unadorned subject name and the first part of the moniker
        /// </summary>
        Name = 1,

        /// <summary>
        /// A trailing component of the form {suffix sep}{suffix name}
        /// </summary>
        Suffix = 4,

        /// <summary>
        /// A numeric specifier of the form {width}{numeric_indicator}
        /// </summary>
        /// <example>
        /// In the identifier 'gteq_(8u,8u)' both arguments are 8-bit unsigned scalar values
        /// </example>
        Numeric,

        /// <summary>
        /// A segmentation specifier of the form {total width}x{segment width}{numeric indicator}
        /// </summary>
        /// <example>
        /// in the identifier 'vnand_(v128x16u,v128x16u)', the term '128x16u' in both value arguments is a segment specifier
        /// </example>
        Segment ,
    }
}