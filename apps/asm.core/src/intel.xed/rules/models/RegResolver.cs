//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RegResolver : INameResolver<RegResolver>
        {
            public int NameId {get;}

            public RegResolver(int id)
            {
                NameId = id;
            }

            public string Name
            {
                [MethodImpl(Inline)]
                get => RegResolvers.Instance.Resolve(this);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => NameId < 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => NameId >= 0;
            }

            [MethodImpl(Inline)]
            public RegResolver WithId(int id)
                => new RegResolver(id);

            public string Format()
                => Name;

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator int(RegResolver src)
                => src.NameId;

            [MethodImpl(Inline)]
            public static explicit operator uint(RegResolver src)
                => (uint)src.NameId;

            [MethodImpl(Inline)]
            public static explicit operator RegResolver(int src)
                => new RegResolver(src);

            public static RegResolver Empty => new RegResolver(-1);
        }
    }
}