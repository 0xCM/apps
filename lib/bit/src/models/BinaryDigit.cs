//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using V = BinaryDigitValue;

    public readonly struct BinaryDigit
    {
        const string D0 = "0";

        const string D1 = "1";

        public readonly V Value;

        [MethodImpl(Inline)]
        public BinaryDigit(V value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public BinaryDigit(BinaryDigitCode src)
        {
            Value = src == BinaryDigitCode.b1 ? V.b1 : V.b0;
        }

        [MethodImpl(Inline)]
        public BinaryDigit(BinaryDigitSym src)
        {
            Value = src == BinaryDigitSym.b1 ? V.b1 : V.b0;
        }

        [MethodImpl(Inline)]
        public BinaryDigit(bit src)
        {
            Value = (V)(byte)src;
        }

        public BinaryDigitSym Symbol
        {
            [MethodImpl(Inline)]
            get => Value == 0 ? BinaryDigitSym.b0 : BinaryDigitSym.b1;
        }

        public BinaryDigitCode Code
        {
            [MethodImpl(Inline)]
            get => (BinaryDigitCode)Symbol;
        }

        public char Char
        {
            [MethodImpl(Inline)]
            get => (char)Symbol;
        }

        public bit Bit
        {
            [MethodImpl(Inline)]
            get => Value == BinaryDigitValue.b1;
        }

        [MethodImpl(Inline)]
        public BinaryDigit Inc()
            => Bit ? new BinaryDigit(bit.Off) : new BinaryDigit(bit.On);

        [MethodImpl(Inline)]
        public BinaryDigit Dec()
            => Bit ? new BinaryDigit(bit.Off) : new BinaryDigit(bit.On);

        [MethodImpl(Inline)]
        public BinaryDigit Not()
            => !Bit;

        [MethodImpl(Inline)]
        public string Format()
            => Value == BinaryDigitValue.b1 ? D1 : D0;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator BinaryDigit(BinaryDigitCode src)
            => new BinaryDigit(src);

        [MethodImpl(Inline)]
        public static implicit operator BinaryDigit(BinaryDigitSym src)
            => new BinaryDigit(src);

        [MethodImpl(Inline)]
        public static implicit operator BinaryDigitCode(BinaryDigit src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator BinaryDigit(bit src)
            => new BinaryDigit(src);

        [MethodImpl(Inline)]
        public static implicit operator bit(BinaryDigit src)
            => src.Bit;

        [MethodImpl(Inline)]
        public static implicit operator char(BinaryDigit src)
            => src.Char;

        [MethodImpl(Inline)]
        public static explicit operator byte(BinaryDigit src)
            => (byte)src.Value;
    }
}