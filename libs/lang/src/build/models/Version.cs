//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        public readonly struct Version
        {
            readonly ulong Data;

            [MethodImpl(Inline)]
            public Version(ushort a, ushort b = 0, ushort c = 0, ushort d = 0)
                => Data = 0;

            [MethodImpl(Inline)]
            public Version(ulong data)
                => Data = data;

            public ushort A
            {
                [MethodImpl(Inline)]
                get => (ushort)Data;
            }

            public ushort B
            {
                [MethodImpl(Inline)]
                get => (ushort)(Data >> 16);
            }

            public ushort C
            {
                [MethodImpl(Inline)]
                get => (ushort)(Data >> 32);
            }

            public ushort D
            {
                [MethodImpl(Inline)]
                get => (ushort)(Data >> 48);
            }

            public string Format()
            {
                var dst = A.ToString();

                if(B != 0)
                    dst += ("." + B.ToString());

                if(C != 0)
                    dst += ("." + C.ToString());

                if(D != 0)
                    dst += ("." + D.ToString());

                return dst;
            }

            public override string ToString()
                => Format();
        }
    }
}