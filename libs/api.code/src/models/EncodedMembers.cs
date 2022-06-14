//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class EncodedMembers : IDisposable
    {
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
            var size =  Data.Members[i].CodeSize;
            return slice(Data.CodeBuffer.View, offset, size);
        }

        public ByteSize CodeSize
        {
            [MethodImpl(Inline), Op]
            get => Data.CodeBuffer.Size;
        }

        [MethodImpl(Inline), Op]
        public unsafe MemorySeg Segment(uint i)
            => new MemorySeg(Data.CodeBuffer.BaseAddress + Data.Offsets[i], Data.Members[i].CodeSize);

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
        public ref readonly EncodedMember Member(uint i)
            => ref Data.Members[i];

        [MethodImpl(Inline), Op]
        public ref readonly EncodedMember Member(int i)
            => ref Data.Members[i];

        [MethodImpl(Inline), Op]
        public MemberEncoding Encoding(int i)
            => new MemberEncoding(Token(i), Data.Members[i].CodeSize);

        public uint MemberCount
        {
            [MethodImpl(Inline)]
            get => Data.Tokens.Count;
        }

        internal class EncodingData
        {
            internal ICompositeDispenser Symbols;

            internal Index<EncodedMember> Members;

            internal ManagedBuffer CodeBuffer;

            internal Index<uint> Offsets;

            internal Index<ApiToken> Tokens;
        }
    }
}