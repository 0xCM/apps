//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedRules
    {
        Index<XedFieldDef> ParseFieldDefs()
        {
            var src = XedPaths.DocSource(XedDocKind.Fields);
            var running = Running(string.Format("Parsing {0}", src.ToUri()));
            var dst = list<XedFieldDef>();
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

                var record = XedFieldDef.Empty;
                record.Name = skip(cells,0);

                ref readonly var type = ref skip(cells,2);
                if(!FieldTypes.ExprKind(type, out var ft))
                {
                    result = (false, AppMsg.ParseFailure.Format(nameof(type), type));
                    break;
                }

                ref readonly var width = ref skip(cells,3);
                result = DataParser.parse(width, out record.Width);
                if(result.Fail)
                {
                    result = (false, AppMsg.ParseFailure.Format(nameof(width), width));
                    break;
                }

                record.Type = XedTypes.spec(ft, record.Width);

                ref readonly var vsib = ref skip(cells,4);
                if(!Visibilities.ExprKind(vsib, out record.Visibility))
                {
                    result = (false, AppMsg.ParseFailure.Format(nameof(vsib), vsib));
                    break;
                }

                dst.Add(record);
            }

            if(result)
            {
                Ran(running, string.Format("Parsed {0} records", dst.Count));
                return dst.ToArray().Sort();
            }
            else
            {
                Error(result.Message);
                return sys.empty<XedFieldDef>();
            }
        }
    }
}