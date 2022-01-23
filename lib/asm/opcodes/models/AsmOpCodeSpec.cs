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

    public readonly struct AsmOpCodeSpec
    {
        const byte Capacity = 15;

        readonly Cell256 Data;

        [MethodImpl(Inline)]
        public AsmOpCodeSpec(ReadOnlySpan<AsmOcToken> tokens)
        {
            Data = first(recover<AsmOcToken,Cell256>(tokens));

            var _tokens = Tokens();
            var counter = z8;
            for(var i=0; i<Capacity; i++)
            {
                if(skip(_tokens,i) != 0)
                    counter++;
                else
                    break;
            }

            seek(_tokens,Capacity-1) = counter;
        }

        [MethodImpl(Inline)]
        Span<AsmOcToken> Tokens()
            => recover<AsmOcToken>(Data.Bytes);

        public byte TokenCount
        {
            [MethodImpl(Inline)]
            get => (byte)this[Capacity-1];
        }

        public ref readonly AsmOcToken this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref skip(Tokens(),i);
        }

        public ref readonly AsmOcToken this[int i]
        {
            [MethodImpl(Inline)]
            get => ref skip(Tokens(),i);
        }

        [MethodImpl(Inline)]
        public static implicit operator AsmOpCodeSpec(AsmOcToken[] src)
            => new AsmOpCodeSpec(src);

        public static AsmOpCodeSpec Empty => new AsmOpCodeSpec(sys.empty<AsmOcToken>());
    }
}