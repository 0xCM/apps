//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [AttributeUsage(AttributeTargets.Field)]
    public class RenderPatternAttribute : Attribute
    {
        public readonly string PatternText;

        public readonly byte ArgCount;

        // public RenderPatternAttribute(string pattern)
        // {
        //     PatternText = pattern;
        //     ArgCount = 0;
        // }

        // public RenderPatternAttribute(byte args)
        // {
        //     ArgCount = args;
        //     PatternText = "";
        // }

        public RenderPatternAttribute(byte args, string pattern)
        {
            PatternText = pattern;
            ArgCount = args;
        }
    }
}