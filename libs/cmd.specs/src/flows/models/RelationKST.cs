//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct Relation<K,S,T> : IRelation<K,S,T>, IHashed
        where K : unmanaged
        where S : unmanaged
        where T : unmanaged
    {
        [Render(32)]
        public readonly FlowId Id;

        [Render(32)]
        public readonly K Kind;

        [Render(32)]
        public readonly S Source;

        [Render(32)]
        public readonly T Target;

        [MethodImpl(Inline)]
        public Relation(FlowId id, K kind, S src, T dst)
        {
            Id = id;
            Kind = kind;
            Source = src;
            Target = dst;
        }

        K IRelation<K,S,T>.Kind
            => Kind;

        S IRelation<K,S,T>.Source
            => Source;

        T IRelation<K,S,T>.Target
            => Target;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Id.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => $"{Kind}:{Source} -> {Target}";


        public override string ToString()
            => Format();

        public static implicit operator DataFlow<K,S,T>(Relation<K,S,T> src)
            => new DataFlow<K,S,T>(src.Id, src.Kind, src.Source, src.Target);
    }
}