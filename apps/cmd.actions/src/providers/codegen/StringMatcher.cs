//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class StringMatcher
    {
        public static StringMatcher build(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var expressions = alloc<string>(count);
            var indices = alloc<CharIndices>(count);
            var lengths = alloc<ushort>(count);
            for(var i=0; i<count; i++)
                seek(expressions, i) = skip(src,i);

            expressions.Sort();
            for(var i=0; i<count; i++)
            {
                ref readonly var expr = ref skip(expressions,i);
                seek(indices, i) = CharIndices.compute(expr);
                seek(lengths, i) = (ushort)expr.Length;
            }

            return new StringMatcher(expressions, indices, lengths);
        }

        public readonly struct Entry
        {
            public readonly uint Key;

            public readonly string Target;

            public readonly ushort Length;

            public readonly CharIndices Indices;

            [MethodImpl(Inline)]
            public Entry(uint key, string target, CharIndices indices, ushort length)
            {
                Key = key;
                Target = target;
                Indices = indices;
                Length = length;
            }

            public string Format()
                => string.Format("[{0}, {1}, {2}, <{3}>", Key, text.enquote(Target), Length, Indices);

            public override string ToString()
                => Format();

        }

        readonly Index<string> TargetData;

        readonly Index<CharIndices> IndexData;

        readonly Index<ushort> LengthData;

        readonly Index<Entry> EntryData;

        public StringMatcher(string[] targets, CharIndices[] indices, ushort[] lengths)
        {
            TargetData = targets;
            IndexData = indices;
            LengthData = lengths;
            EntryCount = TargetData.Count;
            EntryData = alloc<Entry>(EntryCount);
            var max = z16;
            var min = ushort.MaxValue;
            for(var i=0u; i<EntryCount; i++)
            {
                ref readonly var length = ref LengthData[i];
                EntryData[i] = new Entry(i, TargetData[i], IndexData[i], length);
                if(length > max)
                    max = length;

                if(length < min)
                    min = length;
            }
            MinLength = min;
            MaxLength = max;
            CharCounts = CharCounts.compute(targets);
            CharPositions = CharPositions.compute(targets);
        }

        public uint EntryCount {get;}

        public ushort MinLength {get;}

        public ushort MaxLength {get;}

        public CharCounts CharCounts {get;}

        public CharPositions CharPositions {get;}

        public ReadOnlySpan<ushort> Lengths
        {
            [MethodImpl(Inline)]
            get => LengthData;
        }

        public ref readonly Entry this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref EntryData[i];
        }

        public ref readonly Entry this[int i]
        {
            [MethodImpl(Inline)]
            get => ref EntryData[i];
        }

        public ReadOnlySpan<Entry> Entries
        {
            [MethodImpl(Inline)]
            get => EntryData;
        }
    }
}