//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class bits
    {
        [MethodImpl(Inline), Op]
        public static byte segwidth(byte min, byte max)
            => (byte)(max - min + 1);

        [MethodImpl(Inline), Op]
        public static uint segwidth(uint min, uint max)
            => max - min + 1;
    }
}