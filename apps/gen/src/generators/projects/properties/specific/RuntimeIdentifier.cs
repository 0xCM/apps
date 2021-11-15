//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Gen.Projects
{
    public sealed class RuntimeIdentifier : ProjectProperty
    {
        public RuntimeIdentifier(string value)
            :base(nameof(RuntimeIdentifier), value)
        {

        }
    }
}