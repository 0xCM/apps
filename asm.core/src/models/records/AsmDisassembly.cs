//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Record(TableId)]
    public struct AsmDisassembly : IRecord<AsmDisassembly>
    {
        public static string format(in AsmDisassembly src)
        {
            var left = string.Format("{0,-12} {1,-64}", src.Offset, src.Statement);
            var right = new AsmComment(string.Format("{0,-32} {1}", src.Code, src.Bitstring));
            return string.Format("{0}{1}", left, right);
        }

        [Op]
        public static uint render(in AsmDisassembly src, Span<char> dst)
        {
            var i=0u;
            Hex.render(LowerCase,(Hex64)src.Offset, ref i, dst);
            core.seek(dst,i++) = Chars.Space;
            text.copy(src.Statement.Data, ref i, dst);
            return i;
        }

        public static string format(in AsmDisassembly src, Span<char> buffer)
        {
            var count = render(src,buffer);
            return text.format(core.slice(buffer,0,count));
        }

        public const string TableId = "asm.disassembly";

        public const byte FieldCount = 4;

        public MemoryAddress Offset;

        public AsmExpr Statement;

        public AsmHexCode Code;

        public AsmBitstring Bitstring;

        [MethodImpl(Inline)]
        public AsmDisassembly(MemoryAddress offset, AsmExpr expr, AsmHexCode code, AsmBitstring bs)
        {
            Offset = offset;
            Statement = expr;
            Code = code;
            Bitstring = bs;
        }

        [MethodImpl(Inline)]
        public AsmDisassembly(MemoryAddress offset, AsmExpr expr)
        {
            Offset = offset;
            Statement = expr;
            Code = AsmHexCode.Empty;
            Bitstring = AsmBitstring.Empty;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,64,32,32};
    }
}