//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class SysVar<V> : SysVar<SysVar<V>,Name,V>
        where V : IEquatable<V>, IComparable<V>, new()
    {
        public SysVar(Name name)
            : base(name)
        {
        }

        public SysVar(Name name, V value)
            : base(name,value)
        {

        }
    }
}