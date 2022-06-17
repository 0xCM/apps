//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class EnvSet : EnvSet<Index<EnvVar>>
    {
        internal EnvSet(string name, ConstLookup<VarSymbol,object> data, Index<EnvVar> vars)
            : base(name, data, vars, vars)
        {
        }
    }
}