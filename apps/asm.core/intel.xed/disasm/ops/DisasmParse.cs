//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class XedDisasm
    {
        internal partial class DisasmParse
        {
            const string XDIS = "XDIS ";

            const string YDIS = "YDIS:";

            public static Outcome parse(string src, out MemoryAddress dst)
            {
                var result = Outcome.Failure;
                var i = text.index(src, XDIS);
                var j = XDIS.Length;
                var k = text.index(src, Chars.Colon);
                var length = k-j;
                dst = 0;
                if(j >= 0 && length > 0)
                    result = DataParser.parse(text.slice(src,j,length).Trim(), out dst);
                return result;
            }

            public static Outcome parse(TextLine src, out AsmHexCode dst)
            {
                var result = Outcome.Failure;
                dst = AsmHexCode.Empty;
                var buffer = span<byte>(16);

                if(src.StartsWith(XDIS))
                {
                    ref readonly var content = ref src.Content;
                    var k = text.index(content, Chars.Colon);
                    if(k > 0)
                    {
                        var parts = text.words(text.right(content,k));
                        if(parts.Length >=3)
                        {
                            var count = HexParser.parse(parts[2], buffer);
                            if(count)
                            {
                                dst = slice(buffer,0,count).ToArray();
                                result = Outcome.Success;
                            }
                        }
                    }
                }

                return result;
            }

            public static Index<AsmExpr> expressions(ReadOnlySpan<DisasmLineBlock> src)
            {
                var dst = list<AsmExpr>();
                foreach(var block in src)
                {
                    foreach(var line in block.Lines)
                    {
                        var i = text.index(line.Content, YDIS);
                        if(i >= 0)
                            dst.Add(text.trim(text.right(line.Content, i + YDIS.Length)));
                    }
                }
                return dst.ToArray();
            }
        }
    }
}