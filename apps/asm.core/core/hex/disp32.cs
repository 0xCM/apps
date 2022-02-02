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

    partial class AsmHexSpecs
    {
        [MethodImpl(Inline), Op]
        public static Disp32 disp32(ReadOnlySpan<byte> encoding)
        {
            var dst = ByteBlock4.Empty;
            var buffer = dst.Bytes;
            seek(buffer,0) = skip(encoding,1);
            seek(buffer,1) = skip(encoding,2);
            seek(buffer,2) = skip(encoding,3);
            seek(buffer,3) = skip(encoding,4);
            return @as<Disp32>(buffer);
        }
    }
}