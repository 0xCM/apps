//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Record(TableId)]
    public struct BitMaskInfo : IRecord<BitMaskInfo>
    {
        public const string TableId = "api.bitmasks";

        public const byte FieldCount = 5;

        public string Name;

        public NumericBaseKind Base;

        public TypeSpec DataType;

        public BitNumber MaskData;

        public string Text;

        public static ReadOnlySpan<byte> RenderWidths => new byte[]{32,8,12,82,1};
    }
}