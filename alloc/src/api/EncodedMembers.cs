//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class EncodedMembers : IDisposable
    {
        public static EncodedMembers load(Index<EncodedMember> index, BinaryCode data)
        {
            var dst = new EncodingData();
            index.Sort(EncodedMember.comparer(EncodedMember.CmpKind.Target));
            var bytes = data.View;
            var offset = 0u;
            var count = index.Count;
            var offsets = alloc<uint>(count);
            var tokens = alloc<ApiToken>(count);
            var symbols = Alloc.symbols();
            for(var i=0; i<count; i++)
            {
                ref readonly var info = ref index[i];
                ref readonly var size = ref info.CodeSize;
                if(offset + size > bytes.Length)
                    Errors.Throw(string.Format("Offset exceeded at {0} for {1}", i, info.Uri));

                seek(offsets,i) = offset;

                var result = entry(info, out var ep);
                if(result.Fail)
                    Errors.Throw(result.Message);

                seek(tokens,i) = ApiToken.create(symbols, ep, info.TargetAddress);
                var code = slice(bytes, offset, size);

                offset += size;
            }

            dst.Symbols = symbols;
            dst.Index = index;
            dst.CodeBuffer = memory.gcpin(data.Storage);
            dst.Offsets = offsets;
            dst.Tokens = tokens;
            return new EncodedMembers(dst);
        }

        static Outcome entry(in EncodedMember src, out MethodEntryPoint dst)
        {
            var result = ApiUri.parse(src.Uri, out var uri);
            dst = MethodEntryPoint.Empty;
            if(result)
            {
                if(uri.IsEmpty)
                    result = (false, string.Format("Empty uri for {0}", src.Uri));
                else
                    dst = new MethodEntryPoint(src.EntryAddress, Require.notnull(uri), src.Sig);
            }
            return result;
        }

        EncodingData Data;

        internal EncodedMembers(EncodingData data)
        {
            Data = data;
        }

        void IDisposable.Dispose()
        {
            (Data.Symbols as IDisposable).Dispose();
            Data.CodeBuffer.Dispose();
        }

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Code(uint i)
        {
            var offset = Data.Offsets[i];
            var size =  Data.Index[i].CodeSize;
            return slice(Data.CodeBuffer.View, offset, size);
        }

        public ByteSize CodeSize
        {
            [MethodImpl(Inline), Op]
            get => Data.CodeBuffer.Size;
        }

        [MethodImpl(Inline), Op]
        public unsafe MemorySeg Segment(uint i)
            => new MemorySeg(Data.CodeBuffer.BaseAddress + Data.Offsets[i], Data.Index[i].CodeSize);

        [MethodImpl(Inline), Op]
        public unsafe MemorySeg Segment(int i)
            => Segment((uint)i);

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Code(int i)
            => Code((uint)i);

        [MethodImpl(Inline), Op]
        public ref readonly ApiToken Token(uint i)
            => ref Data.Tokens[i];

        [MethodImpl(Inline), Op]
        public ref readonly ApiToken Token(int i)
            => ref Data.Tokens[i];

        public ReadOnlySpan<ApiToken> Tokens
        {
            [MethodImpl(Inline)]
            get => Data.Tokens;
        }

        [MethodImpl(Inline), Op]
        public ref readonly EncodedMember Description(uint i)
            => ref Data.Index[i];

        [MethodImpl(Inline), Op]
        public ref readonly EncodedMember Description(int i)
            => ref Data.Index[i];

        [MethodImpl(Inline), Op]
        public MemberEncoding Encoding(int i)
            => new MemberEncoding(Token(i), Data.Index[i].CodeSize);

        public uint MemberCount
        {
            [MethodImpl(Inline)]
            get => Data.Index.Count;
        }

        internal class EncodingData
        {
            internal SymbolDispenser Symbols;

            internal Index<EncodedMember> Index;

            internal ManagedBuffer CodeBuffer;

            internal Index<uint> Offsets;

            internal Index<ApiToken> Tokens;
        }
    }
}