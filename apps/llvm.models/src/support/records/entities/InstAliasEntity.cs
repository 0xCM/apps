//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.CompilerServices;

    using static Root;

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
            => AttribValue(nameof(AsmString));

        public string ResultInst
            => AttribValue(nameof(ResultInst));

        public string EmitPriority
            => AttribValue(nameof(EmitPriority));

        public string Predicates
            => AttribValue(nameof(Predicates));

        public bit UseInstAsmMatchConverter
            => ParseAttrib(nameof(UseInstAsmMatchConverter), out bit _);

        public string AsmVariantName
            => AttribValue(nameof(AsmVariantName));
    }
}