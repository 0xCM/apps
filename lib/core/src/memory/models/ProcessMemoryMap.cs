//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ProcessMemoryMap
    {
        public Name ProcessName {get;}

        public uint ProcessId {get;}

        public MemoryAddress BaseAddress {get;}

        public ByteSize MemorySize {get;}

        public Index<ModuleMemory> Modules {get;}

        [MethodImpl(Inline)]
        public ProcessMemoryMap(Name name, uint id, MemoryAddress @base, ByteSize size, Index<ModuleMemory> modules)
        {
            ProcessName = name;
            ProcessId = id;
            BaseAddress = @base;
            MemorySize = size;
            Modules = modules;
        }
    }
}