//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct BitRecordField
    {
        /// <summary>
        /// The field name
        /// </summary>
        public text15 Name {get;}

        /// <summary>
        /// The 0-based, record-relative field position/index
        /// </summary>
        public byte FieldIndex {get;}

        /// <summary>
        /// The position of the first bit in the field
        /// </summary>
        public uint FieldOffset {get;}

        /// <summary>
        /// The number of semantic bits required by the field
        /// </summary>
        public byte ContentWidth {get;}

        [MethodImpl(Inline)]
        public BitRecordField(text15 name, byte index, uint offset, byte width)
        {
            Name = name;
            FieldIndex = index;
            FieldOffset = offset;
            ContentWidth = width;
        }

        /// <summary>
        /// The position of the last bit in the field
        /// </summary>
        public uint LastBit
        {
            [MethodImpl(Inline)]
            get => FieldOffset + ContentWidth;
        }
    }
}