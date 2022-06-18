//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class EnvSet : EnvSet<EnvVars>
    {
        internal EnvSet(string name, ConstLookup<VarSymbol,object> data, EnvVars vars)
            : base(name, data, vars, vars)
        {
        }
    }
}