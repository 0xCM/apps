//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public partial class AsmCodeGen : AppService<AsmCodeGen>
    {
        IntelSdm Sdm => Service(Wf.IntelSdm);

        CgSvc CodeGen => Service(Wf.CodeGen);

        AsmSigs AsmSigs => Service(Wf.AsmSigs);

        const string Ops1Pattern = "{0}";

        const string Ops2Pattern = "{0}, {1}";

        const string Ops3Pattern = "{0}, {1}, {2}";

        const string Ops4Pattern = "{0}, {1}, {2}, {3}";

        const string Ops5Pattern = "{0}, {1}, {2}, {3}, {4}";

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

        public Index<CsFunc> DefineSigFormatters()
        {
            var result = Outcome.Success;
            result = AsmSigs.Terminals(out var sigs);
            if(result.Fail)
            {
                Error(result.Message);
            }

            var count = sigs.Count;
            var funcs = alloc<CsFunc>(count);

            for(var i=0; i<count; i++)
            {
                ref var func = ref seek(funcs,i);
                ref readonly var sig = ref sigs[i];
                var csops = alloc<CsOperand>(sig.OpCount);
                var sigops = sig.Operands;
                for(byte j=0; j<sig.OpCount; j++)
                {
                    var sigop = sigops[j];
                    seek(csops,j) = CsOperand.define(sigop.Format(), string.Format("a{0}", j));
                }

                seek(funcs,i) = CsFunc.define(typeof(string).DisplayName(), sig.Mnemonic.Format(MnemonicCase.Lowercase), csops, "return EmptyString;");

            }
            return funcs;
        }

        public void GenSigIds()
        {
            var symbols = Sdm.LoadSigSymbols();
            var g = CodeGen.EnumGen();
            var buffer = text.buffer();
            g.Emit(0u, symbols, buffer);
            var spec = CgSpecs.define("Z0.Asm").WithContent(buffer.Emit());
            CodeGen.EmitFile(spec, "AsmSigId", CgTarget.Intel);
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
    }
}