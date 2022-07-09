//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CliEmitter
    {
        public void EmitFieldMetadata(IApiPack dst)
        {
            var count = 0u;
            var parts = ApiMd.Components;
            var flow = Running(parts.Length);

            foreach(var part in parts)
            {
                try
                {
                    count += EmitFieldMetadata(part, dst);
                }
                catch(Exception e)
                {
                    Error(e);
                }
            }

            Ran(flow, count);
        }

        public uint EmitFieldMetadata(Assembly src, IApiPack dst)
        {
            var path = dst.Metadata("fields.members").Table<MemberFieldInfo>();
            var flow = EmittingTable<MemberFieldInfo>(path);
            var reader = CliReader.create(src);
            var fields = reader.ReadFieldInfo();
            var count = (uint)fields.Length;
            var formatter = Tables.formatter<MemberFieldInfo>();
            using var writer = path.Writer();
            writer.WriteLine(formatter.FormatHeader());
            foreach(var item in fields)
                writer.WriteLine(formatter.Format(item));
            EmittedTable(flow, count);
            return count;
        }
    }
}