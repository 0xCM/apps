//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;

    using Z0.Asm;

    using static core;

    public sealed class ApiCaptureService : WfSvc<ApiCaptureService>
    {
        new ApiCaptureEmitter Emitter => Service(Wf.CaptureEmitter);

        ApiMemberExtractor Extractor => Service(ApiMemberExtractor.create);

        public Index<ApiMemberExtract> ExtractHostOps(IApiHost host)
            => Extractor.Extract(ClrJit.members(host, EventLog));

        /// <summary>
        /// Captures a catalog-specified part
        /// </summary>
        /// <param name="src">The part catalog</param>
        public Index<AsmHostRoutines> CaptureCatalog(IApiPartCatalog src, IApiPack dst)
        {
            if(src.IsEmpty)
                return array<AsmHostRoutines>();

            var buffer = list<AsmHostRoutines>();
            buffer.Add(CaptureTypes(src.ApiTypes, dst));
            buffer.AddRange(CaptureHosts(src.OperationHosts, dst));
            return buffer.ToArray();
        }

        public Index<AsmHostRoutines> CaptureHosts(ReadOnlySpan<IApiHost> src, IApiPack dst)
        {
            var count = src.Length;
            var collected = list<AsmHostRoutines>();
            for(var i=0; i<count; i++)
                collected.Add(CaptureHost(skip(src, i), dst));
            return collected.ToArray();
        }

        public AsmHostRoutines CaptureHost(IApiHost src, IApiPack dst)
        {
            src = require(src);
            var routines = AsmHostRoutines.Empty;
            var flow = Running(string.Format("Capturing {0} routines", src.HostName));
            try
            {
                routines = Emitter.Emit(src.HostUri, ExtractHostOps(src), dst);
            }
            catch(Exception e)
            {
                Error(e);
            }
            Ran(flow, string.Format("Captured {0} {1} routines", routines.Count, src.HostName));
            return routines;
        }

        public AsmHostRoutines CaptureTypes(Index<ApiCompleteType> src, IApiPack dst)
        {
            var buffer = list<AsmMemberRoutine>();
            var extracted = @readonly(ExtractTypes(src).GroupBy(x => x.Host).Select(x => kvp(x.Key, x.Array())).Array());
            var count = extracted.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var extracts = ref skip(extracted,i);
                buffer.AddRange(Emitter.Emit(extracts.Key, extracts.Value, dst));
            }
            return buffer.ToArray();
        }

        Index<ApiMemberExtract> ExtractTypes(Index<ApiCompleteType> types)
        {
            try
            {
                return Extractor.Extract(ClrJit.jit(types, EventLog));
            }
            catch(Exception e)
            {
                Wf.Error(e);
                return sys.empty<ApiMemberExtract>();
            }
        }

        Index<AsmHostRoutines> RunCapture(IApiPack dst)
        {
            var buffer = list<AsmHostRoutines>();
            using var flow = Wf.Running(nameof(RunCapture));
            var catalogs = Wf.ApiCatalog.Catalogs.View;
            var count = catalogs.Length;
            for(var i=0; i<count; i++)
                buffer.AddRange(CaptureCatalog(skip(catalogs,i),dst));
            Ran(flow, count);
            return buffer.ToArray();
        }

        Index<AsmHostRoutines> RunCapture(Index<PartId> parts, IApiPack dst)
        {
            var buffer = list<AsmHostRoutines>();
            using var flow = Running();
            var catalogs = Wf.ApiCatalog.PartCatalogs(parts).View;
            var count = catalogs.Length;
            for(var i=0; i<count; i++)
                buffer.AddRange(CaptureCatalog(skip(catalogs,i),dst));
            Ran(flow);
            return buffer.ToArray();
        }
    }
}