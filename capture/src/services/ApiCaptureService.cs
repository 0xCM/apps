//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Collections.Generic;
    using System.Reflection;

    using Z0.Asm;

    using static core;

    public sealed class ApiCaptureService : AppService<ApiCaptureService>
    {
        ApiMemberExtractor Extractor;

        ApiCaptureEmitter Emitter;

        ApiJit Jitter;

        public ApiCaptureService()
        {
            Extractor = ApiExtracts.extractor();
        }

        protected override void OnInit()
        {
            Emitter = Wf.CaptureEmitter();
            Jitter = Wf.ApiJit();
        }

        public Index<ApiMemberExtract> ExtractHostOps(IApiHost host)
            => Extractor.Extract(Jitter.JitHost(host));

        public Index<ApiMemberExtract> ExtractMembers(ApiHostMembers src)
            => Extractor.Extract(src.Members);

        /// <summary>
        /// Root capture routine that traverses and captures the apiset
        /// </summary>
        public Index<AsmHostRoutines> CaptureParts()
        {
            using var flow = Wf.Running();
            ClearArchive();
            var captured = RunCapture();
            Wf.Ran(flow);
            return captured;
        }


        public Index<AsmHostRoutines> CaptureParts(Index<PartId> parts)
        {
            using var flow = Wf.Running();
            ClearArchive(parts);
            var captured = RunCapture(parts);
            Wf.Ran(flow);
            return captured;
        }

        public AsmHostRoutines CaptureHost(ApiHostUri host, ApiMembers members, FS.FolderPath dst)
        {
            using var flow = Wf.Running();
            var extracted = Extractor.Extract(members);
            var count = extracted.Length;
            var routines = Emitter.Emit(host, extracted, dst);
            Wf.Ran(flow);
            return routines;
        }

        public ReadOnlySpan<ApiHostMembers> HostGroups(in ApiMembers src)
        {
            var dst = list<ApiHostMembers>();
            var groups = src.Storage.GroupBy(x => x.Host);
            foreach(var g in groups)
            {
                var host = g.Key;
                var members = g.ToArray();
                dst.Add(new ApiHostMembers(host, ApiMembers.create(members)));
            }
            return dst.ViewDeposited();
        }

        // public AsmMemberRoutine CaptureMember(MethodInfo src, Span<byte> buffer)
        // {
        //     var block = ApiExtracts.extract(src,buffer);

        // }

        public ReadOnlySpan<AsmHostRoutines> CaptureMembers(ApiMembers src, FS.FolderPath dst)
        {
            var hosted = HostGroups(src);
            var count = hosted.Length;
            var collected = list<AsmHostRoutines>();
            for(var i=0; i<count; i++)
                CaptureMembers(skip(hosted,i), dst, collected);
            return collected.ViewDeposited();
        }

        public void CaptureMembers(ApiHostMembers src, FS.FolderPath path, List<AsmHostRoutines> dst)
        {
            var routines = AsmHostRoutines.Empty;
            var flow = Wf.Running(src.Host);
            try
            {
                routines = Emitter.Emit(src.Host, ExtractMembers(src), path);
                dst.Add(routines);
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
            Wf.Ran(flow, src.Host);
        }

        public ReadOnlySpan<AsmHostRoutines> CaptureCatalog(IApiCatalog catalog)
        {
            var dst = list<AsmHostRoutines>();
            using var flow = Wf.Running();
            var catalogs = catalog.Catalogs.View;
            var count = catalogs.Length;
            for(var i=0; i<count; i++)
                dst.AddRange(CaptureCatalog(skip(catalogs,i)));
            Wf.Ran(flow, count);
            return dst.ViewDeposited();
        }

        /// <summary>
        /// Captures a catalog-specified part
        /// </summary>
        /// <param name="src">The part catalog</param>
        public Index<AsmHostRoutines> CaptureCatalog(IApiPartCatalog src)
        {
            if(src.IsEmpty)
                return array<AsmHostRoutines>();

            var dst = list<AsmHostRoutines>();
            dst.Add(CaptureTypes(src.ApiTypes));
            dst.AddRange(CaptureHosts(src.OperationHosts));
            return dst.ToArray();
        }

        public Index<AsmHostRoutines> CaptureHosts(ReadOnlySpan<ApiHostUri> src)
        {
            var dst = list<AsmHostRoutines>();
            try
            {
                var hosts = Wf.ApiCatalog.FindHosts(src);
                var count = hosts.Length;
                var view = hosts.View;
                for(var i=0; i<count; i++)
                {
                    var host = skip(view,i);
                    dst.Add(CaptureHost(host));
                }
            }
            catch(IOException e)
            {
                Wf.Error(string.Format("IOException: {0}", e.Message));
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }

            return dst.ToArray();
        }

        public Index<AsmHostRoutines> CaptureHosts(ReadOnlySpan<IApiHost> src)
        {
            var count = src.Length;
            var collected = list<AsmHostRoutines>();
            for(var i=0; i<count; i++)
                collected.Add(CaptureHost(skip(src, i)));
            return collected.ToArray();
        }

        public Index<AsmHostRoutines> CaptureHosts(ReadOnlySpan<IApiHost> src, FS.FolderPath dst)
        {
            var count = src.Length;
            var collected = list<AsmHostRoutines>();
            for(var i=0; i<count; i++)
                collected.Add(CaptureHost(skip(src, i), dst));
            return collected.ToArray();
        }

        public AsmHostRoutines CaptureHost(IApiHost src)
        {
            src = require(src);
            var routines = AsmHostRoutines.Empty;
            var flow = Wf.Running(string.Format("Capturing {0} routines", src.HostName));
            try
            {
                routines = Emitter.Emit(src.HostUri, ExtractHostOps(src));
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
            Wf.Ran(flow, string.Format("Captured {0} {1} routines",routines.Count, src.HostName));
            return routines;
        }

        public AsmHostRoutines CaptureHost(IApiHost src, FS.FolderPath dst)
        {
            src = require(src);
            var routines = AsmHostRoutines.Empty;
            var flow = Wf.Running(string.Format("Capturing {0} routines", src.HostName));
            try
            {
                routines = Emitter.Emit(src.HostUri, ExtractHostOps(src), dst);
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
            Wf.Ran(flow, string.Format("Captured {0} {1} routines",routines.Count, src.HostName));
            return routines;
        }

        public AsmHostRoutines CaptureTypes(Index<ApiCompleteType> src)
        {
            var dst = list<AsmMemberRoutine>();
            var extracted = @readonly(ExtractTypes(src).GroupBy(x => x.Host).Select(x => kvp(x.Key, x.Array())).Array());
            var count = extracted.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var extracts = ref skip(extracted,i);
                dst.AddRange(Emitter.Emit(extracts.Key, extracts.Value));
            }
            return dst.ToArray();
        }

        Index<ApiMemberExtract> ExtractTypes(Index<ApiCompleteType> types)
        {
            try
            {
                return Extractor.Extract(Jitter.Jit(types));
            }
            catch(Exception e)
            {
                Wf.Error(e);
                return sys.empty<ApiMemberExtract>();
            }
        }

        Index<AsmHostRoutines> RunCapture()
        {
            var dst = list<AsmHostRoutines>();
            using var flow = Wf.Running();
            var catalogs = Wf.ApiCatalog.Catalogs.View;
            var count = catalogs.Length;
            for(var i=0; i<count; i++)
                dst.AddRange(CaptureCatalog(skip(catalogs,i)));
            Wf.Ran(flow, count);
            return dst.ToArray();
        }

        Index<AsmHostRoutines> RunCapture(Index<PartId> parts)
        {
            var dst = list<AsmHostRoutines>();
            using var flow = Wf.Running();
            var catalogs = Wf.ApiCatalog.PartCatalogs(parts).View;
            var count = catalogs.Length;
            for(var i=0; i<count; i++)
                dst.AddRange(CaptureCatalog(skip(catalogs,i)));
            Wf.Ran(flow, count);
            return dst.ToArray();
        }

        void ClearArchive()
        {
            Wf.ApiCaptureArchive().Clear();
        }

        void ClearArchive(Index<PartId> parts)
        {
            Wf.ApiCaptureArchive().Clear(parts);
        }
    }
}