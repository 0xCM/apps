//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using System.Collections.Generic;

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

        static byte sigops(in SigOpCode src, Span<AsmSigOpExpr> dst)
        {
            var counter = z8;
            if(src.Op0.IsNonEmpty)
                seek(dst,counter++) = src.Op0;
            if(src.Op1.IsNonEmpty)
                seek(dst,counter++) = src.Op1;
            if(src.Op2.IsNonEmpty)
                seek(dst,counter++) = src.Op2;
            if(src.Op3.IsNonEmpty)
                seek(dst,counter++) = src.Op3;
            return counter;
        }

        [CmdOp("sdm/sigs")]
        Outcome SdmOpCodes(CmdArgs args)
        {
            var decomps = Sdm.LoadSigDecomps();
            var count = decomps.Count;
            var opexpr = span<AsmSigOpExpr>(4);
            var identity = text.buffer();
            var identities = dict<Identifier, HashSet<SigOpCode>>();
            for(var i=0; i<count; i++)
            {
                opexpr.Clear();
                identity.Clear();

                ref readonly var sig = ref decomps[i];
                var opcount = sigops(sig, opexpr);
                var operands = slice(opexpr,0, opcount);

                identity.Append(sig.Sig.Mnemonic.Format(MnemonicCase.Lowercase));
                for(var j=0; j<opcount; j++)
                {
                    identity.Append(Chars.Underscore);
                    identity.Append(identifier(skip(operands,j)));
                }

                var id = identity.Emit();
                if(!identities.ContainsKey(id))
                    identities.Add(id, new());

                identities[id].Add(sig);

                //Write(string.Format("{0,-8} | {1,-32} | {2}", sig.Seq, id, sig.Sig.Format()));
            }

            foreach(var entry in identities)
            {
                var id = entry.Key;
                var opcodes = entry.Value.Map(x => x.OpCode.Format()).Delimit(Chars.Pipe,-32);
                Write(string.Format("{0,-32} | {1}", id, opcodes));
            }

            //Write(string.Format("Count:{0}", identities.Count));
            return true;
        }

        static string identifier(AsmSigOpExpr src)
        {
            return src.Text.Replace(" {k1}{z}", EmptyString).Replace(" {k1}", EmptyString).ToLower();
        }
        void EmitSdmOpCodeDocs()
        {
            var rules = Rules.productions(ProjectDb.Settings("asm.sigs.expansions", FS.ext("map")));

            // foreach(var e in src.Entries)
            // {
            //     var regs = e.Value;
            //     var expr = e.Key;
            //     Write(string.Format("{0} -> [{1}]", expr, regs));
            // }
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
            {
                seek(dst,i) = rewrite(src[i]);
            }
            return dst.SelectMany(x => x);
        }
   }
}