//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public sealed class AsmIdentifiers : ConstLookup<Identifier,AsmIdentifier>
    {
        public AsmIdentifiers(AsmIdentifier[] src)
            : base(src.Map(x => ((Identifier)x.InstName.Format(), x)).ToDictionary())
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

        public static implicit operator AsmIdentifiers(AsmIdentifier[] src)
            => new AsmIdentifiers(src);

        public static new AsmIdentifiers Empty => new(sys.empty<AsmIdentifier>());
    }
}