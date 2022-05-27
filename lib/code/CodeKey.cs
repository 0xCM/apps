//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct CodeKey
    {
        public readonly CodeHostKey HostKey;

        public readonly uint BlockSeq;

        [MethodImpl(Inline)]
        public CodeKey(CodeHostKey host, uint block)
        {
            HostKey = host;
            BlockSeq = block;
        }

        public string Format()
            => string.Format("{0}:{1:D3}", HostKey, BlockSeq);

        public override string ToString()
            => Format();

        public static CodeKey Empty => default;
    }
}