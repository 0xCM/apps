//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ModuleMemory : ITextual
    {
        public readonly NameOld ModuleName;

        public readonly MemoryAddress BaseAddress;

        public readonly ByteSize MemorySize;

        [MethodImpl(Inline)]
        public ModuleMemory(NameOld module, MemoryAddress @base, ByteSize size)
        {
            ModuleName = module;
            BaseAddress = @base;
            MemorySize = size;
        }

        public MemorySeg Segment
        {
            [MethodImpl(Inline)]
            get => MemorySegs.define(BaseAddress, MemorySize);
        }

        public MemoryAddress LastAddress
        {
            [MethodImpl(Inline)]
            get => BaseAddress + MemorySize;
        }

        public string Format()
            => string.Format("{0,-64}: {1}({2})", ModuleName, Segment, MemorySize);

        public override string ToString()
            => Format();
    }
}