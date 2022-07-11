//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static CliRows;

    partial class CliEmitter
    {
        public void EmitFieldDefs(ReadOnlySpan<Assembly> src, IApiPack dst)
        {
            var counter = 0u;
            var path = dst.Metadata("fields.defs").Table<FieldDefInfo>();
            var flow = EmittingTable<FieldDefInfo>(path);
            iter(src, a => EmitFieldDefs(a,dst), true);

            //using var writer = path.Writer();
            //var formatter = Tables.formatter<FieldDefInfo>(FieldDefInfo.RenderWidths);

            //for(var i=0; i<src.Length; i++)
            //{
                //ref readonly var a = ref skip(src,i);
                // var assname = a.GetSimpleName();
                // var reader = CliReader.create(a);
                // var handles = reader.FieldDefHandles();
                // var count = handles.Length;
                // for(var j=0; j<count; j++)
                // {
                //     var row = new FieldDefRow();
                //     var info = new FieldDefInfo();
                //     ref readonly var handle = ref skip(handles,j);
                //     reader.Row(handle, ref row);
                //     info.Token = Clr.token(handle);
                //     info.Component = assname;
                //     info.Attributes = row.Attributes;
                //     info.CliSig = reader.Read(row.Signature);
                //     info.Name = reader.Read(row.Name);
                //     writer.WriteLine(formatter.Format(info));
                //     counter++;
                // }
            //}
            //EmittedTable(flow, counter);
        }

        public void EmitFieldDefs(Assembly src, IApiPack dst)
        {
            var name = src.GetSimpleName();
            var path = dst.Metadata("fields.defs").PrefixedTable<FieldDefInfo>(name);
            var flow = EmittingTable<FieldDefInfo>(path);
            var reader = CliReader.create(src);
            var handles = reader.FieldDefHandles();
            var count = handles.Length;
            using var writer = path.Writer();
            var formatter = Tables.formatter<FieldDefInfo>();
            writer.WriteLine(formatter.FormatHeader());
            for(var j=0; j<count; j++)
            {
                var row = new FieldDefRow();
                var info = new FieldDefInfo();
                ref readonly var handle = ref skip(handles,j);
                reader.Row(handle, ref row);
                info.Token = Clr.token(handle);
                info.Component = name;
                info.Attributes = row.Attributes;
                info.CliSig = reader.Read(row.Signature);
                info.Name = reader.Read(row.Name);
                writer.WriteLine(formatter.Format(info));
            }
            EmittedTable(flow, count);
        }
    }
}