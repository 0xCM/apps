//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;
    [ApiHost]
    public readonly partial struct AsmChecks
    {
        [Op]
        public static bit check(ref AsmSizeCheck src)
        {
            src.Actual = (ushort)Sizes.width(src.Input);
            switch(src.Input.Code)
            {
                case NativeSizeCode.W8:
                    src.Expect = (ushort)NativeSize.from(w8).Width;
                break;
                case NativeSizeCode.W16:
                    src.Expect = (ushort)NativeSize.from(w16).Width;
                break;
                case NativeSizeCode.W32:
                    src.Expect = (ushort)NativeSize.from(w32).Width;
                break;
                case NativeSizeCode.W64:
                    src.Expect = (ushort)NativeSize.from(w64).Width;
                break;
                case NativeSizeCode.W128:
                    src.Expect = (ushort)NativeSize.from(w128).Width;
                break;
                case NativeSizeCode.W256:
                    src.Expect = (ushort)NativeSize.from(w256).Width;
                break;
                case NativeSizeCode.W512:
                    src.Expect = (ushort)NativeSize.from(w512).Width;
                break;
                case NativeSizeCode.W80:
                    src.Expect = (ushort)NativeSize.from(w80).Width;
                break;
            }
            return src.Passed;
        }
    }
}