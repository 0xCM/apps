//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        public sealed class AssemblyName : ProjectProperty
        {
            public AssemblyName(string value)
                :base(nameof(AssemblyName), value)
            {

            }
        }
    }
}