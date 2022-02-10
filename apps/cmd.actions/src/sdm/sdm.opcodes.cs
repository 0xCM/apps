//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

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

        [CmdOp("gen/asm/data")]
        Outcome GenInstData(CmdArgs args)
        {
            var src =  Sdm.LoadSymbolicSigs();
            var count = src.Count;
            var dst = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var term = ref src[i];
                AsmSigs.parse(term.Target.Format(), out var sig);
                var sigid = AsmSigs.identify(sig);
                var sigf = sig.Format();
                for(byte j=0; j<sig.OpCount; j++)
                {
                    var op = sig.Operands[j];
                    var kind = op.OpKind.ToString();
                    if(op.IsOpMask)
                    {
                        kind = op.Modifier.ToString();
                    }
                    dst.AppendLineFormat("{0,-6} | {1,-42} | {2,-48} | {3,-12} | {4,-12} | {5}", j, sigid, sigf, kind, AsmSigs.identify(op), op.Format());
                }
            }

            FileEmit(dst.Emit(), count, ProjectDb.Log("asmsigs", FS.Csv), TextEncodingKind.Asci);
            return true;
        }

        [CmdOp("check/sdm/forms")]
        Outcome LoadAsmForms(CmdArgs args)
        {
            const string RenderPattern = "{0,-42} | {1,-42} | {2}";
            var result = Outcome.Success;
            var lookup = Sdm.LoadFormLookup();
            var kinds = lookup.Kinds;
            var count = kinds.Length;
            var path = ProjectDb.Subdir("sdm") + FS.file("sdm.forms.groups", FS.Csv);
            using var writer = path.Writer();
            writer.WriteLine(string.Format(RenderPattern,"Kind", "OpCode", "Sig"));
            for(var i=0; i<count; i++)
            {
                ref readonly var kind = ref skip(kinds,i);
                var forms = lookup[kind];
                var specs = forms.Select(AsmFormSpec.from);
                if(specs.Length == 1)
                {
                    ref readonly var spec = ref forms.First;
                    writer.WriteLine(string.Format(RenderPattern, spec.Kind, spec.OpCode, spec.Sig));
                }
                else
                {
                    for(var j=0; j<specs.Count; j++)
                    {
                        ref readonly var spec = ref specs[j];
                        if(j==0)
                            writer.WriteLine(spec.Kind, FlairKind.Processed);
                        writer.WriteLine(string.Format(RenderPattern, EmptyString, spec.OpCode, spec.Sig));
                    }
                }
            }

            return result;
        }

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

        bool nonterminal(string src)
        {
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
                case "CR":
                case "DR":
                    return true;
            }

            return false;
        }

        Index<string> rewrite(string src)
        {
            if(empty(src))
                return sys.empty<string>();

            if(nonterminal(src))
            {
                switch(src)
                {
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
                    case "CR":
                        return rewrite(CrRegs);
                    case "DR":
                        return rewrite(DbRegs);
                }
            }

            return array(src);
        }

        Index<string> rewrite(Index<string> src)
        {
            var count = src.Count;
            var dst = alloc<Index<string>>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = rewrite(src[i]);
            return dst.SelectMany(x => x);
        }
   }
}