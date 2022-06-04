//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct ProjectModel
    {
        public readonly struct Version : ITextual
        {
            public uint Data {get;}

            [MethodImpl(Inline)]
            public Version(byte a, byte b = 0, byte c = 0, byte d = 0)
                => Data = 0;

            [MethodImpl(Inline)]
            public Version(uint data)
                => Data = data;

            public byte A
                => (byte)Data;

            public byte B
                => (byte)(Data >> 8);

            public byte C
                => (byte)(Data >> 16);

            public byte D
                => (byte)(Data >> 24);

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