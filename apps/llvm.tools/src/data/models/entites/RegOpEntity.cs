//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static LlvmNames;

    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class RegOpEntity : RecordEntity
    {
        public RegOpEntity(DefRelations def, RecordField[] fields)
            : base(def,fields)
        {

        }


        public string RegTypes
            => this[nameof(RegTypes)];

        public string MemberList
            => this[nameof(MemberList)];

        public int Size
            => Parse(nameof(Size), out int _);
    }
}