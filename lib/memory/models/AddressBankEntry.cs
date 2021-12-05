//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AddressBankEntry : IRecord<AddressBankEntry>
    {
        public const string TableId = "address-bank.entry";

        public AddressBankIndex Index;

        public Address16 Selector;

        public Address32 Base;

        public ByteSize Size;

        public MemoryAddress Target;

        public ByteSize TotalSize;
    }
}