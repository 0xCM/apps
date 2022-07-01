//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    partial class HashCodes
    {
        [Parser]
        public static Outcome parse(string src, out Hash8 dst)
        {
            var result = Hex8.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (byte)hex;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out Hash16 dst)
        {
            var result = Hex16.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (ushort)hex;
            return result;
        }


        [Parser]
        public static Outcome parse(string src, out Hash32 dst)
        {
            var result = Hex32.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (uint)hex;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out Hash64 dst)
        {
            var result = Hex64.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (ulong)hex;
            return result;
        }
    }
}