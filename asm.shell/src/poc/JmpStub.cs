//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    [Record(TableId)]
    public struct JmpStub : IRecord<JmpStub>
    {
        public const string TableId = "jmp.stub";

        public const byte FieldCount = 6;

        public OpIdentity Method;

        public MemoryAddress StubAddress;

        public MemoryAddress TargetAddress;

        public Address32 Displacement;

        public Address32 Offset;

        public AsmHexCode StubCode;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{64,16,16,16,16,1};
    }
}