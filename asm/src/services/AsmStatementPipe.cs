//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Text;

    using static Root;
    using static core;

    public sealed class AsmStatementPipe : AppService<AsmStatementPipe>
    {
        AsmDecoder Decoder;

        protected override void OnInit()
        {
            Decoder = Wf.AsmDecoder();
        }

        public SortedReadOnlySpan<ProcessAsmRecord> BuildProcessAsm(ReadOnlySpan<AsmRoutine> src)
        {
            var kRountines = src.Length;
            if(kRountines == 0)
                return default;

            var total = ApiInstructions.count(src);
            var buffer = span<ProcessAsmRecord>(total);
            ref var dst = ref first(buffer);
            var counter = 0u;
            var @base = skip(src,0).BaseAddress;
            for(var i=0u; i<kRountines; i++)
            {
                ref readonly var routine = ref skip(src,i);
                var instructions = routine.Instructions.View;
                var icount = instructions.Length;
                if(icount == 0)
                    continue;

                var bytes = routine.Code.Data.ToReadOnlySpan();
                var i0 = first(instructions);
                var blockBase = i0.IP;
                var blockOffset = z16;
                for(var j=0; j<icount; j++)
                {
                    var instruction = skip(instructions,j).Instruction;
                    var opcode = asm.ocstring(instruction.OpCode.ToString());
                    if(!opcode.IsValid)
                        break;

                    var statement = new ProcessAsmRecord();
                    var size = (ushort)instruction.ByteLength;
                    var specifier = instruction.Specifier;
                    var ip = (MemoryAddress)instruction.IP;
                    statement.Sequence = counter++;
                    statement.GlobalOffset = (Address32)(ip - @base);
                    statement.BlockAddress = blockBase;
                    statement.BlockOffset = blockOffset;
                    statement.IP = ip;
                    statement.OpUri = routine.Uri;
                    statement.Statement = instruction.FormattedInstruction;
                    AsmParser.sigxpr(instruction.OpCode.InstructionString, out statement.Sig);
                    statement.Encoded = AsmHexCode.load(slice(bytes, blockOffset, size));
                    statement.OpCode = opcode;
                    statement.Bitstring = statement.Encoded;
                    seek(buffer,counter) = statement;

                    blockOffset += size;
                }
            }

            return Spans.sorted(@readonly(slice(buffer,1,counter)));
        }

        public uint EmitProcessAsm(SortedReadOnlySpan<ProcessAsmRecord> src, FS.FilePath dst)
            => TableEmit(src.View, ProcessAsmRecord.RenderWidths, ProcessAsmRecord.RowPad, Encoding.ASCII, dst);

        public ReadOnlySpan<ProcessAsmRecord> EmitProcessAsm(ReadOnlySpan<AsmRoutine> src, FS.FilePath dst)
        {
            var rows = BuildProcessAsm(src);
            EmitProcessAsm(rows, dst);
            return rows;
        }

        public SortedReadOnlySpan<ProcessAsmRecord> BuildProcessAsm(SortedSpan<ApiCodeBlock> src)
        {
            var count = src.Length;
            if(count == 0)
                return default;

            var dst = list<ProcessAsmRecord>();
            var counter = 0u;
            var @base = src[0].BaseAddress;

            for(var i=0u; i<count; i++)
            {
                ref readonly var code = ref src[i];
                var decoded = Decode(code);
                var instructions = decoded.Instructions;
                var icount = instructions.Length;
                if(icount == 0)
                    continue;

                var bytes = code.Bytes;
                var i0 = first(instructions);
                var blockBase = (MemoryAddress)i0.IP;
                var blockOffset = z16;
                for(var j=0; j<icount; j++)
                {
                    var instruction = skip(instructions,j);
                    var opcode = asm.ocstring(instruction.OpCode.ToString());
                    if(!opcode.IsValid)
                        break;

                    var statement = new ProcessAsmRecord();
                    var size = (ushort)instruction.ByteLength;
                    var specifier = instruction.Specifier;
                    var ip = (MemoryAddress)instruction.IP;
                    statement.Sequence = counter++;
                    statement.GlobalOffset = (Address32)(ip - @base);
                    statement.BlockAddress = blockBase;
                    statement.BlockOffset = blockOffset;
                    statement.IP = ip;
                    statement.OpUri = code.OpUri;
                    statement.Statement = instruction.FormattedInstruction;
                    AsmParser.sigxpr(instruction.OpCode.InstructionString, out statement.Sig);
                    statement.Encoded = AsmHexCode.load(slice(bytes, blockOffset, size));
                    statement.OpCode = opcode;
                    statement.Bitstring = statement.Encoded;
                    dst.Add(statement);

                    blockOffset += size;
                }
            }

            return Spans.sorted(dst.ViewDeposited());
        }

        AsmInstructionBlock Decode(in ApiCodeBlock src)
        {
            var outcome = Decoder.Decode(src, out var decoded);
            if(outcome)
                return decoded;
            else
            {
                Wf.Error(outcome.Message);
                return AsmInstructionBlock.Empty;
            }
        }
    }
}