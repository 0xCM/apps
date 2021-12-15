//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class SymSourceAttribute : Attribute
    {
        public SymSourceAttribute()
        {
            SymKind = string.Empty;
            NumericBase = NumericBaseKind.Base10;
        }

        public SymSourceAttribute(NumericBaseKind nbk)
        {
            SymKind = string.Empty;
            NumericBase = nbk;
        }

        public SymSourceAttribute(object kind)
        {
            SymKind = kind?.ToString() ?? string.Empty;
            NumericBase = NumericBaseKind.Base10;
        }

        public SymSourceAttribute(object kind, NumericBaseKind nbk)
        {
            SymKind = kind?.ToString() ?? string.Empty;
            NumericBase = nbk;
        }

        public string SymKind {get;}

        public NumericBaseKind NumericBase {get;}
    }
}