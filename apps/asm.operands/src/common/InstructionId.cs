//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct InstructionId
    {
        public readonly Hex32 DocId;

        public readonly EncodingId EncodingId;

        [MethodImpl(Inline)]
        public InstructionId(Hex32 doc, EncodingId encoding)
        {
            DocId = doc;
            EncodingId = encoding;
        }

        public string Format()
            => string.Format("{0:x8}{1:x16}", (uint)DocId, (ulong)EncodingId);

        public override string ToString()
            => Format();

        public static InstructionId Empty => default;

    }
}