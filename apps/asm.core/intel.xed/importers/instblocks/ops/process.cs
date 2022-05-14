//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedImport
    {
        public static void process(MemoryFile src, IInstBlockReceiver dst)
        {
            const string FirstItemMarker = "amd_3dnow_opcode:";
            const string LastItemMarker = "EOSZ_LIST:";
            const string Marker = "iform:";
            var lines = XedImport.lines(src);
            var seq = 0u;
            var i0 = 0u;
            var counter = 0u;
            var form = InstForm.Empty;
            var fields = Bitfields.bv<BlockField>(0);
            var field = BlockField.amd_3dnow_opcode;

            for(var i=0u; i<lines.Length; i++)
            {
                var line = text.trim(text.despace(skip(lines,i)));
                if(empty(line))
                    continue;

                var z = text.index(line,Chars.Colon);
                if(z > 0)
                {
                    if(!XedParsers.parse(text.left(line,z), out field))
                        term.warn($"The source text '{line}' is not understood");
                    else
                        fields[field] = bit.On;
                }

                if(text.begins(line,FirstItemMarker))
                {
                    i0 = i;
                }
                else if(text.begins(line, LastItemMarker))
                {
                    dst.Accept(block(seq++, fields, range(form, i0, counter), lines));
                    counter = 0;
                    fields = 0;
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

                counter++;
            }
        }
    }
}