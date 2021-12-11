//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static Root;

    /// <summary>
    /// Represents a table-gen defined instruction
    /// </summary>
    public class RegOpEntity : DefFields
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