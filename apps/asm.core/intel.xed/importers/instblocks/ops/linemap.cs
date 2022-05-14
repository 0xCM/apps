//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using System.IO;

    partial class XedImport
    {
        public static LineMap<InstForm> linemap(MemoryFile src)
        {
            const string FirstItemMarker = "amd_3dnow_opcode:";
            const string LastItemMarker = "EOSZ_LIST:";
            const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
            const string Marker = "iform:";
            var data = lines(src);
            var seq = 0u;
            var i0 = 0u;
            var buffer = list<LineInterval<InstForm>>();
            var form = InstForm.Empty;
            for(var i=0u; i<data.Length; i++)
            {
                var line = text.trim(skip(data,i));
                if(text.begins(line,FirstItemMarker))
                    i0 = i;
                else if(text.begins(line, LastItemMarker))
                {
                    var seg = new LineInterval<InstForm>(form, i0, i);
                    buffer.Add(seg);
                }
                else
                {
                    var j = text.index(line,Marker);
                    if(j >= 0)
                    {
                        var k = text.index(line,Chars.Colon);
                        XedParsers.parse(text.trim(text.right(line,k)), out form);
                    }
                }
            }

            return buffer.ToArray();
        }
    }
}