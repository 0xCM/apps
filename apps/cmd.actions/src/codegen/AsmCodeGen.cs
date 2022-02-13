//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    using static AsmSigTokenKind;

    public partial class AsmCodeGen : AppService<AsmCodeGen>
    {
        IntelSdm Sdm => Service(Wf.IntelSdm);

        CgSvc CodeGen => Service(Wf.CodeGen);

        AsmSigSvc Sigs => Service(Wf.AsmSigs);

        const string Ops1Pattern = "{0}";

        const string Ops2Pattern = "{0}, {1}";

        const string Ops3Pattern = "{0}, {1}, {2}";

        const string Ops4Pattern = "{0}, {1}, {2}, {3}";

        const string Ops5Pattern = "{0}, {1}, {2}, {3}, {4}";

        public static string identifier(AsmMnemonic src)
        {
            var identifier = src.Format(MnemonicCase.Lowercase);
            return identifier switch{
                "in" => "@in",
                "out" => "@out",
                "int" => "@int",
                "lock" => "@lock",
                _ => identifier
            };
        }

        Index<string> OpsPatterns()
        {
            return state(nameof(OpsPatterns), Load);

            Index<string> Load()
            {
                var dst = alloc<string>(5);
                var i=0;
                seek(dst,i++) = Ops1Pattern;
                seek(dst,i++) = Ops2Pattern;
                seek(dst,i++) = Ops3Pattern;
                seek(dst,i++) = Ops4Pattern;
                seek(dst,i++) = Ops5Pattern;
                return dst;
            }
        }

        static bool supported(in AsmSigOp src)
        {
            var result = false;
            switch(src.Kind)
            {
                case SysReg:
                case GpReg:
                case VecReg:
                case RegLiteral:
                case Imm:
                case Mem:
                case MaskReg:
                case MmxRm:
                case IntLiteral:
                    result = true;
                break;
            }
            return result;
        }

        static bool supported(in AsmSig src)
        {
            var result = true;
            var count = src.OpCount;
            ref readonly var ops = ref src.Operands;
            for(var i=0; i<count; i++)
                result &= supported(ops[i]);
            return result;
        }

        CsOperand CsOp(byte index, in AsmSigOp src)
        {
            var type = src.Format();
            switch(src.Kind)
            {
                case SysReg:
                case GpReg:
                case VecReg:
                case RegLiteral:
                case Imm:
                case Mem:
                case MaskReg:
                case MmxRm:
                case IntLiteral:
                {

                    switch(src.Value)
                    {
                        case 0:
                            type = "N0";
                        break;
                        case 1:
                            type = "N1";
                        break;
                    }
                    break;
                }

                case Rel:
                case GpRm:
                case VecRm:
                case FpuReg:
                case FpuInt:
                case FpuMem:
                case Moffs:
                case Ptr:
                case MemPtr:
                case MemPair:
                case Rounding:
                case AsmSigTokenKind.Vsib:
                case BCastComposite:
                case OpMask:
                case Dependent:
                    break;

                default:
                break;
            }
            return CsOperand.define(type, string.Format("a{0}", index));
        }

        public void GenMnemonicNames()
        {
            var g = CodeGen.LiteralProvider();
            var name = "AsmMnemonicNames";
            var src = Sdm.LoadSigs().Select(x => x.Mnemonic.Format(Asm.MnemonicCase.Lowercase)).Distinct();
            var dst = CodeGen.SourceFile(name, CgTarget.Intel);
            var names = src.View;
            var values = src.View;
            var literals = Literals.seq(name, names, values);
            g.Emit("Z0", literals, dst);
        }


        // public void GenFormIdentifiers()
        // {
        //     var forms = Sdm.LoadForms();
        //     var names = forms.Keys.ToArray().Sort();
        //     var count = names.Length;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var name = ref skip(names,i);
        //     }
        // }

        // public void GenSigFormatters()
        // {
        //     var fSrc = DefineSigFormatters();
        //     var count = fSrc.Count;

        //     var fDst= text.buffer();
        //     var margin = 0u;
        //     var name = "AsmFormatters";
        //     fDst.IndentLineFormat(margin,"public readonly struct {0}", name);
        //     fDst.IndentLine(margin, Chars.LBrace);
        //     margin +=4;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var f = ref fSrc[i];
        //         f.Render(margin, fDst);
        //         fDst.AppendLine();
        //     }
        //     margin -=4;
        //     fDst.IndentLine(margin,Chars.RBrace);

        //     var spec = CgSpecs.define("Z0.Asm", array("using Operands;"), fDst.Emit());
        //     CodeGen.EmitFile(spec, name, CgTarget.Intel);

        // }
    }
}