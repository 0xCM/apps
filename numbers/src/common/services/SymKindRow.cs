//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct SymKindRow : IRecord<SymKindRow>
    {
        public const string TableId = "symbol.kinds";

        public const byte FieldCount = 4;

        /// <summary>
        /// The declaration order
        /// </summary>
        [Render(8)]
        public SymKey Index;

        /// <summary>
        /// The declaring type
        /// </summary>
        [Render(64)]
        public Identifier Type;

        /// <summary>
        /// The kind identifier
        /// </summary>
        [Render(24)]
        public Identifier Name;

        /// <summary>
        /// The encoded literal, possibly an invariant address to a string resource
        /// </summary>
        [Render(1)]
        public ulong Value;
    }
}