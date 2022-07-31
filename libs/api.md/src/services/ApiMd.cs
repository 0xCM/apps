//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = ApiMdKind;

    public sealed partial class ApiMd : WfSvc<ApiMd>
    {
        IDbTargets ApiTargets()
            => AppDb.ApiTargets();

        public IDbTargets ApiTargets(string scope)
            => AppDb.ApiTargets(scope);

        IDbTargets AssetTargets
            => AppDb.ApiTargets("assets");

        public IApiCatalog Catalog
            => ApiRuntimeCatalog;

        public Assembly[] Assemblies
            => DbArchives.assemblies();

        public Type[] EnumTypes
            => data(K.EnumTypes, () => Assemblies
                .Enums()
                .Where(x => x.ContainsGenericParameters == false));

        public Index<Type> ApiTableTypes
            => data(K.ApiTables, () => Assemblies.Types().Tagged<RecordAttribute>().Index());

        public ReadOnlySeq<SymLiteralRow> SymLits
            => data(nameof(SymLiteralRow), () => Symbolic.symlits(Assemblies));

        public Index<IApiHost> ApiHosts
            => data(K.ApiHosts, () => Catalog.ApiHosts.Index());

        public ReadOnlySeq<ComponentAssets> ComponentAssets
            => data(K.ApiAssets, () => CalcAssets());

        public ApiParserLookup Parsers
            => data(K.Parsers, () => Z0.Parsers.contracted(Assemblies));

        public new ApiMdEmitter Emitter()
            => ApiMdEmitter.create(Wf, this, ApiPacks.create());

        public new ApiMdEmitter Emitter(IApiPack dst)
            => ApiMdEmitter.create(Wf, this, dst);

        public void EmitDatasets(IApiPack dst)
            => Emitter(dst).Emit();

        public Index<SymLiteralRow> LoadSymLits(FS.FilePath src)
        {
            using var reader = src.TableReader<SymLiteralRow>(SymLiteralRow.parse);
            var header = reader.Header.Split(Chars.Tab);
            if(header.Length != SymLiteralRow.FieldCount)
            {
                Error(AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, header.Length));
                return Index<SymLiteralRow>.Empty;
            }

            var dst = list<SymLiteralRow>();
            while(!reader.Complete)
            {
                var outcome = reader.ReadRow(out var row);
                if(!outcome)
                {
                    Error(outcome.Message);
                    break;
                }
                dst.Add(row);
            }

            return dst.ToArray();
        }

        void EmitApiTokens(Name name, ReadOnlySeq<SymInfo> src)
            => TableEmit(src, ApiTargets(tokens).PrefixedTable<SymInfo>(name), TextEncodingKind.Unicode);

        internal Index<ComponentAssets> CalcAssets()
            => Assets.extract(Assemblies);

        internal void EmitAssets()
        {
            AssetTargets.Delete();
            EmitAssetEntries(EmitAssets(ComponentAssets));
        }

        internal ReadOnlySeq<AssetCatalogEntry> EmitAssets(ReadOnlySeq<ComponentAssets> src)
        {
            var counter = 0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var assets = ref src[i];
                var count = assets.Count;
                var targets = AssetTargets.Targets(assets.Source.GetSimpleName());
                for(var j=0; j<count; j++)
                {
                    ref readonly var asset = ref assets[j];
                    FileEmit(Assets.utf8(asset), targets.Path(asset.Name.ShortFileName), TextEncodingKind.Utf8);
                    counter++;
                }
            }

            return src.SelectMany(x => x).Select(e => Assets.entry(e));
        }

        internal void EmitAssetEntries(ReadOnlySeq<AssetCatalogEntry> src)
            => TableEmit(src, AppDb.ApiTargets().Table<AssetCatalogEntry>());

        public Index<SymInfo> LoadTokens(string name)
        {
            var src = ApiTargets().PrefixedTable<SymInfo>(tokens + "." +  name.ToLower());
            using var reader = src.TableReader<SymInfo>(SymInfo.parse);
            var header = reader.Header.Split(Chars.Pipe);
            if(header.Length != SymInfo.FieldCount)
            {
                Error(AppMsg.FieldCountMismatch.Format(SymInfo.FieldCount, header.Length));
                return Index<SymInfo>.Empty;
            }
            var dst = list<SymInfo>();
            while(!reader.Complete)
            {
                var outcome = reader.ReadRow(out var row);
                if(!outcome)
                {
                    Error(outcome.Message);
                    break;
                }
                dst.Add(row);
            }

            return dst.ToArray();
        }

        internal void EmitEnums(ReadOnlySpan<ClrEnumRecord> src, FS.FilePath dst)
            => TableEmit(src,dst);

        // internal ReadOnlySeq<SymLiteralRow> EmitSymLits()
        //     => EmitSymLits(ApiTargets().Table<SymLiteralRow>());

        // internal ReadOnlySeq<SymLiteralRow> EmitSymLits<E>()
        //     where E : unmanaged, Enum
        //         => EmitSymLits<E>(ApiTargets().PrefixedTable<SymLiteralRow>(typeof(E).FullName));

        // internal ReadOnlySeq<SymLiteralRow> EmitSymLits(FS.FilePath dst)
        //     => EmitSymLits(Assemblies, dst);

        // internal ReadOnlySeq<SymLiteralRow> EmitSymLits<E>(FS.FilePath dst)
        //     where E : unmanaged, Enum
        // {
        //     var flow = EmittingTable<SymLiteralRow>(dst);
        //     var rows = Symbolic.symlits<E>();
        //     var count = rows.Length;
        //     var formatter = Tables.formatter<SymLiteralRow>();
        //     using var writer = dst.Writer(TextEncodingKind.Unicode);
        //     writer.WriteLine(formatter.FormatHeader());
        //     for(var i=0; i<count; i++)
        //         writer.WriteLine(formatter.Format(rows[i]));
        //     EmittedTable<SymLiteralRow>(flow, count);
        //     return rows;
        // }

        // internal void Emit(ReadOnlySpan<SymKindRow> src)
        //     => TableEmit(src, AppDb.ApiTargets().Table<SymKindRow>());

        // internal ReadOnlySeq<SymLiteralRow> EmitSymLits(Assembly[] src, FS.FilePath dst)
        // {
        //     var data = Symbolic.symlits(src);
        //     TableEmit(data, dst, TextEncodingKind.Unicode);
        //     return data;
        // }

        // internal ReadOnlySeq<SymDetailRow> EmitSymDetails<E>(Symbols<E> src, FS.FilePath dst)
        //     where E : unmanaged, Enum
        // {
        //     var count = src.Count;
        //     var buffer = alloc<SymDetailRow>(count);
        //     for(var i=0; i<count; i++)
        //         Symbols.detail(src[i], (ushort)count, out seek(buffer,i));
        //     TableEmit(buffer,dst);
        //     return buffer;
        // }

        internal static uint CountFields(Index<Type> tables)
        {
            var counter = 0u;
            for(var i=0; i<tables.Count; i++)
                counter += tables[i].DeclaredInstanceFields().Ignore().Index().Count;
            return counter;
        }

        ReadOnlySeq<ApiTableField> CalcTableFields()
        {
            var tables = ApiTableTypes;
            var count = CountFields(tables);
            var buffer = alloc<ApiTableField>(count);
            var k=0u;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var type = ref tables[i];
                var fields = Tables.fields(type);
                var total = 0u;
                var id = TableId.identify(type).Format();
                var typename = type.DisplayName();
                for(var j=z16; j<fields.Length; j++, k++)
                {
                    ref readonly var src = ref skip(fields,j);
                    ref readonly var field = ref src.Definition;
                    ref var dst = ref seek(buffer,k);
                    var size = (ushort)(Sizes.bits(field.FieldType)/8);
                    total += size;
                    dst.Seq = j;
                    dst.TableId = id;
                    dst.TableType = typename;
                    dst.Col = j;
                    dst.FieldSize = size;
                    dst.TableSize = total;
                    dst.RenderWidth = src.FieldWidth;
                    dst.FieldName = field.Name;
                    dst.FieldType = field.FieldType.DisplayName();
                }
            }
            return buffer;
        }

        void Emit(ReadOnlySpan<ApiFlowSpec> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiFlowSpec>());
    }
}