//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiEmitters : AppService<ApiEmitters>
    {
        ApiServices ApiSvc => Service(Wf.ApiServices);

        Heaps Heaps => Wf.Heaps();

        AppSvcOps AppSvc
            => Service(Wf.AppSvc);

        AppDb AppDb
            => Service(Wf.AppDb);

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

        public Index<SymDetailRow> EmitDetails<E>(Symbols<E> src, FS.FilePath dst)
            where E : unmanaged, Enum
        {
            var count = src.Count;
            var buffer = alloc<SymDetailRow>(count);
            for(var i=0; i<count; i++)
                Symbols.detail(src[i], (ushort)count, out seek(buffer,i));
            AppSvc.TableEmit(buffer,dst);
            return buffer;
        }

        public Index<SymInfo> EmitTokens(Type src)
        {
            var tokens = Symbols.syminfo(src);
            WfEmit.TableEmit(tokens, ApiTargets().Table<SymInfo>("tokens" + "." +  src.Name.ToLower()));
            return tokens;
        }

        public Index<SymInfo> LoadTokens(string name)
        {
            var src = ApiTargets().Table<SymInfo>("tokens" + "." +  name.ToLower());
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

        void ApiEmit(Index<SymLiteralRow> symlits)
            => core.exec(true,
                EmitDataTypes,
                EmitDataFlows,
                EmitEnumList,
                EmitCompilationLits,
                EmitComments,
                EmitParsers,
                EmitApiTables,
                EmitApiCommands,
                () => EmitSymHeap(symlits),
                () => EmitSymLits(symlits)
            );

        void EmitApiCommands()
            => ApiSvc.Emit(ApiSvc.CalcApiCommands());

        void EmitCompilationLits()
            => ApiSvc.Emit(ApiSvc.CalcCompilationLits());

        void EmitComments()
            => ApiSvc.EmitComments();

        void EmitEnumList()
            => ApiSvc.EmitTypeList("api.enums.types", ApiSvc.CalcEnumTypes());

        void EmitDataFlows()
            => ApiSvc.Emit(ApiSvc.CalcDataFlows());

        void EmitDataTypes()
            => ApiSvc.Emit(ApiSvc.CalcDataTypes());

        void EmitSymLits(Index<SymLiteralRow> src)
            => ApiSvc.Emit(src);

        void EmitSymHeap(Index<SymLiteralRow> src)
            => Heaps.Emit(Heaps.symbols(src));

        void EmitApiTables()
            => ApiSvc.Emit(ApiSvc.CalcTableDefs());

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