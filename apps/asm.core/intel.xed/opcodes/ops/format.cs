//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedOpCodes
    {
        static string hex(byte src)
            => "0x" + src.ToString("X2");

        public static string format(XedOpCode src)
        {
            var a = src.Map.Value;
            var value = src.Value.Data;
            var size = src.Value.TrimmedSize;
            var lo = (byte)a;
            var hi = (byte)(a >> 8);
            var symbol = src.Symbol;
            var dst = EmptyString;
            switch(size)
            {
                case 0:
                case 1:
                {
                    ref readonly var b0 = ref value[0];
                    dst = $"{symbol}[{a}]:{hex(b0)}";
                }
                break;
                case 2:
                {
                    ref readonly var b0 = ref value[1];
                    ref readonly var b1 = ref value[0];
                    dst = $"{symbol}[{a}]:{hex(b1)} {hex(b0)}";
                    if(lo !=0 && hi == 0)
                    {
                        if(lo == b1)
                            dst = $"{symbol}[{a}]:{hex(b0)}";
                    }
                }
                break;
                case 3:
                {
                    ref readonly var b0 = ref value[2];
                    ref readonly var b1 = ref value[1];
                    ref readonly var b2 = ref value[0];
                    dst = $"{symbol}[{a}]:{hex(b2)} {hex(b1)} {hex(b0)}";
                    if(lo !=0 && hi != 0)
                    {
                        if(hi == b2 && lo == b1)
                            dst = $"{symbol}[{a}]:{hex(b0)}";
                    }
                    else if(lo != 0)
                    {
                        if(lo == b2)
                            dst = $"{symbol}[{a}]:{hex(b1)} {hex(b0)}";
                    }
                }
                break;
            }

            return dst;
        }
    }
}