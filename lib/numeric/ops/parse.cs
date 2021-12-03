//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using DP = DataParser;

    partial struct Numeric
    {
        public static Outcome parse(string src, Type type, out dynamic dst)
        {
            Outcome result = (false, string.Format("The {0} type is unsupported", type.Name));
            dst = 0;
            if(type.IsUInt8())
            {
                result = DP.parse(src, out byte x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt8())
            {
                result = DP.parse(src, out sbyte x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt16())
            {
                result = DP.parse(src, out short x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt16())
            {
                result = DP.parse(src, out ushort x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt32())
            {
                result = DP.parse(src, out uint x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt32())
            {
                result = DP.parse(src, out int x);
                if(result)
                    dst = x;
            }
            else if(type.IsUInt64())
            {
                result = DP.parse(src, out ulong x);
                if(result)
                    dst = x;
            }
            else if(type.IsInt64())
            {
                result = DP.parse(src, out long x);
                if(result)
                    dst = x;
            }
            else if(type.IsFloat32())
            {
                result = DP.parse(src, out float x);
                if(result)
                    dst = x;
            }
            else if(type.IsFloat64())
            {
                result = DP.parse(src, out double x);
                if(result)
                    dst = x;
            }
            return result;
        }
    }
}