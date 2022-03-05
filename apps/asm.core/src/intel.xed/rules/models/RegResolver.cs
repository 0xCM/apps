//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RegResolver
        {
            internal readonly int ResolverId;

            public RegResolver(int id)
            {
                ResolverId = id;
            }

            public string Name
            {
                [MethodImpl(Inline)]
                get => RegResolvers.name(this);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => ResolverId < 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => ResolverId >= 0;
            }

            public string Format()
                => Name;

            public override string ToString()
                => Format();

            public static RegResolver Empty => new RegResolver(-1);

            [MethodImpl(Inline)]
            public static explicit operator int(RegResolver src)
                => src.ResolverId;

            [MethodImpl(Inline)]
            public static explicit operator uint(RegResolver src)
                => (uint)src.ResolverId;

            [MethodImpl(Inline)]
            public static explicit operator RegResolver(int src)
                => new RegResolver(src);
        }
    }
}