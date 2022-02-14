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

        AsmSigSvc Sigs => Service(Wf.AsmSigs);

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

        SymSet CalcFormSymbols()
        {
            var forms = Sdm.CalcForms();
            var identifiers = forms.Keys.ToArray().Sort();
            var count = (uint)identifiers.Length + 1;
            var dst = SymSet.create(count);
            dst.DataType = ClrEnumKind.U16;
            dst.Name = "AsmFormId";
            dst.Description ="Defines asm form classifiers";
            dst.Flags = false;
            dst.SymbolKind = "asm";
            var symbols = dst.Symbols;
            var values = dst.Values;
            var descriptions = dst.Descriptions;
            var names = dst.Names;
            var kinds = dst.Kinds;
            for(ushort i=0; i<count; i++)
            {
                ref var name = ref names[i];
                ref var symbol = ref symbols[i];
                ref var value = ref values[i];
                ref var desc = ref descriptions[i];
                ref var kind = ref kinds[i];
                if(i == 0)
                {
                    name = "None";
                    symbol = EmptyString;
                    value = 0;
                    desc = EmptyString;
                    kind = EmptyString;
                }
                else
                {
                    ref readonly var id = ref skip(identifiers,i - 1);
                    var form = forms[id];

                    name = id == "lock" ? "@lock" : id;
                    symbol = form.Sig.Format();
                    value = i;
                    kind = form.OpCode.Format();
                    desc = string.Format("{0} | {1} | {2}", symbol, kind, form.Description);
                }
            }
            return dst;
        }

        public void GenFormKinds()
        {
            var g = CodeGen.EnumGen();
            var src = CalcFormSymbols();
            var dst = text.buffer();
            var margin = 0u;
            var name = "AsmFormKind";
            var ns = "Z0.Asm";
            dst.IndentLineFormat(margin, "namespace {0}", "Z0.Asm");
            dst.IndentLine(margin, Chars.LBrace);
            margin += 4;
            g.Emit(margin, src, dst);
            margin -=4;
            dst.IndentLine(margin, Chars.RBrace);
            CodeGen.EmitFile(dst.Emit(), name, CgTarget.Intel);
        }
    }
}