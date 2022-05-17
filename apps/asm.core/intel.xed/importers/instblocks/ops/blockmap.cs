//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedImport
    {
        partial class InstBlockImporter
        {
            static bool split(string src, out string name, out string value)
            {
                var result = false;
                var i = text.index(src,Chars.Colon);
                if(i > 0)
                {
                    name = text.trim(text.left(src,i));
                    value = text.trim(text.right(src,i));
                    result = true;
                }
                else
                {
                    name = EmptyString;
                    value = EmptyString;
                }
                return result;
            }

            public static LineMap<FormFields> blockmap(ReadOnlySpan<string> src)
            {
                const string FirstItemMarker = "amd_3dnow_opcode:";
                const string LastItemMarker = "EOSZ_LIST:";
                const string Pattern = "{0,-6} | {1,-6} | {2,-6} | {3,-6} | {4,-64}";
                const string Marker = "iform:";
                var fields = FormFields.Empty;
                var buffer = list<LineInterval<FormFields>>();
                var form = InstForm.Empty;
                var name = EmptyString;
                var value = EmptyString;
                var field = BlockField.amd_3dnow_opcode;
                var counter = 0u;
                var min = 0u;
                var seq = 0u;
                for(var i=0u; i<src.Length; i++)
                {
                    var line = text.trim(skip(src,i));
                    counter += (uint)line.Length;
                    if(split(line, out name, out value))
                    {
                        if(XedParsers.parse(name, out field))
                            fields.Fields[field] = bit.On;
                    }
                    if(text.begins(line,FirstItemMarker))
                        fields.MinLine = i;
                    else if(text.begins(line, LastItemMarker))
                    {
                        fields.MaxLine = i;
                        fields.MinChar = min;
                        fields.MaxChar = counter;
                        fields.Seq = seq++;
                        fields.Lines = fields.MaxLine - fields.MinLine + 1;
                        buffer.Add(new LineInterval<FormFields>(fields, fields.MinLine, fields.MaxLine));
                        fields = FormFields.Empty;
                        min = counter+1;
                    }
                    else
                    {
                        var j = text.index(line,Marker);
                        if(j >= 0)
                            XedParsers.parse(value, out fields.Form);
                    }
                }

                return buffer.ToArray();
            }
        }
    }
}