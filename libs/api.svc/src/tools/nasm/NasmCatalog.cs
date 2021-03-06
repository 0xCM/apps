//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class NasmCatalog : AppService<NasmCatalog>
    {
        AppSvcOps AppSvc => Wf.AppSvc();

        static AppDb AppDb => AppDb.Service;

        static bool comment(ReadOnlySpan<char> src)
            =>  src.Length != 0 && first(src) == Chars.Semicolon;

        static ReadOnlySpan<char> encoding(string src)
            => text.trim(text.replace(text.inside(src, Chars.LBracket, Chars.RBracket), Chars.Tab,Chars.Space));

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

            Write(string.Format("Parsing {0}", src));
            if(!src.Exists)
            {
                Error(FS.missing(src));
                return default;
            }

            var input = src.ReadNumberedLines();
            if(input.Length < 80)
            {
                Error(string.Format("Bad format: {0}", src));
                return default;
            }

            Write(string.Format("Read {0} source lines", input.Length));

            var lines = slice(input.View, FirstLine);
            var count = lines.Length;
            var section = EmptyString;
            var buffer = span<NasmInstruction>(count);
            var j = 0u;
            var widths = NasmInstruction.RenderWidths;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                var content = text.replace(text.trim(line.Content), Chars.Pipe, Chars.Caret);

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
            => ImportInstructions(
                AppDb.DbIn().Path(FS.file("nasm.instructions", FS.Txt)),
                AppDb.DbOut().Targets("asm.refs").Table<NasmInstruction>()
                );

        ReadOnlySpan<NasmInstruction> ImportInstructions(FS.FilePath src, FS.FilePath dst)
        {
            var instructions = ParseInstructions(src);
            AppSvc.TableEmit(instructions, dst, TextEncodingKind.Unicode);
            return instructions;
        }

        public ReadOnlySpan<NasmInstruction> LoadInstructionImports()
            => LoadInstructionImports(AppDb.DbOut().Targets("asm.refs").Table<NasmInstruction>());

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