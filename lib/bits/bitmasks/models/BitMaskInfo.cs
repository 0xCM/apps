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
        public const string TableId = "bitmasks";

        public string Name;

        public TypeCode TypeCode;

        public object Data;

        public string Text;

        public NumericBaseKind Base;
    }
}