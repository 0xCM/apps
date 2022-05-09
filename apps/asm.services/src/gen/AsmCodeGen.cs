//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class AsmCodeGen : AppService<AsmCodeGen>
    {
        IntelSdm Sdm => Service(Wf.IntelSdm);

        CgSvc CodeGen => Service(Wf.CodeGen);

        const string Ops1Pattern = "{0}";

        const string Ops2Pattern = "{0}, {1}";

        const string Ops3Pattern = "{0}, {1}, {2}";

        const string Ops4Pattern = "{0}, {1}, {2}, {3}";

        const string Ops5Pattern = "{0}, {1}, {2}, {3}, {4}";

        const string TargetNamespace = "Z0.Asm";

        const string AsmSigTableName = "AsmSigST";

        const string MnemonicNameProvider = "AsmMnemonicNames";

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

        public void Emit()
        {
            CodeGen.SourceRoot(CgTarget.Intel).Clear(true);
            GenMnemonicNames();
            GenFormKinds();
            GenSigStrings();
        }

        public void GenMnemonicNames()
        {
            var g = CodeGen.LiteralProvider();
            var src = Sdm.CalcMnemonics().Select(x => x.Format(MnemonicCase.Lowercase));
            var dst = CodeGen.SourceFile(MnemonicNameProvider, CgTarget.Intel);
            var names = src.View;
            var values = src.View;
            var literals = Literals.seq(MnemonicNameProvider, names, values);
            g.Emit(TargetNamespace, literals, dst);
        }

        public void GenFormKinds()
        {
            var descriptors = Sdm.CalcFormDescriptors();
            var src = descriptors.CalcSymbols();
            var dst = text.buffer();
            var margin = 0u;
            dst.IndentLineFormat(margin, "namespace {0}", TargetNamespace);
            dst.IndentLine(margin, Chars.LBrace);
            margin += 4;
            CsRender.@enum(margin, src, dst);
            margin -=4;
            dst.IndentLine(margin, Chars.RBrace);
            CodeGen.EmitFile(dst.Emit(), AsmFormDescriptors.FormKindName, CgTarget.Intel);
        }

        public void GenSigStrings()
        {
            var forms = Sdm.CalcFormDescriptors();
            var keys = forms.Keys;
            var count = keys.Length + 1;
            var sigs = alloc<string>(count);
            for(var i=0; i<count; i++)
            {
                if(i==0)
                    seek(sigs,i) = EmptyString;
                else
                    seek(sigs,i) = forms[keys[i-1]].Sig.Format();
            }

            CodeGen.GenStringTable(TargetNamespace, AsmSigTableName, AsmFormDescriptors.FormKindName, sigs, CgTarget.Intel);
        }
    }
}