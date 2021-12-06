//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Collections.Generic;

    public sealed class RegIdDescriptors : ConstLookup<Identifier,RegIdDescriptor>
    {
        public RegIdDescriptors(RegIdDescriptor[] src)
            : base(src.Map(x => (x.InstName, x)).ToDictionary())
        {

        }

        public static implicit operator RegIdDescriptors(RegIdDescriptor[] src)
            => new RegIdDescriptors(src);

        public static new RegIdDescriptors Empty => new(sys.empty<RegIdDescriptor>());
    }
}