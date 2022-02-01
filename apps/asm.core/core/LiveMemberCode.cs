//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    [Record(TableId)]
    public struct LiveMemberCode : IRecord<LiveMemberCode>
    {
        public const string TableId = "code.live";

        public const byte FieldCount = 6;

        public OpUri Name;

        public LocatedSymbol Entry;

        public bit IsStub;

        public MemoryAddress Target;

        public Disp32 Disp;

        public AsmHexCode StubEncoding;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{64,16,8,16,16,1};


    }
}