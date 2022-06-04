//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("parsers/check")]
        void CheckParsers()
        {
            var count = Digital.parse("01001101", out GBlock64<BinaryDigit> dst);
            CheckDigitParsers();
        }

        void CheckDigitParsers()
        {
            CheckDigitParser(base2);
        }

        void CheckDigitParser(Base10 @base)
        {
            var parser = DigitParsers.chars(@base);
            var buffer = CharBlocks.alloc(n32);
        }

        void CheckDigitParser(Base16 @base)
        {
            var parser = DigitParsers.chars(@base);
            var buffer = CharBlocks.alloc(n32);

        }

        void CheckDigitParser(Base2 @base)
        {
            var parser = DigitParsers.chars(@base);
            var input = span("11001101");
            var buffer = CharBlocks.alloc(n32);
            var count = parser.Parse(input, buffer.Data);
            var parsed = slice(buffer.Data,0,count);
            Write(text.format(Demand.eq(input,parsed)));
        }
    }
}