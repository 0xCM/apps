//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    using static core;
    using static Root;

    partial class ProjectCmdProvider
    {
        [CmdOp("seq/prod")]
        Outcome SeqProd(CmdArgs args)
        {
            var a = Intervals.closed(2u, 12u).Partition();
            var b = Intervals.closed(33u, 41u).Partition();
            var c = SeqProducts.mul(a,b);
            Write(SeqProducts.format(c));

            return true;
        }
        [CmdOp("sdm/productions")]
        Outcome SdmProductions(CmdArgs args)
        {
            var path = ProjectDb.Settings("asm.sigs.atomics", FS.ext("map"));
            var src = rules.atomics(path);
            foreach(var e in src.Entries)
            {
                var regs = e.Value;
                var expr = e.Key;
                Write(string.Format("{0} -> [{1}]", expr, regs));
            }
            return true;
        }

        [CmdOp("sdm/opcodes")]
        Outcome SdmOpCodes(CmdArgs args)
        {
            EmitSdmOpCodeDocs();
            return true;
        }

        void EmitSdmOpCodeDocs()
        {
            var codes = Sdm.LoadImportedOpCodes();
            var count = codes.Count;

            void EmitTable()
            {
                var dst = ProjectDb.Subdir("sdm") + FS.file("sdm.opcodes.tables", FS.Md);
                var emitting = EmittingFile(dst);
                using var writer = dst.AsciWriter();

                for(var i=0; i<count; i++)
                {
                    ref readonly var entry = ref codes[i];
                    writer.Write(format(entry));
                    writer.WriteLine();
                }
                EmittedFile(emitting,count);
            }


            EmitTable();
            Sdm.EmitOpCodeSigs();
        }

        static string format(in SdmSigOpCode entry, bool rw = true)
        {
            var dst = text.buffer();
            ref readonly var sig = ref entry.Sig;
            ref readonly var opcode = ref entry.OpCode;
            var operands = sig.Operands();
            var count = operands.Length;
            dst.AppendLine(string.Format("## {0,-36}", sig.Format()));
            dst.AppendLine(string.Format("   {0}", opcode.Expr.Format()));
            for(var j=0; j<count; j++)
            {
                ref readonly var op = ref skip(operands,j);
                if(rw)
                {
                    var content = rewrite(op.Format());
                    var ops = content.IsEmpty ? EmptyString : content.Length > 1 ? text.bracket(content.Delimit(Chars.Pipe).Format()) : content.First;
                    dst.AppendLine(string.Format("       {0} | {1}", j, ops));
                }
                else
                {
                    dst.AppendLine(string.Format("       {0} | {1}", j, op.Format()));

                }
            }
            return dst.Emit();
        }

        static string[] _Rm8 = new string[]{"r8", "m8"};

        static string[] _Rm16 = new string[]{"r16", "m16"};

        static string[] _Rm32 = new string[]{"r32", "m32"};

        static string[] _Rm64 = new string[]{"r64", "m64"};

        static string[] XmmM128 = new string[]{"xmm", "m128"};

        static string[] YmmM256 = new string[]{"ymm", "m256"};

        static string[] ZmmM512 = new string[]{"zmm", "m512"};

        static string[] MmxM64 = new string[]{"mm", "m64"};

        static string[] XmmM64 = new string[]{"xmm", "m64"};

        static string[] Gp8Regs = new string[]{"al","cl","dl","bl","spl","bpl","sil","dil","r8b","r9b","r10b","r11b","r12b","r13b","r14b","r15b"};

        static string[] Gp16Regs = new string[]{"ax","cx","dx","bx","sp","bp","si","di","r8w","r9w","r10w","r11w","r12w","r13w","r14w","r15w"};

        static string[] Gp32Regs = new string[]{"eax","ecx","edx","ebx","esp","ebp","esi","edi","r8d","r9d","r10d","r11d","r12d","r13d","r14d","r15d"};

        static string[] Gp64Regs = new string[]{"rax","rcx","rdx","rbx","rsp","rbp","rsi","rdi","r8","r9","r10","r11","r12","r13","r14","r15"};

        static string[] XmmRegs = new string[]{"xmm0","xmm1","xmm2","xmm3","xmm4","xmm5","xmm6","xmm7","xmm8","xmm9","xmm10","xmm11","xmm12","xmm13","xmm14","xmm15","xmm16","xmm17","xmm18","xmm19","xmm20","xmm21","xmm22","xmm23","xmm24","xmm25","xmm26","xmm27","xmm28","xmm29","xmm30","xmm31"};

        static string[] YmmRegs = new string[]{"ymm0","ymm1","ymm2","ymm3","ymm4","ymm5","ymm6","ymm7","ymm8","ymm9","ymm10","ymm11","ymm12","ymm13","ymm14","ymm15","ymm16","ymm17","ymm18","ymm19","ymm20","ymm21","ymm22","ymm23","ymm24","ymm25","ymm26","ymm27","ymm28","ymm29","ymm30","ymm31"};

        static string[] ZmmRegs = new string[]{"zmm0","zmm1","zmm2","zmm3","zmm4","zmm5","zmm6","zmm7","zmm8","zmm9","zmm10","zmm11","zmm12","zmm13","zmm14","zmm15","zmm16","zmm17","zmm18","zmm19","zmm20","zmm21","zmm22","zmm23","zmm24","zmm25","zmm26","zmm27","zmm28","zmm29","zmm30","zmm31"};

        static string[] MmxRegs = new string[]{"mmx0","mmx1","mmx2","mmx3","mmx4","mmx5","mmx6","mmx7"};

        static string[] MaskRegs = new string[]{"k0","k1","k2","k3","k4","k5","k6","k7"};

        static string[] CrRegs = new string[]{"cr0","cr1","cr2","cr3","cr4","cr5","cr6","cr7"};

        static string[] DbRegs = new string[]{"db0","db1","db2","db3","db4","db5","db6","db7"};

        static bool nonterminal(string src)
        {
            if(text.contains(src,Chars.FSlash) || text.contains(src, Chars.Dash))
                return true;

            switch(src)
            {
                case "r8":
                case "r16":
                case "r32":
                case "r64":
                case "xmm":
                case "ymm":
                case "zmm":
                case "k":
                case "mm":
                    return true;
            }

            return false;
        }

        static Index<string> rewrite(string src)
        {
            if(empty(src))
                return sys.empty<string>();

            if(nonterminal(src))
            {
                switch(src)
                {
                    case "r/m8":
                        return rewrite(_Rm8);
                    case "r/m16":
                        return rewrite(_Rm16);
                    case "r/m32":
                        return rewrite(_Rm32);
                    case "r/m64":
                        return rewrite(_Rm64);
                    case "xmm/m128":
                        return rewrite(XmmM128);
                    case "xmm/m64":
                        return rewrite(XmmM64);
                    case "mm/m64":
                        return rewrite(MmxM64);
                    case "ymm/m256":
                        return rewrite(YmmM256);
                    case "zmm/m512":
                        return rewrite(ZmmM512);
                    case "r8":
                        return rewrite(Gp8Regs);
                    case "r16":
                        return rewrite(Gp16Regs);
                    case "r32":
                        return rewrite(Gp32Regs);
                    case "r64":
                        return rewrite(Gp64Regs);
                    case "xmm":
                        return rewrite(XmmRegs);
                    case "ymm":
                        return rewrite(YmmRegs);
                    case "zmm":
                        return rewrite(ZmmRegs);
                    case "mm":
                        return rewrite(MmxRegs);
                    case "k":
                        return rewrite(MaskRegs);
                    case "CR0-CR7":
                        return rewrite(CrRegs);
                    case "DR0-DR7":
                        return rewrite(DbRegs);
                }
            }

            return array(src);
        }

        static Index<string> rewrite(Index<string> src)
        {
            var count = src.Count;
            var dst = alloc<Index<string>>(count);
            for(var i=0; i<count; i++)
            {
                seek(dst,i) = rewrite(src[i]);
            }
            return dst.SelectMany(x => x);
        }
   }
}