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
        public readonly string LiteralValue;

        public ushort Length
        {
            get => (ushort)LiteralValue.Length;
        }

        public RenderLiteralAttribute(string content)
        {
            LiteralValue = content;
        }

        public RenderLiteralAttribute(string content, ushort length)
        {
            LiteralValue = content;
        }
    }
}