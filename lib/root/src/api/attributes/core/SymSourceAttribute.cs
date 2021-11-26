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
        }

        public SymSourceAttribute(object kind)
        {
            SymKind = kind?.ToString() ?? string.Empty;
        }

        public string SymKind {get;}
    }
}