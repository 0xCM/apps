//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack =1)]
    public readonly struct ApiHostHex
    {
        public ApiHostUri Host {get;}

        public MemoryBlocks Hex {get;}

        [MethodImpl(Inline)]
        public ApiHostHex(ApiHostUri uri, MemoryBlocks hex)
        {
            Host = uri;
            Hex = hex;
        }

        [MethodImpl(Inline)]
        public static implicit operator ApiHostHex((ApiHostUri uri, MemoryBlocks hex) src)
            => new ApiHostHex(src.uri, src.hex);
    }
}