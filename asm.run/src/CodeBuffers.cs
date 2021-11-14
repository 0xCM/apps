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

    public unsafe readonly struct CodeBuffers
    {
        public static CodeBuffers create()
        {
            if(!memory.liberate(Store128, out var pBuffer))
                throw new Exception("Failed to liberate buffer");
            return new CodeBuffers(pBuffer);
        }

        static ReadOnlySpan<byte> Store128 => new byte[128]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,};

        [MethodImpl(Inline)]
        CodeBuffers(byte* p128)
        {
            P128 = p128;
        }

        public Span<byte> Buffer128
        {
            [MethodImpl(Inline)]
            get => edit(Store128);
        }

        readonly byte* P128;
    }
}