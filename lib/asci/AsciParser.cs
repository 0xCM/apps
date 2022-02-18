//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct AsciParser
    {
        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out asci64 dst)
        {
            dst = src;
            return true;
        }

        [MethodImpl(Inline), Op]
        public static Outcome parse(string src, out asci16 dst)
        {
            dst = src;
            return true;
        }
    }
}