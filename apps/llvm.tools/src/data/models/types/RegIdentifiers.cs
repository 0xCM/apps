//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public sealed class RegIdentifiers : ConstLookup<Identifier,RegIdentifier>
    {
        public RegIdentifiers(RegIdentifier[] src)
            : base(src.Map(x => ((Identifier)x.Name.Format(), x)).ToDictionary())
        {

        }

        public ItemList<ushort,text15> ToItemList()
            => new ItemList<ushort,text15>("RegId", MapValues(x => new ListItem<ushort,text15>(x.Id, x.Name)));

        public static implicit operator RegIdentifiers(RegIdentifier[] src)
            => new RegIdentifiers(src);

        public static new RegIdentifiers Empty => new(sys.empty<RegIdentifier>());
    }
}