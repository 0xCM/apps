//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;

    partial class XedOpCodes
    {
        public static Index<OpCodeDetail> details(Index<InstPattern> patterns)
        {
            var count = patterns.Count;
            var buffer = alloc<OpCodeDetail>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var src = ref patterns[i];
                ref var dst = ref seek(buffer,i);
                dst.PatternId = (ushort)src.PatternId;
                dst.Expr = src.Expr;
                dst.Layout = src.Layout;
                dst.InstClass = src.InstClass;
                dst.Mode = src.Mode;
                dst.OpCode = src.OpCode;
                dst.Lock = src.Lock;
                dst.Mod = XedFields.mod(src.Fields);
                dst.RexW = XedFields.rexw(src.Fields);
            }

            buffer.Sort();

            return buffer;
        }
    }
}