//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct CodeKey
    {
        public CodeHostKey HostKey {get;}

        public uint BlockSeq {get;}

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