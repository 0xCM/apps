//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRecords;

    using FT = XedModels.FieldType;

    public class XedTypes : AppService<XedTypes>
    {
        TypeParser TypeParser => Service(Wf.TypeParser);

        public static TypeSpec spec(FieldType @base, byte width)
        {
            var dst = TypeSpec.Empty;
            switch(@base)
            {
                case FT.Bits:
                    if(width == 1)
                        dst = TypeSyntax.bit();
                    else
                        dst = TypeSyntax.bits(width);
                break;
                case FT.Reg:
                    dst = TypeSyntax.@enum(nameof(XedRegId), TypeSyntax.u16());
                break;
                case FT.IClass:
                    dst = TypeSyntax.@enum(nameof(IClass), TypeSyntax.u16());
                break;
                case FT.Chip:
                    dst = TypeSyntax.@enum(nameof(ChipCode), TypeSyntax.u8());
                break;
                case FT.U8:
                    dst = TypeSyntax.u8();
                break;
                case FT.U16:
                    dst = TypeSyntax.u16();
                break;
                case FT.U32:
                    dst = TypeSyntax.u32();
                break;
                case FT.U64:
                    dst = TypeSyntax.u64();
                break;
                case FT.I8:
                    dst = TypeSyntax.i8();
                break;
                case FT.I16:
                    dst = TypeSyntax.i16();
                break;
                case FT.I32:
                    dst = TypeSyntax.i64();
                break;
                case FT.I64:
                    dst = TypeSyntax.i64();
                break;
                case FT.Error:
                    dst = TypeSyntax.@enum(nameof(ErrorKind), TypeSyntax.u8());
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