//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedPatterns
    {
        public struct InstPatternSpec : IComparable<InstPatternSpec>
        {
            public uint PatternId;

            public uint InstId;

            public MachineMode Mode;

            public InstIsa Isa;

            public Category Category;

            public Extension Extension;

            public InstClass InstClass;

            public InstForm InstForm;

            public InstAttribs Attributes;

            public Index<XedFlagEffect> Effects;

            public XedOpCode OpCode;

            public TextBlock BodyExpr;

            public TextBlock RawBody;

            public InstPatternBody Body;

            public PatternOps Ops;

            public static void FixIsa(ref InstPatternSpec src)
            {
                if(src.Isa.IsEmpty)
                {
                    switch(src.Extension.Kind)
                    {
                        case ExtensionKind._3DNOW:
                            src.Isa = IsaKind._3DNOW;
                        break;
                        case ExtensionKind.INVPCID:
                            src.Isa = IsaKind.INVPCID;
                        break;
                        case ExtensionKind.PCLMULQDQ:
                            src.Isa = IsaKind.PCLMULQDQ;
                        break;
                        case ExtensionKind.FMA4:
                            src.Isa = IsaKind.FMA4;
                        break;
                        case ExtensionKind.F16C:
                            src.Isa = IsaKind.F16C;
                        break;
                        case ExtensionKind.X87:
                            src.Isa = IsaKind.X87;
                        break;
                        case ExtensionKind.AES:
                            src.Isa = IsaKind.AES;
                        break;
                        case ExtensionKind.AVX:
                            src.Isa = IsaKind.AVX;
                        break;
                        case ExtensionKind.AVX2:
                            src.Isa = IsaKind.AVX2;
                        break;
                        case ExtensionKind.BMI1:
                            src.Isa = IsaKind.BMI1;
                        break;
                        case ExtensionKind.BMI2:
                            src.Isa = IsaKind.BMI2;
                        break;
                        case ExtensionKind.LONGMODE:
                            src.Isa = IsaKind.LONGMODE;
                        break;
                        case ExtensionKind.CLZERO:
                            src.Isa = IsaKind.CLZERO;
                        break;
                        case ExtensionKind.FMA:
                            src.Isa = IsaKind.FMA;
                        break;
                        case ExtensionKind.LZCNT:
                            src.Isa = IsaKind.LZCNT;
                            break;
                        case ExtensionKind.SSE:
                            src.Isa = IsaKind.SSE;
                        break;
                        case ExtensionKind.SSE2:
                            src.Isa = IsaKind.SSE2;
                        break;
                        case ExtensionKind.SSE3:
                            src.Isa = IsaKind.SSE3;
                        break;
                        case ExtensionKind.SSE4:
                            src.Isa = IsaKind.SSE4;
                        break;
                        case ExtensionKind.VTX:
                            src.Isa = IsaKind.VTX;
                        break;
                        case ExtensionKind.SSE4A:
                            src.Isa = IsaKind.SSE4A;
                        break;
                        case ExtensionKind.SSSE3:
                            src.Isa = IsaKind.SSSE3;
                        break;
                        case ExtensionKind.TBM:
                            src.Isa = IsaKind.TBM;
                        break;
                        case ExtensionKind.XSAVE:
                            src.Isa = IsaKind.XSAVE;
                        break;
                        case ExtensionKind.XSAVEC:
                            src.Isa = IsaKind.XSAVEC;
                        break;
                        case ExtensionKind.XSAVEOPT:
                            src.Isa = IsaKind.XSAVEOPT;
                        break;
                        case ExtensionKind.XSAVES:
                            src.Isa = IsaKind.XSAVES;
                        break;
                        default:
                        {

                        }
                        break;
                    }
                }
            }
            public int CompareTo(InstPatternSpec src)
            {
                var result = InstId.CompareTo(src.InstId);
                if(result == 0)
                {
                    result = InstClass.CompareTo(src.InstClass);
                    if(result == 0)
                    {
                        result = OpCode.CompareTo(src.OpCode);
                        if(result == 0)
                        {
                            if(InstForm.IsNonEmpty)
                                result = InstForm.CompareTo(src.InstForm);
                            if(result == 0)
                                result = BodyExpr.CompareTo(src.BodyExpr);
                        }
                    }
                }
                return result;
            }

            [MethodImpl(Inline)]
            public PatternSort Sort()
                => new PatternSort(this);

            public static InstPatternSpec Empty => default;
        }
    }
}