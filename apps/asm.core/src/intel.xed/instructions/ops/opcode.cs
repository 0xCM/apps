//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedPatterns
    {
        public static XedOpCode opcode(InstPatternBody src)
            => XedOpCodeParser.create().Parse(src);

        public static XedOpCode opcode(InstPattern src)
            => opcode(src.Body);

        public static Index<XedOpCode> opcodes(Index<InstPattern> src)
        {
            var buffer = bag<XedOpCode>();
            iter(src, p => buffer.Add(opcode(p.Body)), true);
            return buffer.ToArray().Sort();
        }
    }
}