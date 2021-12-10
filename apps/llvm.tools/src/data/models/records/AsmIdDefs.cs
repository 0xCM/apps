//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public sealed class AsmIdDefs : ConstLookup<Identifier,AsmIdDef>
    {
        public AsmIdDefs(AsmIdDef[] src)
            : base(src.Map(x => (x.InstName, x)).ToDictionary())
        {

        }

        public ushort AsmId(Identifier inst)
        {
            if(Find(inst, out var value))
            {
                return value.Id;
            }
            else
                return 0xFFFF;
        }

        public static implicit operator AsmIdDefs(AsmIdDef[] src)
            => new AsmIdDefs(src);

        public static new AsmIdDefs Empty => new(sys.empty<AsmIdDef>());
    }
}