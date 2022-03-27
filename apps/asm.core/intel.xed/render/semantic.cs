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
            var @class = XedPatterns.@class(src);
            var kind = EmptyString;
            switch(@class)
            {
                case OpCodeClass.Legacy:
                    switch(src)
                    {
                        case OpCodeKind.LEGACY_00:
                            kind = "00";
                        break;
                        case OpCodeKind.LEGACY_0F:
                            kind = "0F";
                        break;
                        case OpCodeKind.LEGACY_0F38:
                            kind = "0F38";
                        break;
                        case OpCodeKind.LEGACY_0F3A:
                            kind = "0F3A";
                        break;
                    }
                break;
                case OpCodeClass.Vex:
                    switch(src)
                    {
                        case OpCodeKind.VEX_0F:
                            kind = "0F";
                        break;
                        case OpCodeKind.VEX_0F38:
                            kind = "0F38";
                        break;
                        case OpCodeKind.VEX_0F3A:
                            kind = "0F3A";
                        break;
                    }
                break;
                case OpCodeClass.Evex:
                    switch(src)
                    {
                        case OpCodeKind.EVEX_0F:
                            kind = "0F";
                        break;
                        case OpCodeKind.EVEX_0F38:
                            kind = "0F38";
                        break;
                        case OpCodeKind.EVEX_0F3A:
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
    }
}