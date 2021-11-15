//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;
    using System.Reflection.Metadata.Ecma335;

    using static Root;

    partial class CliReader
    {
        [MethodImpl(Inline), Op]
        public Address32 HeapOffset(UserStringHandle handle)
            => (Address32)MD.GetHeapOffset(handle);

        [MethodImpl(Inline), Op]
        public Address32 HeapOffset(BlobHandle handle)
            => (Address32)MD.GetHeapOffset(handle);

        [MethodImpl(Inline), Op]
        public Address32 HeapOffset(StringHandle handle)
            => (Address32)MD.GetHeapOffset(handle);

        [MethodImpl(Inline), Op]
        public Address32 HeapOffset(GuidHandle handle)
            => (Address32)MD.GetHeapOffset(handle);
    }
}