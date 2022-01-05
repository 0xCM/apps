//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;
    using static XedModels;

    using FT = XedModels.FieldType;

    partial class IntelXed
    {
        public Index<FieldDef> EmitFieldDefs()
        {
            var src = ParseFieldDefs();
            EmitFieldDefs(src);
            return src;
        }

        public FS.FilePath EmitFieldDefs(ReadOnlySpan<FieldDef> src)
        {
            var dst = FieldDefsPath();
            TableEmit(src, FieldDef.RenderWidths, dst);
            return dst;
        }

        static TypeSpec CalcTypeSpec(FieldType @base, byte width)
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

        Index<FieldDef> ParseFieldDefs()
        {
            var src = FieldDefSource();
            var running = Running(string.Format("Parsing {0}", src.ToUri()));
            var dst = list<FieldDef>();
            var result = Outcome.Success;
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                var content = line.Content.Trim();
                if(text.empty(content) || text.begins(content,Chars.Hash))
                    continue;

                var cells = text.split(text.despace(content),Chars.Space);
                var count = cells.Length;
                if(count < 5)
                {
                    result = (false, string.Format("Only {0} cells found in {1}", count, content));
                    break;
                }

                var record = FieldDef.Empty;
                record.Name = skip(cells,0);

                ref readonly var type = ref skip(cells,2);

                if(!FieldTypes.ExprKind(type, out var ft))
                {
                    result = (false,string.Format("Unanticipated type {0}", type));
                    break;
                }

                ref readonly var width = ref skip(cells,3);
                result = DataParser.parse(width, out record.Width);
                if(result.Fail)
                {
                    result = (false,string.Format("Unable to parse width from {0}", width));
                    break;
                }

                record.Type = CalcTypeSpec(ft, record.Width);

                ref readonly var vsib = ref skip(cells,4);
                if(!Visibilities.ExprKind(vsib, out record.Visibility))
                {
                    result = (false,string.Format("Unanticipated visiblity {0}", vsib));
                    break;
                }

                dst.Add(record);
            }
            if(result)
            {
                Ran(running, string.Format("Parsed {0} records", dst.Count));
                return dst.ToArray();
            }
            else
            {
                Error(result.Message);
                return sys.empty<FieldDef>();
            }
        }
    }
}