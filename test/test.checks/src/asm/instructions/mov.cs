//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;
    using static core;

    // 7ffa095300e5h 0005h mov rax,1f6d13cb5e4h ; MOV r64, imm64 | REX.W B8+ro io | 48 b8 e4 b5 3c d1 f6 01 00 00
    // 7ffa09530115h 0005h mov rax,1f6d12f2f4ch ; MOV r64, imm64 | REX.W B8+ro io | 48 b8 4c 2f 2f d1 f6 01 00 00

    partial class AsmCaseArchive
    {
        public static AsmEncodingCases mov()
        {
            var dst = new AsmEncodingCases(alloc<AsmEncodingCase>(2));
            var counter = z16;
            var monic = "mov";
            dst[0] = AsmEncodingCase.define(monic, counter++,
                ResText.from("REX.W B8+ro io"),
                ResText.from("MOV r64,imm64"),
                ResText.from("mov rax,1f6d13cb5e4h"),
                ResText.from("48 b8 e4 b5 3c d1 f6 01 00 00")
                );
            dst[1] = AsmEncodingCase.define(monic, counter++,
                ResText.from("REX.W B8+ro io"),
                ResText.from("MOV r64,imm64"),
                ResText.from("mov rax,1f6d12f2f4ch"),
                ResText.from("48 b8 4c 2f 2f d1 f6 01 00 00")
                );
            return dst;
        }
    }
}