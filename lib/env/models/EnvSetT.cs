//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EnvSet<S> : EnvProvider<EnvSet<S>>, IEnvSet<S>
        where S : struct
    {
        readonly ConstLookup<VarSymbol,object> Data;

        internal EnvSet(string name, ConstLookup<VarSymbol,object> data, S src, Index<EnvVar> vars)
            : base(vars)
        {
            Data = data;
            Name = name;
        }

        public override string Name {get;}
    }
}