//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class SysVar<V> : SysVar<SysVar<V>,VarName,V>
        where V : IEquatable<V>, IComparable<V>, new()
    {
        public SysVar(VarName name)
            : base(name)
        {
        }

        public SysVar(VarName name, V value)
            : base(name,value)
        {

        }
    }
}