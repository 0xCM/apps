//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    public class NasmCatalog : AppService<NasmCatalog>
    {
        static bool comment(string src)
            => src.Length > 0 && src[0] == Chars.Semicolon;

        static ReadOnlySpan<char> encoding(string src)
            => text.replace(text.inside(src, Chars.LBracket, Chars.RBracket), Chars.Tab,Chars.Space).Trim();

        static ReadOnlySpan<char> operands(ReadOnlySpan<char> src)
        {
            var i0 = text.index(src,Chars.Tab, Chars.Space);
            if(i0 >0)
            {
                var i1 = text.index(src, i0 + 1, Chars.LBracket);
                if(i1 >0)
                    return text.segment(src,i0 + 1, i1 - 1).Trim();
            }
            return default;
        }

        public ReadOnlySpan<NasmInstruction> ParseInstructions(FS.FilePath src)
        {
            const uint FirstLine = 70;
            var lines = slice(src.ReadNumberedLines(), FirstLine);
            var count = lines.Length;
            var section = EmptyString;
            var buffer = span<NasmInstruction>(count);
            var j = 0u;
            var widths = NasmInstruction.RenderWidths;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                var content = line.Trim().Text.Replace(Chars.Pipe, Chars.Caret);

                if(content.Length < 2)
                    continue;

                if(comment(content))
                    continue;

                ref var dst = ref seek(buffer,j++);
                var pad = z16;
                dst.Sequence = j;
                dst.Mnemonic = text.absolute(content.LeftOfFirst(Chars.Tab), skip(widths,1));
                dst.Operands = text.absolute(text.format(operands(content)), skip(widths,2));
                dst.Encoding = text.absolute(text.format(encoding(content)), skip(widths,3));
                var flags = content.RightOfFirst(Chars.RBracket).Trim().Replace(Chars.Tab, Chars.Space);
                dst.Flags = text.absolute(flags, skip(widths,4));
            }

            return slice(buffer, 0, j);
        }

        public ReadOnlySpan<NasmInstruction> ImportInstructions()
        {
            var src = Ws.Sources().Datasets(AsmTableScopes.Nasm) + FS.file("nasm.instructions", FS.Txt);
            var dst = Ws.Tables().TablePath<NasmInstruction>(AsmTableScopes.Nasm);
            return ImportInstructions(src,dst);
        }

        public ReadOnlySpan<NasmInstruction> ImportInstructions(FS.FilePath src, FS.FilePath dst)
        {
            var instructions = ParseInstructions(src);
            var count = instructions.Length;
            if(count != 0)
            {
                var flow = Wf.EmittingTable<NasmInstruction>(dst);
                var emitted = Tables.emit(instructions, NasmInstruction.RenderWidths, TextEncodingKind.Unicode, dst);
                Wf.EmittedTable(flow, emitted);
                return instructions;
            }
            else
                return default;
        }

        public ReadOnlySpan<NasmInstruction> LoadInstructionImports()
        {
            var src = Ws.Tables().TablePath<NasmInstruction>(AsmTableScopes.Nasm);
            return LoadInstructionImports(src);
        }

        public ReadOnlySpan<NasmInstruction> LoadInstructionImports(FS.FilePath src)
        {
            using var reader = src.UnicodeLineReader();
            var counter = 0u;
            var dst = list<NasmInstruction>();
            while(reader.Next(out var line))
            {
                var splits = line.Content.Split(Chars.Pipe);
                var count = splits.Length;
                if(count != NasmInstruction.FieldCount)
                    Error(Tables.FieldCountMismatch.Format(NasmInstruction.FieldCount, count));

                if(counter != 0)
                {
                    var j=0u;
                    var record = new NasmInstruction();
                    DataParser.parse(skip(splits,j++), out record.Sequence);
                    record.Mnemonic = skip(splits,j++);
                    record.Operands = skip(splits,j++);
                    record.Encoding = skip(splits,j++);
                    record.Flags = skip(splits,j++);
                    dst.Add(record);
                }

                counter++;

            }
            return dst.ViewDeposited();
        }
    }
}