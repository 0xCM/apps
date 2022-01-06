//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;
    using static XedModels;

    partial class XedRules
    {
        Index<FieldDef> ParseSourceFieldDefs()
        {
            var src = XedPaths.FieldDefSource();
            var running = Running(string.Format("Parsing {0}", src.ToUri()));
            var dst = list<FieldDef>();
            var result = Outcome.Success;
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                var content = line.Content.Trim();
                if(text.empty(content) || text.begins(content,Chars.Hash))
                    continue;

                var cells = text.split(text.despace(content),Chars.Space);
                var count = cells.Length;
                if(count < 5)
                {
                    result = (false, string.Format("Only {0} cells found in {1}", count, content));
                    break;
                }

                var record = FieldDef.Empty;
                record.Name = skip(cells,0);

                ref readonly var type = ref skip(cells,2);

                if(!FieldTypes.ExprKind(type, out var ft))
                {
                    result = (false,string.Format("Unanticipated type {0}", type));
                    break;
                }

                ref readonly var width = ref skip(cells,3);
                result = DataParser.parse(width, out record.Width);
                if(result.Fail)
                {
                    result = (false,string.Format("Unable to parse width from {0}", width));
                    break;
                }

                record.Type = XedTypes.spec(ft, record.Width);

                ref readonly var vsib = ref skip(cells,4);
                if(!Visibilities.ExprKind(vsib, out record.Visibility))
                {
                    result = (false,string.Format("Unanticipated visiblity {0}", vsib));
                    break;
                }

                dst.Add(record);
            }
            if(result)
            {
                Ran(running, string.Format("Parsed {0} records", dst.Count));
                return dst.ToArray();
            }
            else
            {
                Error(result.Message);
                return sys.empty<FieldDef>();
            }
        }
    }
}