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
        // Index<XedFieldDef> ImportFieldDefs()
        // {
        //     var src = XedPaths.DocSource(XedDocKind.Fields);
        //     var dst = list<XedFieldDef>();
        //     var result = Outcome.Success;
        //     var line = EmptyString;
        //     var lines = src.ReadLines().Reader();
        //     while(lines.Next(out line))
        //     {
        //         var content = line.Trim();
        //         if(text.empty(content) || text.begins(content,Chars.Hash))
        //             continue;

        //         var cells = text.split(text.despace(content), Chars.Space).Reader();
        //         var record = XedFieldDef.Empty;
        //         record.Name = cells.Next();

        //         cells.Next();
        //         result = FieldTypes.ExprKind(cells.Next(), out XedFieldType ft);
        //         if(result.Fail)
        //             Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.FieldType), cells.Prior()));
        //         else
        //             record.FieldType = ft;

        //         result = DataParser.parse(cells.Next(), out record.Width);
        //         if(result.Fail)
        //             Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.Width), cells.Prior()));

        //         if(!Visibilities.ExprKind(cells.Next(), out record.Visibility))
        //             Errors.Throw(AppMsg.ParseFailure.Format(nameof(record.Visibility), cells.Prior()));

        //         dst.Add(record);
        //     }

        //     return dst.ToArray().Sort();
        // }
    }
}