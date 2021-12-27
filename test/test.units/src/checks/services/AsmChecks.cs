//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;
    using static core;

    [ApiHost]
    public class AsmChecks : Checker<AsmChecks>
    {
        public Outcome CheckStringRes()
        {
            using var flow = Running(nameof(CheckStringRes));
            var resources = Resources.strings(typeof(AsciText)).View;
            var count = resources.Length;
            Ran(flow);
            // for(var i=0; i<count; i++)
            // {
            //     Write(skip(resources,i));
            // }
            return true;
        }


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

        public Outcome CheckAsmHexCode()
        {
            // 4080C416                add spl,22
            var buffer = span<char>(20);
            var input1 = "40 80 c4 16";
            var input2 = "4080C416";
            Hex.parse64u(input2, out var input3);

            var code1 = asm.code(input1);
            var code2 = asm.code(input2);
            var code3 = asm.code(input3);

            var text1 = code1.Format();
            var text2 = code2.Format();
            var text3 = code3.Format();

            // Write(code1.Format());
            // Write(code2.Format());
            // Write(code3.Format());

            var check1 = CheckEquality(text1,text2);
            if(check1.Fail)
                return check1;
            else
                Status(check1.Message);

            var check2 = CheckEquality(text1,text3);
            if(check2.Fail)
                return check2;
            else
                Status(check2.Message);

            return check2;
        }

        static Outcome CheckEquality(string a, string b)
        {
            var same = a.Equals(b);
            return (same, string.Format("{0} {1} {2}", a, same ? "==" : "!=", b));
        }
    }
}