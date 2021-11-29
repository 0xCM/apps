//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    partial struct Lines
    {
        [Op]
        public static Count traverse(string src, Action<TextLine> receiver, bool keepblank = false)
        {
            var lineNumber = 0u;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null)
                {
                    if(text.blank(next))
                    {
                        if(keepblank)
                            receiver(new TextLine(++lineNumber, next));
                    }
                    else
                        receiver(new TextLine(++lineNumber, next));
                    next = reader.ReadLine();
                }
            }
            return lineNumber;
        }
    }
}