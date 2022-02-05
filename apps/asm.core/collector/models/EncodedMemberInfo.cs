//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct EncodedMemberInfo : IComparable<EncodedMemberInfo>
    {
        public const string TableId = "api.members.info";

        public const byte FieldCount = 11;

        public Hex64 Id;

        public MemoryAddress EntryAddress;

        public MemoryAddress EntryRebase;

        public MemoryAddress TargetAddress;

        public MemoryAddress TargetRebase;

        public @string StubAsm;

        public Disp32 Disp;

        public ushort CodeSize;

        public @string Host;

        public @string Sig;

        public @string Uri;

        [MethodImpl(Inline)]
        public int CompareTo(EncodedMemberInfo src)
            => EntryAddress.CompareTo(src.EntryAddress);

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{16,16,16,16,16,24,10,8,32,120,1};
    }
}