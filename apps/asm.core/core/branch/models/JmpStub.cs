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

        public const byte FieldCount = 5;

        public OpIdentity Name;

        public LocatedSymbol Stub;

        public MemoryAddress Target;

        public Disp32 Disp;

        public AsmHexCode Encoding;

        [MethodImpl(Inline)]
        public JmpRel32 ToModel()
            => AsmRel32.from(this);

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{64,16,16,16,1};
    }
}