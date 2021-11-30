//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class FormatterAttribute : Attribute
    {
        public FormatterAttribute(Type src)
        {
            SourceType = src;
            TargetType = typeof(string);
        }

        public FormatterAttribute(Type src, Type dst)
        {
            SourceType = src;
            TargetType = dst;
        }

        public Type SourceType {get;}

        public Type TargetType {get;}
    }
}