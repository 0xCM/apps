//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static MemorySections;

    [ApiHost]
    public readonly partial struct BssSections : ISectionDispenser<BssSections>
    {
        const uint _EntryCount = 4;

        [Op]
        public static BssSections dispenser()
            => new BssSections(_ContainerAddress);

        MemoryAddress ContainerAddress {get;}

        [MethodImpl(Inline)]
        BssSections(MemoryAddress @base)
        {
            ContainerAddress = @base;
        }

        public uint EntryCount => _EntryCount;

        [MethodImpl(Inline), Op]
        public unsafe ref readonly Section Entry(ushort index)
            => ref Container()[index];

        [Op]
        public ReadOnlySpan<Section> Entries()
            => Container().View;

        [Op]
        uint ISectionDispenser.EntryCount
            => _EntryCount;

        [Op]
        Section ISectionDispenser.Entry(ushort id)
            => Entry(id);

        [Op]
        ReadOnlySpan<Section> ISectionDispenser.Entries()
            => Entries();

        [MethodImpl(Inline), Op]
        ref readonly Index<Section> Container()
            => ref _Container;

        [Op]
        static uint initialize(Span<Section> dst)
        {
            seek(dst,0) = section(default(Bss1x16x16x64_0));
            seek(dst,1) = section(default(Bss1x16x16x64_1));
            seek(dst,2) = section(default(Bss1x16x16x64_2));
            seek(dst,3) = section(default(Bss1x16x16x64_3));
            MemorySections.initialize(skip(dst,0));
            MemorySections.initialize(skip(dst,1));
            MemorySections.initialize(skip(dst,2));
            MemorySections.initialize(skip(dst,3));
            return _EntryCount;
        }

        [FixedAddressValueType]
        static Index<Section> _Container;

        static MemoryAddress _ContainerAddress;

        static BssSections()
        {
            _Container = alloc<Section>(_EntryCount);
            initialize(_Container.Edit);
            _ContainerAddress = address(_Container);
        }
    }
}