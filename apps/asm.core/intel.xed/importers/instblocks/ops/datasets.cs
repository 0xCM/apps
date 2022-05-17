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
            // static BlockImportDatasets datasets(LineMap<FormFields> map, ReadOnlySpan<string> src)
            // {
            //     var dst = CalcDatasets(map,src);
            //     return data(nameof(BlockImportDatasets), () => dst);
            // }

            // static BlockImportDatasets CalcDatasets(LineMap<FormFields> map, ReadOnlySpan<string> src)
            // {
            //     var dst = new BlockImportDatasets();
            //     var emitter = text.emitter();
            //     var k=0u;
            //     for(var i=0u; i<map.IntervalCount; i++)
            //     {
            //         ref readonly var range = ref map[i];
            //         dst.Received.TryAdd(range.Id.Form, range);
            //         var spec = range.Id;
            //         var form = spec.Form;
            //         var import = InstBlockImport.Empty;
            //         var name = EmptyString;
            //         var value = EmptyString;
            //         var bf = BlockField.amd_3dnow_opcode;
            //         import.Form = form;
            //         import.Seq = i;
            //         for(var m =0; m<range.LineCount; m++)
            //         {
            //             ref readonly var line = ref skip(src,k++);
            //             emitter.AppendLine(line);

            //             split(line, out name, out value);
            //             XedParsers.parse(name, out bf);

            //             if(bf == BlockField.iclass)
            //                 XedParsers.parse(value, out import.Class);
            //             else if(bf == BlockField.pattern)
            //             {
            //                 split(line, out _, out value);
            //                 try
            //                 {
            //                     InstParser.parse(value, out import.Pattern);
            //                 }
            //                 catch(Exception e)
            //                 {
            //                     term.warn(e.Message);
            //                 }
            //             }
            //         }
            //         dst.Imports.Add(import);
            //         dst.Data.TryAdd(form, emitter.Emit());
            //     }

            //     return dst;
            // }
        }
    }
}