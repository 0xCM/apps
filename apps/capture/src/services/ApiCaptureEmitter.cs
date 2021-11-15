//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Z0.Asm;

    using static Root;
    using static core;

    public class ApiCaptureEmitter : AppService<ApiCaptureEmitter>
    {
        MsilPipe IlPipe;

        ApiHex ApiHex;

        ApiHostAsmEmitter HostEmitter;

        ApiExtractParser ExtractParser;

        public ApiCaptureEmitter()
        {
            ExtractParser = ApiExtracts.parser();
        }

        protected override void OnInit()
        {
            IlPipe = Wf.MsilPipe();
            ApiHex = Wf.ApiHex();
            HostEmitter = Wf.AsmHostEmitter();
        }

        public AsmHostRoutines Emit(ApiHostUri host, Index<ApiMemberExtract> src)
        {
            var routines = AsmHostRoutines.Empty;
            try
            {
                var flow = Wf.Running(Msg.RunningHostEmissionWorkflow.Format(host,src.Count));
                EmitExtracts(host, src, Db.RawExtractPath(host));
                var parsed = ParseExtracts(host, src);
                if(parsed.Length != 0)
                {
                    EmitApiHex(host, parsed, Db.ParsedExtractPath(host));
                    EmitMsilData(host, parsed, Db.CilPaths.CilDataPath(host));
                    EmitMsilCode(host, parsed, Db.CilPaths.CilCodePath(host));
                    routines = DecodeMembers(host, parsed, src);
                }
                Wf.Ran(flow);
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
            return routines;
        }

        public AsmHostRoutines Emit(ApiHostUri host, Index<ApiMemberExtract> src, FS.FolderPath dst)
        {
            var routines = AsmHostRoutines.Empty;
            try
            {
                var cilpaths = Db.CilPaths;
                var flow = Wf.Running(Msg.RunningHostEmissionWorkflow.Format(host,src.Count));
                var extracts = EmitExtracts(host, src, Db.RawExtractPath(dst, host));
                var parsed = ParseExtracts(host, src);
                if(parsed.Length != 0)
                {
                    EmitApiHex(host, parsed, dst);
                    EmitMsilData(host, parsed, cilpaths.CilDataPath(dst, host));
                    EmitMsilCode(host, parsed, cilpaths.CilCodePath(dst, host));
                    routines = DecodeMembers(host, parsed, src, Db.AsmCapturePath(dst,host));
                }
                Wf.Ran(flow);
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
            return routines;
        }

        public Index<ApiHexRow> EmitApiHex(ApiHostUri host, Index<ApiMemberCode> src, FS.FilePath dst)
            => ApiHex.WriteBlocks(host, src.View, dst);

        public Index<ApiHexRow> EmitApiHex(ApiHostUri host, Index<ApiMemberCode> src, FS.FolderPath dst)
            => ApiHex.WriteBlocks(host, src.View, dst);

        public Count EmitMsilCode(ApiHostUri host, Index<ApiMemberCode> src, FS.FilePath dst)
        {
            if(src.Count != 0)
                IlPipe.EmitCode(src, dst);
            return src.Count;
        }

        public Index<MsilCapture> EmitMsilData(ApiHostUri host, Index<ApiMemberCode> src, FS.FilePath dst)
            => IlPipe.EmitData(src, dst);

        public Index<ApiExtractRow> EmitExtracts(ApiHostUri host, Index<ApiMemberExtract> src, FS.FilePath dst)
        {
            var count = src.Length;
            var blocks = src.Map(x => x.Block);
            var flow = Wf.EmittingTable<ApiExtractRow>(dst);
            var emitted = Emit(blocks, dst);
            Wf.EmittedTable(flow, count);
            return emitted;
        }

        Index<ApiMemberCode> ParseExtracts(ApiHostUri host, Index<ApiMemberExtract> src)
        {
            if(src.Length != 0)
            {
                var flow = Wf.Running();
                var parsed = ExtractParser.ParseMembers(src);
                Wf.Ran(flow, Msg.ParsedExtractBlocks.Format(parsed.Count, host));
                return parsed;
            }
            else
                return Index<ApiMemberCode>.Empty;
        }

        AsmHostRoutines DecodeMembers(ApiHostUri host, Index<ApiMemberCode> src, Index<ApiMemberExtract> extracts)
            => DecodeMembers(host,src,extracts, Wf.Db().AsmCapturePath(host));

        AsmHostRoutines DecodeMembers(ApiHostUri host, Index<ApiMemberCode> src, Index<ApiMemberExtract> extracts, FS.FilePath dst)
        {
            var decoded = HostEmitter.Emit(host, src, dst);
            if(decoded.Count != 0)
                MatchAddresses(extracts, decoded.AsmRoutines);
            return decoded;
       }

        Index<ApiExtractRow> Emit(ReadOnlySpan<ApiExtractBlock> src, FS.FilePath dst)
        {
            var count = src.Length;
            var buffer = alloc<ApiExtractRow>(count);
            var records = span(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var code = ref skip(src,i);
                if(code.IsNonEmpty)
                    row(code, ref seek(records,i));
            }
            Tables.emit(@readonly(records), dst);
            return buffer;
        }

        [MethodImpl(Inline), Op]
        static ref ApiExtractRow row(in ApiExtractBlock src, ref ApiExtractRow dst)
        {
            dst.Base = src.BaseAddress;
            dst.Encoded = src.Storage;
            dst.Uri = src.Uri;
            return ref dst;
        }

        void MatchAddresses(ApiMemberExtract[] extracted, AsmRoutine[] decoded)
        {
            try
            {
                var flow = Wf.Running(string.Format("Attempting to match <{0}> routine addresses", extracted.Length));
                var a = extracted.Select(x => x.BaseAddress).ToHashSet();
                if(a.Count != extracted.Length)
                {
                    Wf.Error($"count(Extracted) = {extracted.Length} != {a.Count} = count(set(Extracted))");
                    return;
                }

                var b = decoded.Select(f => f.BaseAddress).ToHashSet();
                if(b.Count != decoded.Length)
                {
                    Wf.Error($"count(Decoded) = {decoded.Length} != {b.Count} = count(set(Decoded))");
                    return;
                }

                b.IntersectWith(a);
                if(b.Count != decoded.Length)
                {
                    Wf.Error($"count(Decoded) = {decoded.Length} != {b.Count} = count(intersect(Decoded,Extracted))");
                    return;
                }

                Wf.Ran(flow, string.Format("Matched <{0}> routine addresses", extracted.Length));
            }
            catch(Exception e)
            {
                Wf.Error(e);
            }
        }
    }
}