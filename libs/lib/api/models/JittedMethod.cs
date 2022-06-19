//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    public readonly struct JittedMethod : IComparable<JittedMethod>
    {
        public ApiHostUri Host {get;}

        public MethodInfo Method {get;}

        public MemoryAddress Location {get;}

        [MethodImpl(Inline)]
        public JittedMethod(ApiHostUri host, MethodInfo method, MemoryAddress location = default)
        {
            Host = host;
            Method = method;
            Location = location;
        }

        [MethodImpl(Inline)]
        public int CompareTo(JittedMethod src)
            => Location.CompareTo(src.Location);
    }
}