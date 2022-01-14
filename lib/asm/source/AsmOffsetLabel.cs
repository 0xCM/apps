//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmRenderPatterns;

    /// <summary>
    /// Represents an line offset label
    /// </summary>
    public readonly struct AsmOffsetLabel : IAsmSourcePart
    {
        [Op]
        public static string format(AsmOffsetLabel src)
        {
            const string LabelPattern = "{0} ";
            var width = src.OffsetWidth;
            var value = src.OffsetValue;
            var f = EmptyString;
            if(width <= 16)
                f = HexFormatter.format(w16,(ushort)value, postspec:true);
            else if(width <= 32)
                f = HexFormatter.format(w32,(uint)value, postspec:true);
            else
                f = HexFormatter.format(w64,(ulong)value, postspec:true);

            return string.Format(LabelPattern, f);
        }

        [Op]
        public static string format(in AsmOffsetLabel label, in AsmFormInfo src, byte[] encoded)
            => string.Format(InstInfoPattern, label, encoded.Length, encoded.FormatHex(), src.Sig, src.OpCode);

        const ulong OffsetMask = 0xFF_FF_FF_FF_FF_FF_FF;

        const byte Cut = 56;

        readonly ulong Data;

        [MethodImpl(Inline)]
        public AsmOffsetLabel(byte width, ulong offset)
        {
            Data = ((ulong)width << Cut) | (offset & OffsetMask);
        }

        public AsmPartKind PartKind
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
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmCell(AsmOffsetLabel src)
            => asm.cell(src.Format(), src.PartKind);
    }
}