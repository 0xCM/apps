//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Field)]
    public class RenderLiteralAttribute : Attribute
    {
        public string LiteralValue {get;}

        public ushort Length {get;}

        public RenderLiteralAttribute(string content)
        {
            LiteralValue = content;
            Length = 0;
        }

        public RenderLiteralAttribute(string content, ushort length)
        {
            LiteralValue = content;
            Length = length;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class RenderPatternAttribute : Attribute
    {
        public string PatternText {get;}

        public byte ArgCount {get;}

        public RenderPatternAttribute(string pattern)
        {
            PatternText = pattern;
            ArgCount = 0;
        }

        public RenderPatternAttribute(byte args)
        {
            ArgCount = args;
            PatternText = "";
        }

        public RenderPatternAttribute(byte args, string pattern)
        {
            PatternText = pattern;
            ArgCount = args;
        }
    }
}