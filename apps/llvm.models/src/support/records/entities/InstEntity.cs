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
    }
}