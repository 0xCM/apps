//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
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

            static void init(FieldRender r)
            {
                for(var i=0; i<FieldRender.Count; i++)
                {
                    var kind = (FieldKind)i;
                    switch(kind)
                    {
                        case K.AGEN:
                            r[kind] = (x => x.ToString());
                        break;

                        case K.ASZ:
                            r[kind] = (x => XedRender.format((ASZ)x));
                        break;

                        case K.BCAST:
                            r[kind] = (x => XedRender.format((BCastKind)x));
                        break;

                        case K.BCRC:
                            r[kind] = (x => ((bit)x).Format());
                        break;

                        case K.BRDISP_WIDTH:
                            r[kind] = (x => XedRender.format((DispWidth)x));
                        break;

                        case K.CET:
                            r[kind] = (x => ((bit)x).Format());
                        break;

                        case K.CHIP:
                            r[kind] = (x => XedRender.format((ChipCode)x));
                        break;

                        case K.CLDEMOTE:
                            r[kind] = (x => ((bit)x).Format());
                        break;

                        case K.DF32:
                            r[kind] = (x => ((bit)x).Format());
                        break;

                        case K.DF64:
                            r[kind] = (x => ((bit)x).Format());
                        break;

                        case K.DISP:
                            r[kind] = (x => ((bit)x).Format());
                        break;

                        // case K.DISP_WIDTH:
                        //     r[kind] = (x => XedRender.format((DispWidth)x));
                        // break;

                        // case K.ELEMENT_SIZE:
                        //     r[kind] = (x => XedRender.format((ElementSize)x));
                        // break;

                        case K.EASZ:
                            r[kind] = (x => XedRender.format((EASZ)x, FormatCode.BitWidth));
                        break;

                        case K.EOSZ:
                            r[kind] = (x => XedRender.format((EOSZ)x, FormatCode.BitWidth));
                        break;

                        case K.ESRC:
                            r[kind] = (x => XedRender.format((ESRC)x));
                        break;

                        case K.ICLASS:
                            r[kind] = (x => XedRender.format((InstClass)x));
                        break;

                        case K.MASK:
                            r[kind] = (x => XedRender.format((MaskReg)x));
                        break;

                        case K.OSZ:
                            r[kind] = (x => XedRender.format((OSZ)x, FormatCode.BitWidth));
                        break;

                        // case K.MAP:
                        //     r[kind] = (x => XedRender.format((OcMapKind)x));
                        // break;

                        case K.NOMINAL_OPCODE:
                            r[kind] = (x => XedRender.format((Hex8)x));
                        break;

                        case K.MOD:
                            r[kind] = (x => XedRender.format((uint2)x));
                        break;

                        case K.MODE:
                            r[kind] = (x => XedRender.format((MachineMode)x));
                        break;

                        case K.REP:
                            r[kind] = (x => XedRender.format((XedModels.RepPrefix)x));
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
                            r[kind] = (x => XedRender.format((SMODE)x,FormatCode.BitWidth));
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
                        case K.VL:
                            r[kind] = (x => XedRender.format((VexLength)x, FormatCode.BitWidth));
                        break;

                        case K.BASE0:
                        case K.BASE1:
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
}