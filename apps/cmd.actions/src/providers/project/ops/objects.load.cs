//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    using Windows.Image;

    partial class ProjectCmdProvider
    {
        [CmdOp("objects/load")]
        Outcome LoadObjects(CmdArgs args)
        {
            var project = Project();
            var hexSrc = CoffObjects.LoadObjHex(project);
            var hexLu = hexSrc.ToLookup(FileKind.HexDat);
            var objSrc = CoffObjects.LoadObjData(project);
            if(hexSrc.Count != objSrc.Count)
            {
                Error(string.Format("Counts differ"));
                return false;
            }
            var formatter = Tables.formatter<CoffObject>();
            var headerFormatter = Tables.formatter<IMAGE_FILE_HEADER>();
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
                var hexData = hex.Compact();
                var objData = obj.Data;
                var size = (uint)objData.Size;
                var hexSize = (uint)hexData.Size;
                if(size != hexSize)
                {
                    Error(string.Format("{0} size mismatch: {1} != {2}", id, size.FormatHex(), hexSize.FormatHex()));
                    break;
                }

                for(var j=0u; j<size; j++)
                {
                    MemoryAddress curoffset = j;
                    ref readonly var a = ref objData[j];
                    ref readonly var b = ref hexData[j];
                    if(a != b)
                    {
                        Error(string.Format("{0} != {1} at offset {2} for {3}", a.FormatHex(), b.FormatHex(), curoffset, id));
                        break;
                    }
                }

                var offset = 0u;
                ref readonly var header = ref skip(recover<IMAGE_FILE_HEADER>(objData.View), offset);
                offset += size<IMAGE_FILE_HEADER>();

                ref readonly var symcount = ref header.NumberOfSymbols;
                ref readonly var symoffset = ref header.PointerToSymbolTable;

                Write(string.Format("{0,-24} | {1,-8} | {2}", id, symcount,symoffset));

                ref readonly var s0 = ref first(recover<COFF_SYMBOL>(slice(objData.View,(uint)symoffset)));
                for(var j=0; j<symcount; j++)
                {
                    ref readonly var s = ref skip(s0,j);
                    ref readonly var name = ref s.Name;
                    var kind = name.IsAddress ? "Address" : "String";
                    var @class = Symbols.format(s.StorageClass);
                    var symtype = Symbols.format(s.Type);
                    var section = s.SectionNumber;
                    Write(string.Format("{0,-8} | {1,-16} | {2,-8} | {3,-8} | {4,-14} | {5}", section, s.Name, kind, s.Value, symtype, @class));
                }
            }

            return  true;
        }
    }
}