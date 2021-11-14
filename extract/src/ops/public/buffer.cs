//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct ApiExtracts
    {
        [Op]
        public static byte[] buffer(ByteSize? size = null)
            => alloc<byte>(size ?? DefaultBufferLength);
    }
}
