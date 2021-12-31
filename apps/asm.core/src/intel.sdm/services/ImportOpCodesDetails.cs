//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;
    using static SdmModels;

    using SQ = SymbolicQuery;

    partial class IntelSdm
    {
        public Index<SdmOpCodeDetail> ImportOpCodes()
        {
            var result = Outcome.Success;
            var details = ImportOpCodeDetails();
            var forms = EmitForms(details);
            var summary = SdmOpCodes.summarize(details);
            var count = summary.Length;
            var dst = SdmPaths.ImportPath("sdm.opcodes", FS.Txt);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
                writer.WriteLine(SdmOpCodes.format(summary[i]));
            EmittedFile(emitting,count);
            return details;
        }

        public Index<ListItem<string>> ExtractOpCodeStrings(ReadOnlySpan<SdmOpCode> src)
        {
            var count = src.Length;
            var items = list<string>(count);
            var counter = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var detail = ref skip(src,i);
                var fmt = detail.Expr.Format().Trim();
                if(nonempty(fmt))
                {
                    items.Add(fmt);
                    counter++;
                }

            }
            items.Sort();
            return items.ToArray().Mapi((i,x) => new ListItem<string>((uint)i,x));
        }

        Index<SdmOpCodeDetail> ImportOpCodeDetails()
            => ImportOpCodeDetails(SdmPaths.Sources("sdm.instructions").Files(FS.Csv).ToReadOnlySpan());

        Index<SdmOpCodeDetail> ImportOpCodeDetails(ReadOnlySpan<FS.FilePath> src)
        {
            var running = Running(string.Format("Importing opcodes from {0} source files", src.Length));
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
                        counter += Fill(table, current);
                    }
                }
            }

            var rows = slice(buffer,0,counter).ToArray().Sort();
            for(var i=0u; i<rows.Length; i++)
                seek(rows,i).OpCodeKey = i;

            var dst = SdmPaths.ImportTable<SdmOpCodeDetail>();
            using var writer = dst.UnicodeWriter();
            TableEmit(@readonly(rows), SdmOpCodeDetail.RenderWidths, writer, dst);

            Ran(running);
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


        public static Index<TableColumn> columns(ReadOnlySpan<string> src)
            => Tables.columns<SdmColumnKind>(src);

        [Op]
        uint Fill(Table src, Span<SdmOpCodeDetail> dst)
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
                    var name = text.trim(col.Name);
                    if(empty(content))
                        continue;

                    if(empty(name))
                    {
                        Warn(string.Format("Unnamed column with content '{0}'", content));
                        continue;
                    }
                    switch(name)
                    {
                        case "Opcode":
                        var oc = NormalizeOpcode(content);
                        target.OpCode = text.despace(oc);
                        if(empty(oc))
                            valid = false;
                        break;

                        case "Instruction":
                            var monic = text.trim(text.ifempty(text.left(content, Chars.Space), content));
                            if(empty(monic))
                            {
                                valid = false;
                                break;
                            }

                            var ops = CalcOperands(content);
                            if(nonempty(ops))
                                target.Sig = string.Format("{0} {1}", monic, ops);
                            else
                                target.Sig = monic;
                            target.Mnemonic = monic;
                            valid = true;
                        break;

                        case "Op En":
                        case "Op/ En":
                        case "Op / En":
                        case "Op/En":
                        case "Op /En":
                            target.EncXRef = content;
                            valid = true;
                        break;

                        case "Compat/Leg Mode":
                            target.LegacyMode = content;
                            if(content == "N.E.")
                                target.LegacyMode = "Invalid";
                            valid = true;
                        break;

                        case "64-Bit Mode":
                        case "64-bit Mode":
                            target.Mode64 = content;
                            if(content == "N.E." || content == "N.S." | content == "Inv.")
                                target.Mode64 = "Invalid";
                            valid = true;
                        break;

                        case "64/32-bit Mode":
                        case "64/32 -bit Mode":
                        case "64/32 bit Mode Support":
                            target.Mode64x32 = content;
                            if(text.trim(text.left(content, Chars.FSlash)) == "V")
                                target.Mode64 = "Valid";
                            valid = true;
                        break;

                        case "CPUID":
                        case "CPUID Feature Flag":
                            target.CpuId = content;
                            valid = true;
                        break;

                        case "Description":
                            target.Description = content;
                            valid = true;
                        break;
                        case "Operand1":
                        case "Operand 1":
                        case "Operand2":
                        case "Operand 2":
                        case "Operand3":
                        case "Operand 3":
                        case "Operand4":
                        case "Operand 4":
                            valid = false;
                            break;

                        default:
                            valid = false;
                            Warn(string.Format("Column {0} unrecognized", col.Name));
                            break;
                    }
                }

                if(valid)
                    seek(dst, counter++) = target;
            }
            return counter;
        }

        string NormalizeOpcode(string src)
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

        string CalcOperands(string sig)
        {
            ReadOnlySpan<string> _operands(string src)
                => text.trim(text.split(src, Chars.Comma)).Select(CalcOperand);

            var i = SQ.index(sig, Chars.Space);
            if(i > 0)
                return text.join(", ", _operands(text.format(SQ.right(sig,i))));
            else
                return EmptyString;
        }

        string CalcOperand(string op)
        {
            var n = text.index(op, Chars.FSlash);
            var dst = op;
            if(text.fenced(dst,RenderFence.Angled))
                dst = text.unfence(dst,RenderFence.Angled);

            if(n > 0)
            {
                var m = text.index(dst, Chars.Space);
                if(m > n)
                {
                    var components = text.join(Chars.FSlash, text.trim(text.split(text.left(dst,m), Chars.FSlash)));
                    dst = string.Format("{0} {1}", components, text.right(dst,m));
                }
                else
                    dst = text.join(Chars.FSlash, text.trim(text.split(dst, Chars.FSlash)));
            }
            return SigOpNormal.Apply(dst);
        }
    }
}