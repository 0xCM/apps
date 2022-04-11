//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedRules;

    using K = XedRules.InstFieldKind;

    partial class XedPatterns
    {
        public static Index<InstLayout> layouts(ReadOnlySpan<InstGroup> groups)
        {
            var dst = bag<InstLayout>();
            iter(groups, g => layouts(g,dst), true);
            return dst.Array().Sort();
        }

        static void layouts(InstGroup src, ConcurrentBag<InstLayout> dst)
        {
            var count = src.Members.Count;
            for(var j=0; j<count; j++)
                dst.Add(XedPatterns.layout(src.Members[j]));
        }

        public static InstLayout layout(in InstGroupMember src)
        {
            var @class = src.Class;
            var opcode = src.OpCode;
            var fields = src.Fields;
            if(fields.IsEmpty)
                return InstLayout.Empty;

            var layout = fields.Layout;
            var count = layout.Length;
            var cells = alloc<LayoutField>(count);
            for(var i=z8; i<count; i++)
            {
                ref readonly var field = ref fields[i];
                ref var cell = ref seek(cells,i);
                switch(field.DataKind)
                {
                    case K.BitLiteral:
                        cell = new (i, field.AsBitLit());
                    break;
                    case K.HexLiteral:
                        cell = new (i, field.AsHexLit());
                    break;
                    case K.Nonterm:
                        cell = new (i, field.AsNonterminal());
                    break;
                    case K.Seg:
                        cell = new (i, field.AsSeg());
                    break;
                    default:
                        Errors.Throw(AppMsg.UnhandledCase.Format(field.DataKind));
                    break;
                }
            }

            return new InstLayout(@class, src, opcode, cells);
         }
    }
}