//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using W = W8;

    /// <summary>
    /// Describes an 8-bit immediate that is potentially refined
    /// </summary>
    [DataType("imm8r", Kind, Width, Width)]
    public readonly struct imm8R : IImm<imm8R,byte>
    {
        public const ImmKind Kind = ImmKind.Imm8;

        public const byte Width = 8;

        public byte Value {get;}

        [MethodImpl(Inline)]
        public imm8R(byte value)
            => Value = value;

        public ImmKind ImmKind
            => Kind;

        public ImmBitWidth ImmWidth
            => (ImmBitWidth)Width;

        public string Format()
            => HexFormatter.format(Value, W, true);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator byte(imm8R imm8)
            => imm8.Value;

       public static W W => default;
    }
}