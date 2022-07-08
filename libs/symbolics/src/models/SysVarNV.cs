//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class SysVar<N,V> : SysVar<SysVar<N,V>, N,V>
        where N : unmanaged, IDataType<N>, IExpr
        where V : IEquatable<V>, IComparable<V>, new()
    {
        public SysVar(N name)
            : base(name)
        {
        }

        public SysVar(N name, V value)
            : base(name,value)
        {

        }
    }
}