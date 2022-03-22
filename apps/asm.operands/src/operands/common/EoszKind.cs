//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [Flags]
    public enum EoszKind : byte
    {
        [Symbol("")]
        None,

        [Symbol("8")]
        W8 = 1,

        [Symbol("16")]
        W16 = 2,

        [Symbol("32")]
        W32 = 4,

        [Symbol("64")]
        W64 = 8
    }

    public static partial class XTend
    {
        public static string Format(this EoszKind src)
        {
            var dst = EmptyString;
            if(src != 0)
            {
                if(src.Test(EoszKind.W8))
                    dst = "8";

                if(src.Test(EoszKind.W16))
                {
                    if(text.empty(dst))
                        dst = "16";
                    else
                        dst += "16";
                }

                if(src.Test(EoszKind.W32))
                {
                    if(text.empty(dst))
                        dst = "32";
                    else
                        dst += "32";
                }

                if(src.Test(EoszKind.W64))
                {
                    if(text.empty(dst))
                        dst = "64";
                    else
                        dst += "64";

                }
            }
            return dst;
        }
    }
}