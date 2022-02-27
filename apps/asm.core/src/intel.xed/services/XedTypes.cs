//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    using FT = XedModels.FieldType;

    public class XedTypes : AppService<XedTypes>
    {
        TypeParser TypeParser => Service(Wf.TypeParser);

        public static Identifier spec(FieldType @base, byte width)
        {
            var dst = Identifier.Empty;
            switch(@base)
            {
                case FT.Bits:
                    switch(width)
                    {
                        case 1:
                            dst = nameof(bit);
                        break;
                        case 2:
                            dst = nameof(uint2);
                        break;
                        case 3:
                            dst = nameof(uint3);
                        break;
                        case 4:
                            dst = nameof(uint4);
                        break;
                        case 5:
                            dst = nameof(uint5);
                        break;
                        case 6:
                            dst = nameof(uint6);
                        break;
                        case 7:
                            dst = nameof(uint7);
                        break;
                        case 8:
                            dst = nameof(eight);
                        break;
                        default:
                        {
                            if(width <= 16)
                                dst = CsKeywords.U16;
                            else if(width <= 32)
                                dst = CsKeywords.U32;
                            else if(width <= 64)
                                dst = CsKeywords.U64;
                            else
                                dst = RP.Error;
                        }
                        break;
                    }
                break;
                case FT.Reg:
                    dst = TypeSyntax.@enum(nameof(XedRegId)).Format();
                break;
                case FT.IClass:
                    dst = TypeSyntax.@enum(nameof(IClass)).Format();
                break;
                case FT.Chip:
                    dst = TypeSyntax.@enum(nameof(ChipCode)).Format();
                break;
                case FT.U8:
                    dst = CsKeywords.U8;
                break;
                case FT.U16:
                    dst = CsKeywords.U16;
                break;
                case FT.U32:
                    dst = CsKeywords.U32;
                break;
                case FT.U64:
                    dst = CsKeywords.U64;
                break;
                case FT.I8:
                    dst = CsKeywords.I8;
                break;
                case FT.I16:
                    dst = CsKeywords.I16;
                break;
                case FT.I32:
                    dst = CsKeywords.I32;
                break;
                case FT.I64:
                    dst = CsKeywords.I64;
                break;
                case FT.Error:
                    dst = TypeSyntax.@enum(nameof(ErrorKind)).Format();
                break;
            }

            return dst;
        }

        public Outcome Concretize(TypeSpec src, out Type dst)
        {
            var result = Outcome.Success;
            dst = typeof(void);

            if(TypeParser.IsParametric(src))
            {
                var parameters = TypeParser.Parameters(src);
            }

            return result;
        }
    }
}