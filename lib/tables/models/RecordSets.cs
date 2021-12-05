//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RecordSets
    {
        [MethodImpl(Inline)]
        public static RecordSet<T> load<T>(T[] src)
            where T : struct, IRecord<T>
                => new RecordSet<T>(src);
    }
}