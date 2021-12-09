//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class InstAliasEntity : RecordEntity
    {
        public InstAliasEntity(DefRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }

        public string AsmString
            => Value(nameof(AsmString), () => llvm.AsmString.normalize(this[nameof(AsmString)]));

        public AsmMnemonic Mnemonic
            => Value(nameof(Mnemonic), () => llvm.AsmString.mnemonic(this[nameof(AsmString)]));

        public string ResultInst
            => this[nameof(ResultInst)];


        string DeriveInstName()
        {
            var src = ResultInst;
            var i = text.index(src,Chars.LParen);
            if(i >= 0)
            {
                var j = text.index(src,i, Chars.Space);
                if(j >= 0)
                {
                    return text.inside(src,i,j);
                }
                else
                {
                    var k = text.index(src,i, Chars.RParen);
                    if(k >= 0)
                        return text.inside(src,i,k);
                }
            }
            return src;
        }

        public string InstName
            => Value(nameof(InstName), DeriveInstName);

        public string EmitPriority
            => AttribValue(nameof(EmitPriority));

        public string Predicates
            => AttribValue(nameof(Predicates));

        public bit UseInstAsmMatchConverter
            => Parse(nameof(UseInstAsmMatchConverter), out bit _);

        public string AsmVariantName
            => AttribValue(nameof(AsmVariantName));
    }
}