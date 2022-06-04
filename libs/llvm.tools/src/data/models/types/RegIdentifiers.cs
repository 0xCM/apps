//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public sealed class RegIdentifiers : ConstLookup<string,RegIdentifier>
    {
        public RegIdentifiers(RegIdentifier[] src)
            : base(src.Map(x => (x.RegName.Format(), x)).ToDictionary())
        {

        }

        public ItemList<ushort,text15> ToItemList()
            => new ItemList<ushort,text15>("RegId", MapValues(x => new ListItem<ushort,text15>(x.Id, x.RegName)));

        public static implicit operator RegIdentifiers(RegIdentifier[] src)
            => new RegIdentifiers(src);

        public static new RegIdentifiers Empty => new(sys.empty<RegIdentifier>());
    }
}