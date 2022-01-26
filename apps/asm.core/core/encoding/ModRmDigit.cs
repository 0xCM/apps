//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmOpCodeTokens;

    /// <summary>
    /// Represents a register digit 0..7 that occurs within an op code expression
    /// </summary>
    public struct ModRmDigit
    {
        public ModRmToken _Code;

        [MethodImpl(Inline)]
        public ModRmDigit(ModRmToken code)
            => _Code = code;

        public byte Encoded
        {
            [MethodImpl(Inline)]
            get => (byte)_Code;
        }

        public ModRmToken Code()
            => _Code;

        public void Code(ModRmToken code)
            => _Code = code;

        [MethodImpl(Inline)]
        public static implicit operator ModRmDigit(byte src)
            => new ModRmDigit((ModRmToken)src);

        [MethodImpl(Inline)]
        public static implicit operator ModRmDigit(ModRmToken src)
            => new ModRmDigit(src);

        [MethodImpl(Inline)]
        public static explicit operator byte(ModRmDigit src)
            => src.Encoded;
    }
}