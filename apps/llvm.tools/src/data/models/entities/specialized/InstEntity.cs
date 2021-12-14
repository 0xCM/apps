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
    public class InstEntity : DefFields
    {
        public const string LlvmName = "Instruction";

        public InstEntity(DefRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }

        public bit isPseudo
            => Parse(nameof(isPseudo), out bit _);

        public bit isCodeGenOnly
            => Parse(nameof(isCodeGenOnly), out bit _);

        public bit hasREX_WPrefix
            => Parse(nameof(hasREX_WPrefix), out bit _);

        public bit HasVex_W
            => Parse(nameof(HasVex_W), out bit _);

        public int CodeSize
            => Parse(nameof(CodeSize), out int _);

        public string ImmT
            => this[nameof(ImmT)];

        public string AsmStringSource
            => Value(nameof(AsmStringSource),() => text.remove(this[nameof(AsmString)].Replace(Chars.Tab, Chars.Space), Chars.Quote));

        public AsmString AsmString
            => Value(nameof(AsmString), () => llvm.AsmStrings.extract(this));

        public string OpMap
            => this[nameof(OpMap)];

        public bits<byte> OpMapBits
            => Parse(nameof(OpMapBits), out bits<byte> dst);

        public string InstName
            => EntityName;

        public string AdSize
            => this[nameof(AdSize)];

        public bits<byte> AdSizeBits
            => Parse(nameof(AdSizeBits), out bits<byte> dst);

        public string OpSize
            => this[nameof(OpSize)];

        public bits<byte> OpSizeBits
            => Parse(nameof(OpSizeBits), out bits<byte> dst);

        public string InOperandList
            => this[nameof(InOperandList)];

        public string OutOperandList
            => this[nameof(OutOperandList)];

        public string Predicates
            =>this[nameof(Predicates)];

        public AsmMnemonic Mnemonic
            => Value(nameof(Mnemonic), () => AsmString.Mnemonic);

        public bits<ulong> TSFlags
            => Parse(nameof(TSFlags), out bits<ulong> dst);

        public bits<byte> Opcode
            => Parse(nameof(Opcode), out bits<byte> dst);

        public bits<byte> FormBits
            => Parse(nameof(FormBits), out bits<byte> dst);

        public string OpPrefix
            => this[nameof(OpPrefix)];

        public bits<byte> OpPrefixBits
            => Parse(nameof(OpPrefixBits), out bits<byte> dst);

        public AsmVariationCode VarCode
            => Value(nameof(VarCode), () => llvm.AsmStrings.varcode(InstName, Mnemonic));
    }
}