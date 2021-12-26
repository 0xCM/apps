//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct CodeHostKey
    {
        public uint Component {get;}

        public uint HostSeq {get;}

        [MethodImpl(Inline)]
        public CodeHostKey(uint component, uint host)
        {
            Component = component;
            HostSeq = host;
        }

        public string Format()
            => string.Format("{0:D3}:{1:D3}", Component, HostSeq);

        public override string ToString()
            => Format();

        public static CodeHostKey Empty => default;
    }
}