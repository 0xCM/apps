//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection.Metadata.Ecma335;

    using static core;

    partial class CliReader
    {
        public ReadOnlySpan<string> ReadStrings(CliStringKind kind)
            => kind switch {
                CliStringKind.User => ReadUserStrings(),
                CliStringKind.System => ReadSystemStrings(),
                _ => default
            };

        ReadOnlySpan<string> ReadUserStrings()
        {
            int size = HeapSize(HeapIndex.UserString);
            if (size == 0)
                return sys.empty<string>();

            var values = list<string>();
            var handle = MetadataTokens.UserStringHandle(0);
            do
            {
                values.Add(Read(handle));
                handle = MD.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return values.ViewDeposited();
        }

        ReadOnlySpan<string> ReadSystemStrings()
        {
            int size = HeapSize(HeapIndex.String);
            if (size == 0)
                return sys.empty<string>();

            var values = list<string>();
            var handle = MetadataTokens.StringHandle(0);
            do
            {
                values.Add(Read(handle));
                handle = MD.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return values.ViewDeposited();
        }

        public ReadOnlySpan<CliUserString> ReadUserStringInfo()
        {
            var reader = MD;
            int size = MD.GetHeapSize(HeapIndex.UserString);
            if (size == 0)
                return default;

            var handle = MetadataTokens.UserStringHandle(0);
            var counter=0u;
            var dst = list<CliUserString>();

            do
            {
                dst.Add(new CliUserString(seq: counter++, size, HeapOffset(handle), Read(handle)));
                handle = MD.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return dst.ViewDeposited();
        }
    }
}