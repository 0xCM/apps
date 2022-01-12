//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("objects/headers")]
        Outcome ObjectHeaders(CmdArgs args)
        {
            var project = Project();
            var src = CoffServices.LoadObjData(project);
            var entries = src.Entries;
            var count = entries.Count;
            var records = list<ImageSectionInfo>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref entries[i];
                ref readonly var path = ref entry.Left;
                ref readonly var obj = ref entry.Right;
                var view = CoffObjectView.cover(obj.Data);
                ref readonly var header = ref view.Header;
                var strings = view.StringTable;
                var srcId = path.SrcId(FileKind.Obj, FileKind.O);
                var sections = view.SectionHeaders;
                for(var j=0u; j<sections.Length; j++)
                {
                    ref readonly var section = ref skip(sections,j);
                    var number = j+1 ;
                    var name = CoffObjects.format(strings, section.Name);
                    var record = default(ImageSectionInfo);
                    record.Seq = seq++;
                    record.SrcId = srcId;
                    record.SectionNumber = number;
                    record.SectionName = name;
                    record.RawDataAddress = section.PointerToRawData;
                    record.RawDataSize = section.SizeOfRawData;
                    record.RelocAddress = section.PointerToRelocations;
                    record.RelocCount = section.NumberOfRelocations;
                    record.Flags = section.Characteristics;
                    records.Add(record);

                    // Write(string.Format("{0,-36} | {1,-8} | {2,-12} | {3,-10} | {4,-8} | {5,-10} | {6,-8} | {7}",
                    //     srcId,
                    //     number,
                    //     name,
                    //     section.PointerToRawData,
                    //     section.SizeOfRawData,
                    //     section.PointerToRelocations,
                    //     section.NumberOfRelocations,
                    //     section.Characteristics != 0 ? section.Characteristics.ToString() : EmptyString)
                    //     );
                }
            }


            var dst = ProjectDb.ProjectTable<ImageSectionInfo>(project);
            TableEmit(records.ViewDeposited(), ImageSectionInfo.RenderWidths, dst);
            return true;
        }
    }
}