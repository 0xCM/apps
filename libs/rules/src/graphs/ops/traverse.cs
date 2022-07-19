//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Graphs
    {
        public static void Traverse<V>(V src, Action<V> receiver)
            where V : IEquatable<V>, IVertex<V>
        {
            receiver(src);
            var targets = src.Targets.View();
            for(var i=0; i<targets.Length; i++)
                Traverse<V>(skip(targets,i).Value, receiver);
        }
    }
}