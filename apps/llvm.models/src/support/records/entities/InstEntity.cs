//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;

    using static Root;

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
            => ParseAttrib(nameof(isPseudo), out bit _);

        public bit isCodeGenOnly
            => ParseAttrib(nameof(isCodeGenOnly), out bit _);

        public string AsmString
            => this[nameof(AsmString)].Value;

        public string OpMap
            => this[nameof(OpMap)].Value;

        public AsmMnemonic Mnemonic
            => llvm.AsmString.mnemonic(AsmString);

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
                var dst = AsmVariationCode.Empty;
                var j = text.index(EntityName.Content.ToLower(), Mnemonic.Content);
                if(j >=0)
                    dst = new AsmVariationCode(text.right(EntityName.Content, j + Mnemonic.Content.Length - 1));
                return dst;
            }
        }
    }
}