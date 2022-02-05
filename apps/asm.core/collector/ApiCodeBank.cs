//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class ApiCodeBank : IDisposable
    {
        static Outcome entry(in EncodedMemberInfo src, out MethodEntryPoint dst)
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

        public static ApiCodeBank load(Index<EncodedMemberInfo> index, BinaryCode data)
        {
            var dst = new ApiCodeBank();
            var comparer = EncodedMemberComparer.create(EncodedMemberComparer.ModeKind.Target);
            index.Sort(comparer);
            var bytes = data.View;
            var offset = 0u;
            var count = index.Count;
            var offsets = alloc<uint>(count);
            var tokens = alloc<ApiToken>(count);
            var symbols = SymbolDispenser.alloc();
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
            dst.Data = memory.gcpin(data.Storage);
            dst.Offsets = offsets;
            dst.TokenData = tokens;
            return dst;
        }

        ApiCodeBank()
        {
            Symbols = SymbolDispenser.alloc();
        }

        void IDisposable.Dispose()
        {
            (Symbols as IDisposable).Dispose();
            Data.Dispose();
        }

        SymbolDispenser Symbols;

        Index<EncodedMemberInfo> Index;

        ManagedBuffer Data;

        Index<uint> Offsets;

        Index<ApiToken> TokenData;

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Code(uint i)
        {
            var offset = Offsets[i];
            var size =  Index[i].CodeSize;
            return slice(Data.View, offset, size);
        }

        public ByteSize CodeSize
        {
            [MethodImpl(Inline), Op]
            get => Data.Size;
        }

        [MethodImpl(Inline), Op]
        public unsafe MemorySeg Segment(uint i)
            => new MemorySeg(Data.BaseAddress + Offsets[i], Index[i].CodeSize);

        [MethodImpl(Inline), Op]
        public unsafe MemorySeg Segment(int i)
            => Segment((uint)i);

        [MethodImpl(Inline), Op]
        public ReadOnlySpan<byte> Code(int i)
            => Code((uint)i);

        [MethodImpl(Inline), Op]
        public ref readonly ApiToken Token(uint i)
            => ref TokenData[i];

        [MethodImpl(Inline), Op]
        public ref readonly ApiToken Token(int i)
            => ref TokenData[i];

        public ReadOnlySpan<ApiToken> Tokens
        {
            [MethodImpl(Inline)]
            get => TokenData;
        }

        [MethodImpl(Inline), Op]
        public ref readonly EncodedMemberInfo Description(uint i)
            => ref Index[i];

        [MethodImpl(Inline), Op]
        public ref readonly EncodedMemberInfo Description(int i)
            => ref Index[i];

        [MethodImpl(Inline), Op]
        public MemberEncoding Encoding(int i)
            => new MemberEncoding(Token(i), Index[i].CodeSize);

        public uint MemberCount
        {
            [MethodImpl(Inline)]
            get => Index.Count;
        }
    }
}