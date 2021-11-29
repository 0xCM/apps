//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public readonly partial struct CodeBlocks
    {
        const NumericKind Closure = NumericKind.UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CodeBlock<K> block<K>(K kind, CodeKey key, MemoryAddress src, byte[] data)
            where K : unmanaged
                => new CodeBlock<K>(kind, block(key,src,data));

        [MethodImpl(Inline), Op]
        public static CodeBlock block(uint component, uint hostseq, uint blockseq, MemoryAddress src, byte[] data)
            => block(codekey(component, hostseq, blockseq), src, data);

        [MethodImpl(Inline), Op]
        public static CodeBlock block(CodeKey key, MemoryAddress src, byte[] data)
            => new CodeBlock(key, src, data);

        [MethodImpl(Inline), Op]
        public static CodeHostKey hostkey(uint component, uint host)
            => new CodeHostKey(component, host);

        [MethodImpl(Inline), Op]
        public static CodeKey codekey(CodeHostKey host, uint block)
            => new CodeKey(host, block);

        [MethodImpl(Inline), Op]
        public static CodeKey codekey(uint component, uint host, uint block)
            => codekey(hostkey(component, host), block);
    }
}