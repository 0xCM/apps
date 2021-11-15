//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    partial struct SpanRes
    {
        /// <remarks>
        /// Each method is 29 bytes in length and similar to:
        /// 0000h nop dword ptr [rax+rax]        ; NOP r/m32           | 0F 1F /0        | 5   | 0f 1f 44 00 00
        /// 0005h mov rax,228ab7d8e44h           ; MOV r64, imm64      | REX.W B8+ro io  | 10  | 48 b8 44 8e 7d ab 28 02 00 00
        /// 000fh mov [rcx],rax                  ; MOV r/m64, r64      | REX.W 89 /r     | 3   | 48 89 01
        /// 0012h mov dword ptr [rcx+8],91h      ; MOV r/m32, imm32    | C7 /0 id        | 7   | c7 41 08 91 00 00 00
        /// 0019h mov rax,rcx                    ; MOV r64, r/m64      | REX.W 8B /r     | 3   | 48 8b c1
        /// 001ch ret                            ; RET                 | C3              | 1   | c3
        /// </remarks>
        [Op]
        public static MemorySeg capture(SpanResAccessor accessor)
        {
            var def = definition(accessor);
            var address = MemoryAddress.Zero;
            var size = ByteSize.Zero;
            for(var i=0; i<MemberSegCount; i++)
            {
                if(i == 1)
                {
                    // MOV r64,imm64 : REX.W B8+ro io => [48 b8] [lo lo lo lo hi hi hi hi]
                    var start = skip(MemberSegments, i) + 2;
                    var width = skip(MemberSegments, i+1) - start;
                    address = bw64u(slice(def, start,width));
                }
                else if(i==3)
                {
                    // MOV r/m32, imm32 : C7 /0 id => [c7 41 08] [lo lo hi hi]
                    var start = skip(MemberSegments, i) + 3;
                    var width = skip(MemberSegments, i+1) - start;
                    size = bw32u(slice(def, start, width));
                }
            }

            return new MemorySeg(address, size);
        }

        const byte MemberSegCount = 6;

        static ReadOnlySpan<byte> MemberSegments
            => new byte[MemberSegCount]{0,5,0xf,0x12,0x18,0x1c};
    }
}