//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public sealed class AsmIdentifiers : ConstLookup<Identifier,AsmIdentifier>
    {
        public AsmIdentifiers(AsmIdentifier[] src)
            : base(src.Map(x => ((Identifier)x.Instruction.Format(), x)).ToDictionary())
        {

        }

        public ushort AsmId(string name)
        {
            if(Find(name, out var value))
            {
                return value.Id;
            }
            else
                return 0xFFFF;
        }

        public ItemList<ushort,text31> ToItemList()
            => new ItemList<ushort,text31>("AsmId", MapValues(x => new ListItem<ushort,text31>(x.Id, x.Instruction)));

        public static implicit operator AsmIdentifiers(AsmIdentifier[] src)
            => new AsmIdentifiers(src);

        public static new AsmIdentifiers Empty => new(sys.empty<AsmIdentifier>());
    }
}