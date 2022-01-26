//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System;

    using static core;
    using static Asm.AsmOpCodeTokens;

    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/asmdocs")]
        Outcome EmitAsmDocs(CmdArgs args)
        {
            EmitRexDocs();
            EmitSibDocs();
            EmitModRmDocs();
            EmitConditionDocs();
            EmitRegDocs();
            EmitRexBDocs();
            return true;
        }

        AsmRegSets Regs => Service(Wf.AsmRegSets);

        AsmEncoding Encoding => Service(Wf.AsmEncoding);

        void EmitRegDocs()
        {
            var dst = ApiDoc("asm.regs.strings", FS.Cs);
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            writer.WriteLine(Regs.Gp8LoRegs().ToNameArray("Gp8Regs"));
            writer.WriteLine(Regs.Gp16Regs().ToNameArray("Gp16Regs"));
            writer.WriteLine(Regs.Gp32Regs().ToNameArray("Gp32Regs"));
            writer.WriteLine(Regs.Gp64Regs().ToNameArray("Gp64Regs"));
            writer.WriteLine(Regs.XmmRegs().ToNameArray("XmmRegs"));
            writer.WriteLine(Regs.YmmRegs().ToNameArray("YmmRegs"));
            writer.WriteLine(Regs.ZmmRegs().ToNameArray("ZmmRegs"));
            writer.WriteLine(Regs.MmxRegs().ToNameArray("MmxRegs"));
            writer.WriteLine(Regs.MaskRegs().ToNameArray("MaskRegs"));
            writer.WriteLine(Regs.CrRegs().ToNameArray("CrRegs"));
            writer.WriteLine(Regs.DbRegs().ToNameArray("DbRegs"));

            EmittedFile(emitting,4);
        }

        void EmitRexDocs()
        {
            var dst = ApiDoc("asm.docs.rex", FS.ext("bits") + FS.Csv);
            var emitting = EmittingFile(dst);
            var bits = RexPrefix.Range();
            using var writer = dst.AsciWriter();
            var buffer = text.buffer();
            var count = RexPrefix.table(buffer);
            writer.Write(buffer.Emit());
            EmittedFile(emitting,count);
        }

        void EmitSibDocs()
        {
            var rows = AsmEncoding.SibRows().View;
            TableEmit(rows, SibBitfieldRow.RenderWidths, ApiDoc("asm.docs.sib.bits", FS.Csv));

            var codes = AsmEncoding.SibRegCodes();
            TableEmit(codes.View, SibRegCodes.RenderWidths, ApiDoc("asm.docs.sib.regs", FS.Csv));
        }

        void EmitModRmDocs()
        {
            var path = ApiDoc("asm.docs.modrm", FS.ext("bits") + FS.Csv);
            var flow = EmittingFile(path);
            using var writer = path.AsciWriter();
            var dst = span<char>(256*128);
            var count = AsmBits.ModRmTable(dst);
            var rendered = slice(dst,0,count);
            writer.Write(rendered);
            EmittedFile(flow,count);
        }

        FS.FolderPath ApiDocs()
            => ProjectDb.Api() + FS.folder("docs");

        FS.FilePath ApiDoc(string name, FS.FileExt ext)
            => ApiDocs() + FS.file(name, ext);

        void EmitRexBDocs()
        {
            var tokens = Symbols.index<RexBToken>();
            var g = RexBGenerator.create(Wf);
            var src = g.Generate();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var b = ref src[i];
                ref readonly var token = ref tokens[b.Token];
                uint2 value = (byte)token.Kind;
                var reg = asm.reg(b.RegSize, b.Hi ? RegClassCode.GP8HI : RegClassCode.GP, b.Reg.Code);
                Write(string.Format("{0,-5} | {1,-5} | {2,-5} | {3,-5} | {4}", i, reg.Name, b.Reg.Code, b.Reg, value, token.Expr));
            }

        }

        [CmdOp("api/emit/rexb")]
        Outcome EmitRexBDocs(CmdArgs args)
        {
            EmitRexBDocs();

            return true;
        }
        void EmitConditionDocs()
        {
            var jcc8 = ApiDoc("jcc8", FS.Txt);
            EmitConditionDocs(Conditions.jcc8(), jcc8);
            using var jcc8Reader = jcc8.AsciLineReader();
            while(jcc8Reader.Next(out var line))
                Write(text.format(line.Codes));

            var jcc32 = ApiDoc("jcc32", FS.Txt);
            EmitConditionDocs(Conditions.jcc32(), jcc32);
            using var jcc32Reader = jcc32.AsciLineReader();
            while(jcc32Reader.Next(out var line))
                Write(text.format(line.Codes));
        }

        uint EmitConditionDocs<T>(ReadOnlySpan<T> src, FS.FilePath dst)
            where T : IConditional
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref skip(src,i);
                writer.WriteLine(info.Format(false));
                counter++;
                if(!info.Identical)
                {
                    writer.WriteLine(info.Format(true));
                    counter++;
                }
            }
            EmittedFile(emitting,counter);
            return counter;
        }
    }
}