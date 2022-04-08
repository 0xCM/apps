//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static XedRules;
    using static XedPatterns;
    using static XedModels;

    using static core;

    using K = XedRules.FieldKind;

    partial class XedFields
    {
        public class FieldRender
        {
            public const byte Count = 128;

            readonly Index<FieldKind,Func<ushort,string>> Functions;

            public FieldRender()
            {
                Functions = alloc<Func<ushort,string>>(Count);
                init(this);
            }

            public ref Func<ushort,string> this[FieldKind kind]
            {
                [MethodImpl(Inline)]
                get => ref Functions[kind];
            }
        }

        public static void init(FieldRender r)
        {
            for(var i=0; i<FieldRender.Count; i++)
            {
                var kind = (FieldKind)i;
                switch(kind)
                {
                    case K.CHIP:
                        r[kind] = (x => XedRender.format((ChipCode)x));
                    break;
                    case K.ICLASS:
                        r[kind] = (x => XedRender.format((InstClass)x));
                    break;
                    case K.NOMINAL_OPCODE:
                        r[kind] = (x => XedRender.format((Hex8)x));
                    break;
                    case K.EASZ:
                        r[kind] = (x => XedRender.format((EASZ)x,FormatCode.BitWidth));
                    break;
                    case K.EOSZ:
                        r[kind] = (x => XedRender.format((EOSZ)x,FormatCode.BitWidth));
                    break;
                    case K.MOD:
                        r[kind] = (x => XedRender.format((uint2)x));
                    break;
                    case K.MODE:
                        r[kind] = (x => XedRender.format((MachineMode)x));
                    break;
                    case K.MODRM_BYTE:
                        r[kind] = (x => ((ModRm)x).Format());
                    break;

                    case K.REG:
                        r[kind] = (x => XedRender.format((uint3)x));
                    break;
                    case K.RM:
                        r[kind] = (x => XedRender.format((uint3)x));
                    break;

                    case K.SRM:
                        r[kind] = (x => XedRender.format((uint3)x));
                    break;

                    case K.SMODE:
                        r[kind] = (x => XedRender.format((SMode)x,FormatCode.BitWidth));
                    break;

                    case K.VEXDEST210:
                        r[kind] = (x => XedRender.format((uint3)x));
                    break;
                    case K.VEXDEST3:
                        r[kind] = (x => XedRender.format((uint1)x));
                    break;
                    case K.VEXVALID:
                        r[kind] = (x => XedRender.format((VexClass)x));
                    break;
                    case K.VEX_PREFIX:
                        r[kind] = (x => XedRender.format((VexKind)x));
                    break;

                    case K.REG0:
                    case K.REG1:
                    case K.REG2:
                    case K.REG3:
                    case K.REG4:
                    case K.REG5:
                    case K.REG6:
                    case K.REG7:
                    case K.REG8:
                    case K.REG9:
                    case K.OUTREG:
                        r[kind] = (x => XedRender.format((Register)x));
                    break;
                    default:
                        r[kind] = (x => x.ToString());
                    break;
                }
            }
        }
    }
}