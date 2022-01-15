//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents an line offset label
    /// </summary>
    public readonly struct AsmOffsetLabel : IAsmSourcePart
    {
        internal const string InstInfoPattern = "{0} | {1,-3} | {2,-32} | ({3}) = {4}";

        const ulong OffsetMask = 0xFF_FF_FF_FF_FF_FF_FF;

        const byte Cut = 56;

        readonly ulong Data;

        [MethodImpl(Inline)]
        public AsmOffsetLabel(byte width, ulong offset)
        {
            Data = ((ulong)width << Cut) | (offset & OffsetMask);
        }

        AsmPartKind IAsmSourcePart.PartKind
        {
            [MethodImpl(Inline)]
            get => AsmPartKind.OffsetLabel;
        }

        public ulong OffsetValue
        {
            [MethodImpl(Inline)]
            get => Data & OffsetMask;
        }

        /// <summary>
        /// The offset bit-width
        /// </summary>
        public byte OffsetWidth
        {
            [MethodImpl(Inline)]
            get => (byte)((ulong)Data >> Cut);
        }

        public string Format()
        {
            const string LabelPattern = "{0} ";
            var width = OffsetWidth;
            var value = OffsetValue;
            var f = EmptyString;
            if(width <= 16)
                f = HexFormatter.format(w16,(ushort)value, postspec:true);
            else if(width <= 32)
                f = HexFormatter.format(w32,(uint)value, postspec:true);
            else
                f = HexFormatter.format(w64,(ulong)value, postspec:true);

            return string.Format(LabelPattern, f);
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmOffsetLabel src)
            => asm.cell(src.Format(), AsmPartKind.OffsetLabel);
    }
}