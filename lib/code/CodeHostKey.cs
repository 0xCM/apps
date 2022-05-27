//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct CodeHostKey
    {
        public readonly uint Component;

        public readonly uint HostSeq;

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