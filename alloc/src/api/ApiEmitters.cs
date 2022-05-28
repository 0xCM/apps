//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiEmitters : AppService<ApiEmitters>
    {
        Heaps Heaps => Wf.Heaps();

        ApiMd ApiMd => Wf.ApiMetadata();

        AppSvcOps AppSvc
            => Service(Wf.AppSvc);

        AppDb AppDb
            => Service(Wf.AppDb);

        static uint FieldCount(Index<Type> tables)
        {
            var counter = 0u;
            for(var i=0; i<tables.Count; i++)
                counter += tables[i].DeclaredInstanceFields().Ignore().Index().Count;
            return counter;
        }

        public Index<Type> CalcRecordTypes()
            => Data(nameof(CalcRecordTypes), () => ApiRuntimeCatalog.Components.Storage.Types().Tagged<RecordAttribute>().Index());

        public Index<TableField> CalcTableFields()
        {
            return Data(nameof(TableField), Calc);

            Index<TableField> Calc()
            {
                var tables = CalcRecordTypes();
                var count = FieldCount(tables);
                var buffer = alloc<TableField>(count);
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
        }

        public void Emit()
        {
            ApiEmit(Heaps.CalcSymLits());
        }

        DbTargets ApiTargets()
            => AppDb.Targets("api");

        public Index<SymKindRow> EmitKinds<K>(Symbols<K> src, FS.FilePath dst)
            where K : unmanaged
        {
            var result = Outcome.Success;
            var kinds = src.Kinds;
            var count = kinds.Length;
            var buffer = alloc<SymKindRow>(count);
            Heaps.symkinds(src, buffer);
            AppSvc.TableEmit(buffer, dst);
            return buffer;
        }

        public Index<SymInfo> EmitTokens(Type src)
        {
            var tokens = Symbols.syminfo(src);
            WfEmit.TableEmit(tokens, ApiTargets().Table<SymInfo>("tokens" + "." +  src.Name.ToLower()));
            return tokens;
        }

        void ApiEmit(Index<SymLiteralRow> symlits)
            => core.exec(true,
                EmitDataFlows,
                EmitTypeLists,
                EmitCompilationLits,
                EmitDataTypes,
                EmitComments,
                EmitParsers,
                EmitApiTables,
                EmitApiCommands,
                EmitApiBitMasks,
                () => EmitSymHeap(symlits),
                () => EmitSymLits(symlits)
            );

        void EmitApiCommands()
            => ApiMd.Emit(ApiMd.ApiCommands);

        void EmitCompilationLits()
            => ApiMd.Emit(ApiMd.ApiLiterals);

        void EmitComments()
            => ApiMd.EmitComments();

        void EmitApiBitMasks()
            => ApiMd.Emit(ApiMd.ApiBitMasks);

        void EmitTypeLists()
        {
            ApiMd.EmitTypeList("api.types.enums", ApiMd.EnumTypes);
            ApiMd.EmitTypeList("api.types.records", CalcRecordTypes());
        }

        void EmitDataFlows()
            => ApiMd.Emit(ApiMd.DataFlows);

        void EmitDataTypes()
            => ApiMd.Emit(ApiMd.DataTypes);

        void EmitSymLits(Index<SymLiteralRow> src)
            => ApiMd.Emit(src);

        void EmitSymHeap(Index<SymLiteralRow> src)
            => Heaps.Emit(Heaps.symbols(src));

        void EmitApiTables()
            => ApiMd.Emit(CalcTableFields());

        void EmitParsers()
        {
            var parsers = Parsers.discover(ApiRuntimeCatalog.Components);
            var targets = parsers.Keys;
            var dst = text.emitter();
            iter(targets, target => dst.AppendLineFormat("parse:string -> {0}", target.DisplayName()));
            AppSvc.FileEmit(dst.Emit(), targets.Count, AppDb.ApiTargets().Path("parsers", FileKind.List));
        }
    }
}