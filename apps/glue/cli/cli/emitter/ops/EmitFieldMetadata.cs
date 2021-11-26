//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class CliEmitter
    {
        public void EmitFieldMetadata()
        {
            var count = 0u;
            var parts = Wf.ApiParts.Components;
            var flow = Wf.Running(parts.Length);

            foreach(var part in parts)
            {
                try
                {
                    count += EmitFieldMetadata(part);
                }
                catch(Exception e)
                {
                    Wf.Error(e);
                }
            }

            Wf.Ran(flow, count);
        }

        public FS.FilePath FieldMetadataPath(Assembly src)
            => Db.Table(MemberFieldInfo.TableId, src.Id());

        public uint EmitFieldMetadata(Assembly src)
        {
            var dst = FieldMetadataPath(src);
            var flow = Wf.EmittingTable<MemberFieldInfo>(dst);
            var reader = CliReader.read(src);
            var fields = reader.ReadFieldInfo();
            var count = (uint)fields.Length;
            var formatter = Tables.formatter<MemberFieldInfo>(MemberFieldInfo.RenderWidths);
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            foreach(var item in fields)
                writer.WriteLine(formatter.Format(item));
            Wf.EmittedTable(flow, count);
            return count;
        }
    }
}