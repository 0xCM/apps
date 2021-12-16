//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Gen.Projects
{
    public sealed class AssemblyName : ProjectProperty
    {
        public AssemblyName(string value)
            :base(nameof(AssemblyName), value)
        {

        }
    }
}