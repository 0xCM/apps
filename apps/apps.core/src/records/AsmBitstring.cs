//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    /// <summary>
    /// Defines a sequence of bits that specifies an instruction encoding
    /// </summary>
    [DataType("asm.bitstring")]
    public readonly struct AsmBitstring
    {
        readonly TextBlock Data {get;}

        [MethodImpl(Inline)]
        public AsmBitstring(string src)
        {
            Data = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public string Format()
            => Data;

        public override string ToString()
            => Format();

        // [MethodImpl(Inline)]
        // public static implicit operator AsmBitstring(AsmHexCode src)
        //     => asm.bitstring(src);

        public static AsmBitstring Empty
        {
            [MethodImpl(Inline)]
            get => new AsmBitstring(TextBlock.Empty);
        }
    }
}