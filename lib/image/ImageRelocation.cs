//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ImageRelocation
    {
        /// <summary>
        /// The virtual address (or count)
        /// </summary>
        public Address32 Value;

        /// <summary>
        /// The symbol table index
        /// </summary>
        public uint SymbolIndex;

        /// <summary>
        /// The relocation type
        /// </summary>
        public ImageRelocationKind Type;

        [MethodImpl(Inline)]
        public ImageRelocation(Address32 value, uint index, ImageRelocationKind type)
        {
            Value = value;
            SymbolIndex = index;
            Type = type;
        }
    }
}