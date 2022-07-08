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
            var parts = ApiRuntimeCatalog.Components;
            var flow = Running(parts.Length);

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
            => ProjectDb.TablePath<MemberFieldInfo>(FieldScope, src.Id().Format());

        public uint EmitFieldMetadata(Assembly src)
        {
            var dst = FieldMetadataPath(src);
            var flow = EmittingTable<MemberFieldInfo>(dst);
            var reader = CliReader.create(src);
            var fields = reader.ReadFieldInfo();
            var count = (uint)fields.Length;
            var formatter = Tables.formatter<MemberFieldInfo>(MemberFieldInfo.RenderWidths);
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            foreach(var item in fields)
                writer.WriteLine(formatter.Format(item));
            EmittedTable(flow, count);
            return count;
        }
    }
}