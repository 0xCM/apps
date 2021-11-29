//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct SymKindRow : IRecord<SymKindRow>
    {
        public const string TableId = "symbol.kinds";

        public const byte FieldCount = 4;

        /// <summary>
        /// The declaring type
        /// </summary>
        public Identifier Type;

        /// <summary>
        /// The declaration order
        /// </summary>
        public SymKey Index;

        /// <summary>
        /// The kind identifier
        /// </summary>
        public Identifier Name;

        /// <summary>
        /// The encoded literal, possibly an invariant address to a string resource
        /// </summary>
        public ulong Value;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{24,8,24,1};
    }
}