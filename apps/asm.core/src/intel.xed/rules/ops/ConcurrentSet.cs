//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections;

    using static core;

    public class ConcurrentSet<T> : IEnumerable<T>
    {
        readonly ConcurrentDictionary<T,T> Data;

        public ConcurrentSet()
        {
            Data = new();
        }

        public ConcurrentSet(T[] members)
        {
            Data = new();
            core.iter(members, m => Add(m));
        }

        [MethodImpl(Inline)]
        public bool Add(T src)
            => Data.TryAdd(src,src);

        [MethodImpl(Inline)]
        public void Add(params T[] src)
            => core.iter(src, m => Add(m));

        public IEnumerator<T> GetEnumerator()
            => Members.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => ((IEnumerable)Members).GetEnumerator();

        public ICollection<T> Members
        {
            [MethodImpl(Inline)]
            get => Data.Values;
        }

        public ConcurrentSet<T> Clear()
        {
            Data.Clear();
            return this;
        }
    }
}