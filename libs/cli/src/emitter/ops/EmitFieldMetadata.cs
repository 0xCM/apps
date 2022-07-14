//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;
    using static Refs;

    partial class CliEmitter
    {
        public void EmitFieldMetadata(IApiPack dst)
        {
            var count = 0u;
            var flow = Running(ApiMd.Components.Length);
            iter(ApiMd.Components, part => EmitFieldMetadata(part,dst), true);
            Ran(flow, count);
        }

        void EmitFieldMetadata(Assembly src, IApiPack dst)
        {
            iter(ApiMd.Components, part =>
                {
                    EmitMemberFields(part,dst);
                    EmitFieldDefs(part,dst);

                }, true);

        }
        void EmitMemberFields(Assembly src, IApiPack dst)
        {
            try
            {
                var path = dst.Metadata(CliMemberField.TableId).PrefixedTable<CliMemberField>(src.GetSimpleName());
                if(path.Exists)
                    Errors.ThrowWithOrigin(AppMsg.FileExists.Format(path));

                var flow = EmittingTable<CliMemberField>(path);
                var reader = CliReader.create(src);
                var fields = reader.ReadFieldInfo();
                var count = (uint)fields.Length;
                var formatter = Tables.formatter<CliMemberField>();
                using var writer = path.Writer();
                writer.WriteLine(formatter.FormatHeader());
                foreach(var item in fields)
                    writer.WriteLine(formatter.Format(item));
                EmittedTable(flow, count);
            }
            catch(Exception e)
            {
                Error(e.Message);
            }
        }

        void EmitFieldDefs(Assembly src, IApiPack dst)
        {
            try
            {
                var name = src.GetSimpleName();
                var path = dst.Metadata(FieldDefInfo.TableId).PrefixedTable<FieldDefInfo>(name);
                if(path.Exists)
                    Errors.ThrowWithOrigin(AppMsg.FileExists.Format(path));

                var flow = EmittingTable<FieldDefInfo>(path);
                var reader = CliReader.create(src);
                var handles = reader.FieldDefHandles();
                var count = handles.Length;
                using var writer = path.Writer();
                var formatter = Tables.formatter<FieldDefInfo>();
                writer.WriteLine(formatter.FormatHeader());
                for(var j=0; j<count; j++)
                {
                    var row = new CliFieldDef();
                    var info = new FieldDefInfo();
                    ref readonly var handle = ref skip(handles,j);
                    reader.Row(handle, ref row);
                    info.Token = Clr.token(handle);
                    info.Component = name;
                    info.Attributes = row.Attributes;
                    info.CliSig = reader.Read(row.Sig);
                    info.Name = reader.Read(row.Name);
                    writer.WriteLine(formatter.Format(info));
                }
                EmittedTable(flow, count);
            }
            catch(Exception e)
            {
                Error(e);
            }
        }

    }
}