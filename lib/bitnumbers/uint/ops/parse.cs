//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct BitNumbers
    {
        static Outcome parse(string src, out byte b)
        {
            var result = Outcome.Success;
            b = default;
            var i = text.index(src,HexFormatSpecs.PreSpec);
            if(i >=0)
                result = HexParser.parse8u(src, out b);
            else
                result = DataParser.parse(src, out b);
            return result;

        }

        [Parser]
        public static Outcome parse(string src, out uint2 dst)
        {
            var result = parse(src, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint3 dst)
        {
            var result = parse(src, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint4 dst)
        {
            var result = parse(src, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint5 dst)
        {
            var result = parse(src, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint6 dst)
        {
            var result = parse(src, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out uint7 dst)
        {
            var result = parse(src, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }

        [Parser]
        public static Outcome parse(string src, out eight dst)
        {
            var result = parse(src, out byte b);
            if(result)
                dst = b;
            else
                dst = default;
            return result;
        }
    }
}