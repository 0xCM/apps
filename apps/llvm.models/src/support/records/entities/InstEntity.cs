//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;

    using static Root;

    using Asm;

    using SQ = SymbolicQuery;

    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class InstEntity : RecordEntity
    {
        static AsmMnemonic ExtractMnemonic(string value)
        {
            static string cleanse(string src)
            {
                var i = text.index(src, Chars.LBrace);
                var j = text.index(src, Chars.RBrace);
                if(i == NotFound || j == NotFound || j<=i)
                    return src;
                var content = text.inside(src,i,j);
                var k = text.index(content, Chars.Caret);
                if(k == NotFound)
                    return text.left(src, i);

                var suffix = text.right(content,k);
                return text.left(src,i) + suffix;
            }

            var mnemonic = text.remove(value,Chars.Quote);
            var ws = SQ.wsindex(mnemonic);
            if(ws != NotFound)
                mnemonic = text.remove(text.left(mnemonic, ws), Chars.Quote);

            return cleanse(mnemonic);
        }

        public InstEntity(DefRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }

        public bit isPseudo
            => ParseAttrib(nameof(isPseudo), out bit _);

        public bit isCodeGenOnly
            => ParseAttrib(nameof(isCodeGenOnly), out bit _);

        public string AsmString
            => this[nameof(AsmString)].Value;

        public string OpMap
            => this[nameof(OpMap)].Value;

        public AsmMnemonic Mnemonic
            => ExtractMnemonic(AsmString);

        public bits<ulong> TSFlags
        {
            get
            {
                var result = bits<ulong>.parse(this[nameof(TSFlags)].Value, out var b);
                if(result)
                    return b;
                else
                    return default;
            }
        }

        public AsmVariationCode VariationCode
        {
            get
            {
                var name = EntityName.Content;
                var mnemonic = Mnemonic.Format(MnemonicCase.Uppercase);
                if(text.empty(name) || text.empty(mnemonic) || !text.contains(name,mnemonic))
                    return AsmVariationCode.Empty;

                var candidate = text.remove(name,mnemonic);
                return text.nonempty(candidate) ? new AsmVariationCode(candidate) : AsmVariationCode.Empty;
            }
        }
    }
}