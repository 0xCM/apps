//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using NK = Z0.NumericKind;

[assembly: PartId(PartId.Part)]

namespace Z0
{
    class Root
    {
        public const string EmptyString = "";

        public const MethodImplOptions Inline = MethodImplOptions.AggressiveInlining;

        /// <summary>
        /// Specifies unsigned integral types of widths <see cref='NumericWidths'/>
        /// </summary>
        public const NK UnsignedInts = NK.UnsignedInts;
    }

    public static partial class ClrQuery
    {}

    class SymbolicQuery
    {
        
    }
}
