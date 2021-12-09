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

        public bit isPseudo
            => Parse(nameof(isPseudo), out bit _);

        public bit isCodeGenOnly
            => Parse(nameof(isCodeGenOnly), out bit _);

        public string RawAsmString
            => Value(nameof(RawAsmString),() => this[nameof(AsmString)].Replace(Chars.Tab, Chars.Space));

        public string AsmString
            => Value(nameof(AsmString), () => llvm.AsmString.normalize(RawAsmString));

        public string OpMap
            => this[nameof(OpMap)];

        public string InstName
            => EntityName;

        // public string InOperandList
        //     => this[nameof(InOperandList)];

        // public string OutOperandList
        //     => this[nameof(OutOperandList)];

        // public string Predicates
        //     =>this[nameof(Predicates)];

        public AsmMnemonic Mnemonic
            => Value(nameof(Mnemonic), () => llvm.AsmString.mnemonic(this[nameof(AsmString)]));

        public bits<ulong> TSFlags
            => Parse(nameof(TSFlags), out bits<ulong> dst);

        public AsmVariationCode VarCode
            => Value(nameof(VarCode), () => llvm.AsmString.varcode(InstName, Mnemonic));
    }
}