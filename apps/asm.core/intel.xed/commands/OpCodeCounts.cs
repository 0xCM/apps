//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedPatterns;

    using Asm;

    [Record(TableId)]
    public struct OpCodeCounts : IComparable<OpCodeCounts>
    {
        public const byte FieldCount = 8;

        public const string TableId = "xed.opcodes.counts";

        public uint Seq;

        public uint PatternId;

        public InstClass InstClass;

        public OpCodeKind OcKind;

        public AsmOcValue OcValue;

        public MachineMode Mode;

        public InstPatternBody PatternBody;

        public PatternSort Sort;

        public XedOpCode OpCode
        {
            [MethodImpl(Inline)]
            get => new XedOpCode(Mode, OcKind,OcValue);
        }

        public int CompareTo(OpCodeCounts src)
        {
            var result = InstClass.Classifier.CompareTo(src.InstClass.Classifier);
            if(result == 0)
            {
                result = OcValue.CompareTo(src.OcValue);
                if(result == 0)
                {
                    result = OcKind.CompareTo(src.OcKind);
                    if(result==0)
                    {
                        result = ((byte)Sort.Lockable).CompareTo((byte)src.Sort.Lockable);
                        if(result==0 && Sort.Lockable)
                        {
                            result = ((byte)Sort.LockValue).CompareTo((byte)src.Sort.LockValue);
                        }
                    }
                }
            }

            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,18,12,20,8,160,1};

    }
}