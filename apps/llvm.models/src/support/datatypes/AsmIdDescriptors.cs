//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Collections.Generic;

    public sealed class AsmIdDescriptors : ConstLookup<Identifier,AsmIdDescriptor>
    {
        public AsmIdDescriptors(AsmIdDescriptor[] src)
            : base(src.Map(x => (x.InstName, x)).ToDictionary())
        {

        }

        public static implicit operator AsmIdDescriptors(AsmIdDescriptor[] src)
            => new AsmIdDescriptors(src);
    }
}