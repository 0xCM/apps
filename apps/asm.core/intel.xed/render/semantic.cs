//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static XedRules;
    using static XedPatterns;
    using static XedFields;
    using static XedDisasm;
    using static core;

    partial class XedRender
    {
       public static string semantic(OpAction src)
            => src switch
            {
                OpAction.R => "in",
                OpAction.W => "out",
                OpAction.RW => "io",
                OpAction.CR => "?in",
                OpAction.CW => "?out",
                OpAction.CRW => "crw",
                OpAction.RCW => "rcw",
                _ => EmptyString,
            };

        public static string semantic(in PatternOpInfo src)
        {
            var type = EmptyString;
            var width = EmptyString;
            if(src.CellType.IsNonEmpty)
                type = src.CellType.Format();
            if(empty(type) && src.NonTerminal.IsNonEmpty)
                type = src.NonTerminal.Format();

            if(src.RegLit.IsNonEmpty)
                type = src.RegLit.Format();
            if(src.BitWidth.IsNonEmpty)
                width = string.Format("w{0}", src.BitWidth);
            if(empty(width))
                width = src.OpWidth.Format();

            var desc = EmptyString;
            if(empty(type))
                desc = width;
            else
                desc = nonempty(width) ? string.Format("{0}/{1}", width, type) : type;

            return string.Format("{0} {1,-8} {2,-8} {3,-8} {4}", src.Index, src.Name, src.Kind, XedRender.semantic(src.Action), desc);
        }
    }
}