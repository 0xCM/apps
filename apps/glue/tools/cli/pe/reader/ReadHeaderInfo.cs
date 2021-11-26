//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static PeRecords;
    using static core;

    partial class PeReader
    {
        public ReadOnlySpan<SectionHeaderInfo> ReadHeaderInfo()
        {
            var headers = PeHeaders;
            var pe = headers.PEHeader;
            var sections = SectionHeaders;
            var count = sections.Length;
            var buffer = alloc<SectionHeaderInfo>(count);
            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var section = ref skip(sections,i);
                ref var record = ref seek(target,i);
                record.File = Source.FileName;
                record.EntryPoint = (Address32)pe.AddressOfEntryPoint;
                record.CodeBase = (Address32)pe.BaseOfCode;
                record.GptRva = (Address32)pe.GlobalPointerTableDirectory.RelativeVirtualAddress;
                record.GptSize = (ByteSize)pe.GlobalPointerTableDirectory.Size;
                record.SectionAspects = section.SectionCharacteristics;
                record.SectionName = section.Name;
                record.RawDataAddress = (Address32)section.PointerToRawData;
                record.RawDataSize = (uint)section.SizeOfRawData;
            }
            return buffer;
        }
    }
}