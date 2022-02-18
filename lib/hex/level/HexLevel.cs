//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly partial struct HexLevel
    {
        [MethodImpl(Inline), Op]
        public static IntPtr locate()
            => typeof(HexLevel).TypeHandle.Value;
    }
}