//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public sealed class LlvmRecordLoader : AppService<LlvmRecordLoader>
    {
        LlvmPaths LlvmPaths;

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
        }

        public ItemList LoadList(string id)
        {
            var path = LlvmPaths.ListImportPath(id);
            var result = Tables.list(path, out var items);
            if(result.Fail)
            {
                Error(result.Message);
                return ItemList.Empty;
            }
            return items;
        }

        public Outcome LoadFields(string dsid, out Index<RecordField> dst)
            => LoadFields(LlvmPaths.Table(dsid), out dst);

        public Outcome LoadFields(FS.FilePath src, out Index<RecordField> dst)
        {
            var count = FS.linecount(src);
            var result = Outcome.Success;
            dst = alloc<RecordField>(count.Lines);
            var counter = 0u;
            using var reader = src.Utf8LineReader();
            var id = Identifier.Empty;
            var i = 0u;
            var j = 0u;
            while(reader.Next(out var line))
            {
                result = parse(line, out var field);
                if(result.Fail)
                    break;
                dst[counter++] = field;
            }
            return result;
        }

        static Outcome parse(in TextLine src, out RecordField dst)
        {
            var result = Outcome.Success;
            dst = default;
            var parts = src.Split(Z0.Chars.Pipe).Map(x => x.Trim());
            var count = parts.Length;
            if(count < 4)
                return (false, Tables.FieldCountMismatch.Format(4, count));

            dst.RecordName = skip(parts,0);
            dst.DataType = skip(parts,1);
            dst.Name = skip(parts,2);
            dst.Value = skip(parts,3);
            return result;
        }
    }
}