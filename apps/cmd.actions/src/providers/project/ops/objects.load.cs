//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    using System;
    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("objects/load")]
        Outcome LoadObjects(CmdArgs args)
        {
            var project = Project();
            var hexSrc = CoffServices.LoadObjHex(project);
            var hexLu = hexSrc.ToLookup(FileKind.HexDat);
            var objSrc = CoffServices.LoadObjData(project);
            var tsBase = new DateTime(1970,1,1);
            if(hexSrc.Count != objSrc.Count)
            {
                Error(string.Format("Counts differ"));
                return false;
            }

            var keys = objSrc.Paths.Array();
            var count = keys.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var key = ref skip(keys,i);
                var obj = objSrc[key];
                ref readonly var id = ref obj.SrcId;
                if(!hexLu.ContainsKey(id))
                {
                    Warn("No hex data found for {0}", id);
                    continue;
                }

                var hex = hexLu[id];
                var valid = CoffHex.validate(obj, hex);
                if(valid.Fail)
                {
                    Error(valid.Message);
                    break;
                }

                var objData = obj.Data.View;
                var offset = 0u;
                var view = CoffObjectView.cover(obj.Data, offset);


                ref readonly var symcount = ref view.SymCount;
                if(symcount == 0)
                    break;

                //Write(string.Format("{0,-24} | {1,-8} | {2}", id, symcount, view.SymTableOffset));

                var syms = view.Symbols;
                var strings = view.StringTable;
                for(var j=0; j<symcount; j++)
                {
                    ref readonly var sym = ref skip(syms,j);
                    var symtext = strings.Text(sym);
                    if(nonempty(symtext))
                    {
                        Write(string.Format("{0,-24} | {1} | {2,-8} | {3,-12} | {4,-8} | {5,-8} | {6,-10} | {7}",
                            id,
                            view.Timestamp.ToLexicalString(TimeResolution.Second),
                            sym.SectionNumber,
                            sym.Value,
                            sym.Type,
                            sym.StorageClass,
                            sym.Name.NameKind == CoffNameKind.String ? Address32.Zero.Format() : sym.Name.Address.Format(),
                            strings.Text(sym)
                            ));
                    }
                }
            }

            return  true;
        }
    }
}