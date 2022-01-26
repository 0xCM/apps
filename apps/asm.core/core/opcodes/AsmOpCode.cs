//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct AsmOpCode
    {
        public const byte TokenCapacity = 15;

        Cell256 Data;

        [MethodImpl(Inline)]
        public AsmOpCode(ReadOnlySpan<AsmOcToken> tokens)
        {
            Data = first(recover<AsmOcToken,Cell256>(tokens));
            var _tokens = Tokens();
            var counter = z8;
            for(var i=0; i<TokenCapacity; i++)
            {
                if(skip(_tokens,i) != 0)
                    counter++;
                else
                    break;
            }

            TokenCount = counter;
        }

        [MethodImpl(Inline)]
        Span<AsmOcToken> Tokens()
            => recover<AsmOcToken>(Data.Bytes);

        ref ushort Settings
        {
            [MethodImpl(Inline)]
            get => ref seek(recover<ushort>(Data.Bytes), TokenCapacity-1);
        }

        public ref byte TokenCount
        {
            [MethodImpl(Inline)]
            get => ref @as<byte>(Settings);
        }

        public ref AsmOcClass OcClass
        {
            [MethodImpl(Inline)]
            get => ref seek(@as<AsmOcClass>(Settings),1);
        }

        public ref AsmOcToken this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Tokens(),i);
        }

        public ref AsmOcToken this[int i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Tokens(),i);
        }

        public string Format()
            => AsmOcFormatter.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmOpCode(AsmOcToken[] src)
            => new AsmOpCode(src);

        public static AsmOpCode Empty => new AsmOpCode(sys.empty<AsmOcToken>());
    }
}