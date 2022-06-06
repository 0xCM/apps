//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    using static LlvmNames;

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

        public string AdSize
            => this[nameof(AdSize)];

        public bits<byte> AdSizeBits
            => bits(n2, this[nameof(AdSizeBits)]);

        public string AsmStringSource
            => Value(nameof(AsmStringSource),() => text.remove(this[nameof(AsmString)].Replace(Chars.Tab, Chars.Space), Chars.Quote));

        public AsmPattern AsmString
            => Value(nameof(AsmString), () => llvm.AsmPatterns.extract(this));

        public int CodeSize
            => Parse(nameof(CodeSize), out int _);

       public bits<byte> CD8_Form
            => bits(n3, this[nameof(CD8_Form)]);

       public bits<byte> CD8_Scale
            => bits(n7, this[nameof(CD8_Scale)]);

        public string Constraints
            => this[nameof(Constraints)];

        public string DecoderNamespace
            => this[nameof(DecoderNamespace)];

        public string DecoderMethod
            => this[nameof(DecoderMethod)];

        public string Form
            => this[nameof(Form)];

        public bits<byte> FormBits
            => bits(n7, this[nameof(FormBits)]);

        public string InstName
            => EntityName;

        public dag<IExpr> InOperandList
            => Parse(nameof(InOperandList), out dag<IExpr> _);

        public dag<IExpr> OutOperandList
            => Parse(nameof(OutOperandList), out dag<IExpr> _);

        public bit hasREX_WPrefix
            => Parse(nameof(hasREX_WPrefix), out bit _);

        public bit HasVex_W
            => Parse(nameof(HasVex_W), out bit _);

        public bit hasLockPrefix
            => Parse(nameof(hasLockPrefix), out bit _);

        public bit hasREPPrefix
            => Parse(nameof(hasREPPrefix), out bit _);

        public bit IgnoresVEX_W
            => Parse(nameof(IgnoresVEX_W), out bit _);

        public bit hasVEX_4V
            => Parse(nameof(hasVEX_4V), out bit _);

        public bit hasVEX_L
            => Parse(nameof(hasVEX_L), out bit _);

        public bit ignoresVEX_L
            => Parse(nameof(ignoresVEX_L), out bit _);

        public bit EVEX_W1_VEX_W0
            => Parse(nameof(EVEX_W1_VEX_W0), out bit _);

        public bit hasEVEX_K
            => Parse(nameof(hasEVEX_K), out bit _);

        public bit hasEVEX_Z
            => Parse(nameof(hasEVEX_Z), out bit _);

        public bit hasEVEX_L2
            => Parse(nameof(hasEVEX_L2), out bit _);

        public bit hasEVEX_B
            => Parse(nameof(hasEVEX_B), out bit _);

        public bit hasEVEX_RC
            => Parse(nameof(hasEVEX_RC), out bit _);

        public bit isBranch
            => Parse(nameof(isBranch), out bit _);

        public bit isIndirectBranch
            => Parse(nameof(isIndirectBranch), out bit _);

        public bit isCall
            => Parse(nameof(isCall), out bit _);

        public bit isPseudo
            => Parse(nameof(isPseudo), out bit _);

        public bit isCodeGenOnly
            => Parse(nameof(isCodeGenOnly), out bit _);

        public string ImmT
            => this[nameof(ImmT)];

        public AsmMnemonic Mnemonic
            => Value(nameof(Mnemonic), () => AsmString.Mnemonic);

        public string Namespace
            => this[nameof(Namespace)];

        public string OpMap
            => this[nameof(OpMap)];

        public bits<byte> OpMapBits
            => bits(n3, this[nameof(OpMapBits)]);

        public string OpSize
            => this[nameof(OpSize)];

        public bits<byte> OpSizeBits
            => bits(n2, this[nameof(OpSizeBits)]);

        public bits<byte> Opcode
            => bits(n8, this[nameof(Opcode)]);

        public string OpCodeData
            => this[nameof(Opcode)];

        public string OpEnc
            => this[nameof(OpEnc)];

        public bits<byte> OpEncBits
            => bits(n2, this[nameof(OpEncBits)]);

        public string OpPrefix
            => this[nameof(OpPrefix)];

        public bits<byte> OpPrefixBits
            => bits(n3, this[nameof(OpPrefixBits)]);

        public list<string> Predicates
            => Parse(nameof(Predicates), ListTypes.Predicate, out list<string> _);

        public int Size
            => Parse(nameof(Size), out int _);

        public bits<ulong> TSFlags
            => Parse(nameof(TSFlags), out bits<ulong> dst);

        public AsmVariationCode VarCode
            => Value(nameof(VarCode), () => llvm.AsmPatterns.varcode(InstName, Mnemonic));

        public bits<byte> VectSize
            => bits(n7, this[nameof(VectSize)]);
    }
}