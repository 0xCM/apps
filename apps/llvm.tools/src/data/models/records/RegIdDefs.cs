//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    public sealed class RegIdDefs : ConstLookup<Identifier,RegIdDef>
    {
        public RegIdDefs(RegIdDef[] src)
            : base(src.Map(x => (x.InstName, x)).ToDictionary())
        {

        }

        public static implicit operator RegIdDefs(RegIdDef[] src)
            => new RegIdDefs(src);

        public static new RegIdDefs Empty => new(sys.empty<RegIdDef>());
    }
}