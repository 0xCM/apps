//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public class CpuidParser
        {
            ConcurrentDictionary<uint,asci64> IsaBuffer = new();

            ConcurrentBag<CpuIdImport> CpuIdBuffer = new();

            SortedLookup<uint,string> SortedIsa = dict<uint,string>();

            Index<CpuIdImport> CpuIdFinal = sys.empty<CpuIdImport>();

            Index<IsaImport> IsaFinal = sys.empty<IsaImport>();

            public Output Parsed => new Output(this);

            public void Run(Index<string> data)
            {
                iter(data.Select(normalize), Parse, true);

                var _sortedIsa = IsaBuffer.Map(x => (key:x.Key, name:text.ifempty(x.Value, EmptyString))).ToSortedLookup();

                SortedIsa = _sortedIsa;
                var keys = SortedIsa.Keys;
                var count = keys.Length;
                var dst = alloc<IsaImport>(count);
                for(var i=0u; i<count; i++)
                {
                    ref readonly var key = ref skip(keys,i);
                    asci64 isa = text.ifempty(SortedIsa[key], EmptyString);
                    record(isa, out dst[i]);
                }

                IsaFinal = dst.Sort().Resequence();
                CpuIdFinal = CpuIdBuffer.Index().Sort().Resequence();
            }

            uint IsaKey;

            uint CpuIdKey;

            [MethodImpl(Inline)]
            uint NextIsaKey()
                => inc(ref IsaKey);

            [MethodImpl(Inline)]
            uint NextCpuIdKey()
                => inc(ref CpuIdKey);

            uint StoreIsa(asci64 src)
            {
                var seq = NextIsaKey();
                IsaBuffer.TryAdd(seq,src);
                return seq;
            }

            void StoreCpuId(asci64 xedIsa, string src)
            {
                const string Null = "n/a";
                var parts = text.split(src, Chars.Space).ToIndex();
                var count = parts.Length;
                for(var i=0u; i<count; i++)
                    if(parts[i] != Null)
                        CpuIdBuffer.Add(Record(IsaName(xedIsa), parts[i], out _));
            }

            [MethodImpl(Inline)]
            CpuIdImport Record(asci32 isa, asci64 cpuidSpec, out CpuIdImport dst)
                => dst = new CpuIdImport(isa, NextCpuIdKey(), cpuidSpec);

            void Parse(string src)
            {
                var input = Require.notnull(src);
                if(!IsComment(input))
                {
                    if(split(input, out asci64 isa, out string cpuid))
                    {
                        StoreIsa(isa);
                        if(nonempty(cpuid))
                            StoreCpuId(isa, cpuid);
                    }
                }
            }

            [MethodImpl(Inline)]
            static asci32 IsaName(asci64 src)
                => src.Format().Remove("XED_ISA_SET_");

            static void record(asci64 src, out IsaImport dst)
            {
                dst.Seq = 0;
                dst.XedName = src;
                dst.IsaName = IsaName(src);
            }

            static bool split(string src, out asci64 isa, out string cpuid)
            {
                var result = true;
                var j = text.index(src,Chars.Colon);
                if(j > 0)
                {
                    isa = text.ifempty(text.left(src,j),EmptyString);
                    cpuid = text.ifempty(text.trim(text.right(src,j)), EmptyString);
                }
                else
                {
                    isa = EmptyString;
                    cpuid = EmptyString;
                    result = false;
                }
                return result;
            }

            static bool IsComment(string src)
                => text.begins(src, Chars.Hash);

            static string normalize(string src)
            {
                var input = text.ifempty(text.trim(text.despace(src)), EmptyString);
                var output = input;
                if(IsComment(input))
                    return output;

                var i = text.index(input, Chars.Hash);
                if(i > 0)
                    output = text.trim(text.left(input,i));
                return output;
            }

            public readonly struct Output
            {
                readonly CpuidParser Parser;

                [MethodImpl(Inline)]
                internal Output(CpuidParser parser)
                {
                    Parser = parser;
                }

                public ref readonly Index<CpuIdImport> CpuIdRecords
                    => ref Parser.CpuIdFinal;

                public ref readonly Index<IsaImport> IsaRecords
                    => ref Parser.IsaFinal;
            }
        }
    }
}