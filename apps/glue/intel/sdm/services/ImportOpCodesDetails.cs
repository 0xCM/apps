//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections.Generic;

    using static Root;
    using static core;
    using static SdmModels;

    using SQ = SymbolicQuery;

    public struct SdmOperandSymbolizer
    {


    }

    partial class IntelSdm
    {
        public void ImportOpCodes()
        {
            var result = Outcome.Success;
            var details = ImportOpCodeDetails();
            var forms = EmitForms(details);
            EmitStringTable(details);
            var _opcodes = SdmOpCodes.summarize(details).View;
            var count = _opcodes.Length;
            var dst = SdmPaths.ImportPath("sdm.opcodes", FS.Txt);

            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
                writer.WriteLine(SdmOpCodes.format(skip(_opcodes,i)));

            EmittedFile(emitting,count);
        }

        Index<SdmOpCodeDetail> ImportOpCodeDetails()
            => ImportOpCodeDetails(SdmPaths.Sources("sdm.instructions").Files(FS.Csv).ToReadOnlySpan());

        Index<SdmOpCodeDetail> ImportOpCodeDetails(ReadOnlySpan<FS.FilePath> src)
        {
            var result = Outcome.Success;
            var count = src.Length;
            var kinds = Symbols.index<SdmTableKind>();
            Index<SdmOpCodeDetail> storage = alloc<SdmOpCodeDetail>(4000);
            var buffer = storage.Edit;
            var counter = 0u;
            var _tables = list<Table>();
            for(var i=0; i<count; i++)
            {
                ref readonly var inpath = ref skip(src,i);
                var tables = LoadCsvTables(inpath);
                var id = inpath.FileName.WithoutExtension.Format();
                for(var j=0; j<tables.Length; j++)
                {
                    ref readonly var table = ref skip(tables,j);
                    var kind = (SdmTableKind)table.Kind;
                    ref readonly var symbol = ref kinds[kind];
                    if(kind == SdmTableKind.OpCodes)
                    {
                        var current = slice(buffer, counter);
                        counter += fill(table, current);
                    }
                }
            }

            var rows = slice(buffer,0,counter).ToArray().Sort();
            for(var i=0u; i<rows.Length; i++)
                seek(rows,i).OpCodeKey = i;

            var dst = SdmPaths.ImportTable<SdmOpCodeDetail>();
            using var writer = dst.UnicodeWriter();
            TableEmit(@readonly(rows), SdmOpCodeDetail.RenderWidths, writer, dst);
            return rows;
        }

        Index<AsmForm> EmitForms(ReadOnlySpan<SdmOpCodeDetail> opcodes)
        {
            const string Pattern = "{0,-16} | {1,-64} | {2}";
            const string OpSep = ", ";
            var dst = SdmPaths.ImportPath("asm.forms", FS.Csv);
            var emitting = EmittingTable<AsmForm>(dst);
            using var writer = dst.UnicodeWriter();
            var _forms = SdmOpCodes.forms(opcodes);
            var count = _forms.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref _forms[i];
                ref readonly var sig = ref form.Sig;
                var operands = EmptyString;
                var opcount = form.Sig.OperandCount;
                switch(opcount)
                {
                    case 1:
                        operands = AsmSigs.operand(sig,0).Format();
                    break;
                    case 2:
                        operands = string.Format(RP.delimit(n2, OpSep),
                            AsmSigs.operand(sig,0),
                            AsmSigs.operand(sig,1)
                            );
                    break;
                    case 3:
                        operands = string.Format(RP.delimit(n3, OpSep),
                            AsmSigs.operand(sig,0),
                            AsmSigs.operand(sig,1),
                            AsmSigs.operand(sig,2)
                            );
                    break;
                    case 4:
                        operands = string.Format(RP.delimit(n4, OpSep),
                            AsmSigs.operand(sig,0),
                            AsmSigs.operand(sig,1),
                            AsmSigs.operand(sig,2),
                            AsmSigs.operand(sig,3)
                            );
                    break;
                    default:
                    break;
                }
                writer.WriteLine(string.Format(Pattern, form.Sig.Mnemonic, operands, form.OpCode.Format()));
            }

            EmittedTable(emitting, count);

            return _forms;
        }

        Outcome EmitStringTable(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var result = Outcome.Success;
            var count = src.Length;
            var items = alloc<ListItem<string>>(count);
            for(var i=0u; i<count; i++)
                seek(items,i) = (i,skip(src,i).OpCode);

            var spec = StringTables.specify("Z0.Asm", "OpCodeStrings", items);
            result = StringTableGen.Generate(spec, SdmPaths.StringTables());
            return result;
        }

        public static Index<TableColumn> columns(ReadOnlySpan<string> src)
            => Tables.columns<SdmColumnKind>(src);

        [Op]
        static uint fill(Table src, Span<SdmOpCodeDetail> dst)
        {
            var counter = 0u;
            var rows = src.Rows;
            var count = rows.Length;
            var cols = src.Cols;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(rows,i);
                var target = new SdmOpCodeDetail();
                var cells = input.Cells;
                var valid = true;

                for(var k=0; k<cells.Length; k++)
                {
                    ref readonly var col = ref skip(cols,k);
                    ref readonly var cell = ref skip(cells,k);
                    var content = text.format(cell.Content).Trim();
                    switch(col.Name)
                    {
                        case "Opcode":
                        var oc = ocnormal(content);
                        target.OpCode = oc;
                        if(empty(oc))
                            valid = false;
                        break;

                        case "Instruction":
                            var monic = text.trim(text.ifempty(text.left(content, Chars.Space), content));
                            var ops = operands(content);
                            if(nonempty(ops))
                                target.Sig = string.Format("{0} {1}", monic, ops);
                            else
                                target.Sig = monic;
                            target.Mnemonic = monic;
                            if(empty(monic))
                                valid = false;
                        break;

                        case "Op / En":
                        case "Op/En":
                            target.EncXRef = content;
                        break;

                        case "Compat/Leg Mode":
                            target.LegacyMode = content;
                        break;

                        case "64-bit Mode":
                            target.Mode64 = content;
                        break;

                        case "64/32 -bit Mode":
                        case "64/32 bit Mode Support":
                            target.Mode64x32 = content;
                        break;

                        case "CPUID Feature Flag":
                            target.CpuId = content;
                        break;

                        case "Description":
                            target.Description = content;
                        break;
                    }
                }

                if(valid)
                    seek(dst, counter++) = target;
            }
            return counter;
        }

        static string ocnormal(string src)
        {
            return
                src.Replace("+ rb", " +rb")
                    .Replace("+ rw", " +rw")
                    .Replace("+ rd", " +rd")
                    .Replace("+ ro", " +ro")
                    .Replace("/ r", "/r")
                    .Trim()
                    ;
        }

        static string opnormal(string src)
            => src switch {
                "r32a" => "r32",
                "r32b" => "r32",
                "r64a" => "r64",
                "r64b" => "r64",
                "mm1" => "mm",
                "mm2" => "mm",
                "mm2/m64" => "mm/m64",
                "xmm1" => "xmm",
                "xmm1/m128" => "xmm/m128",
                "xmm2" => "xmm",
                "xmm2/m128" => "xmm/m128",
                "xmm3" => "xmm",
                "xmm3/m128" => "xmm/m128",
                "ymm1" => "ymm",
                "ymm2" => "ymm",
                "ymm2/m256" => "ymm/m256",
                "ymm3/m256 " => "ymm/m256",
                "ymm3/m256/m64bcst" => "ymm/m256/m64bcst",
                "zmm1" => "zmm",
                "zmm2" => "zmm",
                "zmm2/m512" => "zmm/m512",
                "zmm3" => "zmm",
                "xmm3/m128/m32bcst" => "xmm/m128/m32bcst",
                "xmm3/m128/m64bcst" => "xmm/m128/m64bcst",
                _ => src
            };

        static string operands(string sig)
        {
            static ReadOnlySpan<string> _operands(string src)
                => text.split(src, Chars.Comma).Select(op => opnormal(op.Trim()));

            var i = SQ.index(sig, Chars.Space);
            if(i > 0)
                return text.join(", ", _operands(text.format(SQ.right(sig,i))));
            else
                return EmptyString;
        }
    }
}