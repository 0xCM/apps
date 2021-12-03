//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Method)]
    public class ParserAttribute : OpAttribute
    {
        public ParserAttribute(object kind)
        {
            TargetKind = kind;
        }

        public ParserAttribute()
        {
            TargetKind = typeof(void);
        }

        public object TargetKind {get;}
    }
}