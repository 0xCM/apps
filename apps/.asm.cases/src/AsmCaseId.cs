//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct AsmCaseId
    {
        readonly ulong Data;

        [MethodImpl(Inline)]
        public AsmCaseId(ulong data)
        {
            Data = data;
        }

        [MethodImpl(Inline)]
        public ulong Segment(byte offset, byte length)
            => bits.segment(Data, offset, length);

        [MethodImpl(Inline)]
        public T Segment<T>(byte offset, byte length)
            => @as<ulong,T>(bits.segment(Data, offset, length));

        public ulong this[byte offset, byte length]
        {
            [MethodImpl(Inline)]
            get => Segment(offset,length);
        }

        public string Format()
            => Data.ToString();

        public static implicit operator AsmCaseId(ulong src)
            => new AsmCaseId(src);
    }
}