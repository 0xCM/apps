//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRecords;
    partial struct XedModels
    {
        public readonly struct XedOpCode
        {
            [MethodImpl(Inline)]
            public static XedOpCode from(in XedOpCodeRecord src)
                => new XedOpCode(src.Class, src.Kind, src.Value);

            public readonly IClass Class;

            public readonly OpCodeKind Kind;

            public readonly ByteBlock4 Value;

            [MethodImpl(Inline)]
            public XedOpCode(IClass @class, OpCodeKind kind, ByteBlock4 value)
            {
                Class = @class;
                Kind = kind;
                Value = value;
            }
        }
    }
}