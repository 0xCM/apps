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

    public struct AsmOcSpec
    {
        public const byte TokenCapacity = 15;

        Cell256 Data;

        [MethodImpl(Inline)]
        public AsmOcSpec(ReadOnlySpan<AsmOcToken> tokens)
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

        public ref ushort TokenCount
        {
            [MethodImpl(Inline)]
            get => ref seek(recover<ushort>(Data.Bytes), TokenCapacity-1);
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
            => AsmOcSpecs.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmOcSpec(AsmOcToken[] src)
            => new AsmOcSpec(src);

        public static AsmOcSpec Empty => new AsmOcSpec(sys.empty<AsmOcToken>());
    }
}