//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmPrefixCodes;

    public readonly struct MandatoryPrefix : IAsmPrefix<MandatoryPrefixCode>
    {
        public readonly MandatoryPrefixCode Code;

        [MethodImpl(Inline)]
        public MandatoryPrefix(MandatoryPrefixCode src)
        {
            Code = src;
        }

        public byte Encoded
        {
            [MethodImpl(Inline)]
            get => (byte)Code;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Code == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Code != 0;
        }

        public override string ToString()
            => Format();

        public string Format()
            => Encoded.FormatHex();

        [MethodImpl(Inline)]
        public static implicit operator MandatoryPrefix(MandatoryPrefixCode src)
            => new MandatoryPrefix(src);

        [MethodImpl(Inline)]
        public static implicit operator MandatoryPrefixCode(MandatoryPrefix src)
            => src.Code;

        [MethodImpl(Inline)]
        public static implicit operator byte(MandatoryPrefix src)
            => (byte)src.Code;
    }
}