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
    public class InstEntity : RecordEntity
    {
        public InstEntity(DefRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }

        AsmMnemonic? _Mnemonic;

        AsmVariationCode? _VariationCode;

        public bit isPseudo
            => ParseAttrib(nameof(isPseudo), out bit _);

        public bit isCodeGenOnly
            => ParseAttrib(nameof(isCodeGenOnly), out bit _);

        public string AsmString
            => llvm.AsmString.normalize(this[nameof(AsmString)]);

        public string OpMap
            => this[nameof(OpMap)];

        public string InstName
            => EntityName;

        public AsmMnemonic Mnemonic
        {
            get
            {
                if(_Mnemonic == null)
                    _Mnemonic = llvm.AsmString.mnemonic(this[nameof(AsmString)]);
                return _Mnemonic.Value;
            }
        }

        public bits<ulong> TSFlags
        {
            get
            {
                var result = bits<ulong>.parse(this[nameof(TSFlags)], out var b);
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
                if(_VariationCode == null)
                {
                    var name = EntityName.Content;
                    var mnemonic = Mnemonic.Format(MnemonicCase.Uppercase);
                    if(text.empty(name) || text.empty(mnemonic) || !text.contains(name,mnemonic))
                        return AsmVariationCode.Empty;
                    var candidate = text.remove(name,mnemonic);
                    _VariationCode = text.nonempty(candidate) ? new AsmVariationCode(candidate) : AsmVariationCode.Empty;
                }
                return _VariationCode.Value;
            }
        }
    }
}