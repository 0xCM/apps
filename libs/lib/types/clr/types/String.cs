//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrTypeSystem
    {
        [DataType("clr.string",true)]
        public readonly struct String : IType<ClrPrimitiveKind>
        {
            public Identifier Name => nameof(String);

            public ClrPrimitiveKind Kind => ClrPrimitiveKind.String;

            public string Format()
                => Name;
        }
    }
}
