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
                OpAction.RW => "i/o",
                OpAction.CR => "?in",
                OpAction.CW => "?out",
                OpAction.CRW => "?i/?o",
                OpAction.RCW => "?i/o",
                _ => EmptyString,
            };

        public static string semantic(OpCodeKind src)
        {
            var @class = XedPatterns.occlass(src);
            var kind = EmptyString;
            switch(@class)
            {
                case OpCodeClass.Base:
                    switch(src)
                    {
                        case OpCodeKind.Base00:
                            kind = "00";
                        break;
                        case OpCodeKind.Base0F:
                            kind = "0F";
                        break;
                        case OpCodeKind.Base0F38:
                            kind = "0F38";
                        break;
                        case OpCodeKind.Base0F3A:
                            kind = "0F3A";
                        break;
                    }
                break;
                case OpCodeClass.Vex:
                    switch(src)
                    {
                        case OpCodeKind.Vex0F:
                            kind = "0F";
                        break;
                        case OpCodeKind.Vex0F38:
                            kind = "0F38";
                        break;
                        case OpCodeKind.Vex0F3A:
                            kind = "0F3A";
                        break;
                    }
                break;
                case OpCodeClass.Evex:
                    switch(src)
                    {
                        case OpCodeKind.Evex0F:
                            kind = "0F";
                        break;
                        case OpCodeKind.Evex0F38:
                            kind = "0F38";
                        break;
                        case OpCodeKind.Evex0F3A:
                            kind = "0F3A";
                        break;
                    }
                break;
                case OpCodeClass.Xop:
                    switch(src)
                    {
                        case OpCodeKind.XOP8:
                            kind = "08";
                        break;
                        case OpCodeKind.XOP9:
                            kind = "09";
                        break;
                        case OpCodeKind.XOPA:
                            kind = "0A";
                        break;
                    }
                break;
                case OpCodeClass.Amd3D:
                    kind = "3D";
                break;
            }
            return kind;
        }

        public static string semantic(XedOpCode src)
            => string.Format("{0}[{1}:{2}]", src.Class, semantic(src.Kind), src.Value);

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