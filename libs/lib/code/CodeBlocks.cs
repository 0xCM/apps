//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct CodeBlocks
    {
        const NumericKind Closure = NumericKind.UnsignedInts;

        [MethodImpl(Inline), Op]
        public static CodeBlock block(MemoryAddress src, byte[] data)
            => new CodeBlock(src, data);

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