//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Record(TableId)]
    public struct ApiMemberInfo : IComparableRecord<ApiMemberInfo>
    {
        public const string TableId = "api.members";

        public const byte FieldCount = 7;

        public MemoryAddress EntryPoint;

        public ApiClassKind ApiKind;

        public CliToken Token;

        public CliSig CliSig;

        public utf8 DisplaySig;

        public utf8 Uri;

        public BinaryCode MsilCode;

        [MethodImpl(Inline)]
        public int CompareTo(ApiMemberInfo src)
            => EntryPoint.CompareTo(src.EntryPoint);

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{16,16,16,80,120,120,60};
    }
}