//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    using static Root;
    using static core;

    partial struct Lines
    {
        [Op]
        public static ReadOnlySpan<TextLine> read(string src, bool keepblank = false)
        {
            var lines = list<TextLine>();
            var lineNumber = 0u;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null)
                {
                    if(text.blank(next))
                    {
                        if(keepblank)
                            lines.Add(new TextLine(++lineNumber, next));
                    }
                    else
                        lines.Add(new TextLine(++lineNumber, next));

                    next = reader.ReadLine();
                }
            }
            return lines.ViewDeposited();
        }
    }
}