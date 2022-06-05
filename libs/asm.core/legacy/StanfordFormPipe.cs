//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static Msg;
    using static Chars;

    public class StanfordFormPipe : RecordPipe<StanfordFormPipe,StanfordForm>
    {
        public StanfordFormPipe()
        {

        }

        public void Emit(ReadOnlySpan<AsmFormInfo> src, FS.FilePath dst)
        {
            var count = src.Length;
            if(count == 0)
            {
                Warn("No work to do");
                return;
            }

            var flow = EmittingTable<StanfordForm>(dst);
            using var writer = dst.Writer();
            writer.WriteLine(FormatHeader());
            for(ushort i=0; i<count; i++)
            {
                var data = NewRecord();
                writer.WriteLine(Format(Fill(i, skip(src,i), ref data)));
            }
            EmittedTable(flow, count);
        }

        [MethodImpl(Inline)]
        ref StanfordForm Fill(ushort seq, AsmFormInfo src, ref StanfordForm dst)
        {
            dst.Seq = seq;
            dst.OpCode = src.OpCode;
            dst.Sig = src.Sig;
            dst.FormExpr = src;
            return ref dst;
        }

        public ReadOnlySpan<StanfordForm> LoadForms(in TextGrid src)
        {
            var rows = src.Rows;
            var count = rows.Length;
            var buffer = alloc<StanfordForm>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                if(i==0)
                    continue;

                ref readonly var _row = ref skip(rows,i);
                if(_row.CellCount != FieldCount)
                {
                    Error(FieldCountMismatch.Format(TableId, _row.CellCount, FieldCount));
                    return array<StanfordForm>();
                }
                row(_row, ref seek(dst,i));
            }
            return buffer;
        }

        public ReadOnlySpan<StanfordForm> LoadForms(FS.FilePath src)
        {
            var dst = list<StanfordForm>();
            if(src.Exists)
            {
                var flow = Running($"Loading form records from {src.ToUri()}");
                var doc = TextGrids.parse(src);
                if(doc.Failed)
                {
                    Error(doc.Reason);
                    return array<StanfordForm>();
                }

                var forms = LoadForms(doc.Value);
                Ran(flow, LoadedForms.Format(forms.Length, src));
                return forms;
            }
            else
            {
                Error($"The file <{src.ToUri()}> does not exist");
                return array<StanfordForm>();
            }
        }

        public Outcome ParseRow(TextLine src, out StanfordForm dst)
        {
            var parts = Cells(src.Content);
            var count = parts.Length;
            if(count == FieldCount)
            {
                var i = 0u;
                DataParser.parse(NextCell(parts, ref i), out dst.Seq);
                dst.OpCode = NextCell(parts, ref i);
                AsmSigInfo.parse(NextCell(parts, ref i), out dst.Sig);
                dst.FormExpr = new AsmFormInfo(dst.OpCode, dst.Sig);
                return true;
            }
            else
            {
                dst = default;
                return (false, FieldCountMismatch.Format(TableId, count, FieldCount));
            }
        }

        [MethodImpl(Inline)]
        ref readonly string NextCell(ReadOnlySpan<string> src, ref uint i)
            => ref skip(src, i++);

        [Parser]
        static Outcome forminfo(string src, out AsmFormInfo dst)
        {
            dst = AsmFormInfo.Empty;
            var result = Outcome.Success;

            result = text.unfence(src, SigFence, out var sigexpr);
            if(result.Fail)
                return (false, AppMsg.FenceNotFound.Format(src,SigFence));

            result = AsmSigInfo.parse(sigexpr, out var _sig);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format("Sig", sigexpr));

            result = text.unfence(src, OpCodeFence, out var opcode);
            if(result.Fail)
                return (false, AppMsg.FenceNotFound.Format(src,OpCodeFence));

            dst = new AsmFormInfo(opcode, _sig);
            return true;
        }

        static ref StanfordForm row(in TextRow src, ref StanfordForm dst)
        {
            var i = 0;
            DataParser.parse(src[i++], out dst.Seq);
            dst.OpCode = src[i++];
            AsmSigInfo.parse(src[i++], out dst.Sig);
            forminfo(src[i++], out dst.FormExpr);
            return ref dst;
        }


        static Fence<char> SigFence => (LParen, RParen);

        static Fence<char> OpCodeFence => (Lt, Gt);

        const string Implication = " => ";
    }
}