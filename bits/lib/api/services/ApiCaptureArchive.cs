//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCaptureArchive : AppService<ApiCaptureArchive>
    {
        public ApiCaptureArchive()
        {

        }

        public void Clear()
        {
            foreach(var part in Wf.ApiCatalog.PartIdentities)
                Clear(part);
        }

        public void Clear(PartId part)
        {
            var total = 0u;
            var flow = Wf.Running(string.Format("Clearing {0} files", part.Format()));
            total += ClearExtracts(part);
            total += ClearHex(part);
            total += ClearAsm(part);
            total += ClearCilData(part);
            total += ClearCilCode(part);
            Wf.Ran(flow, string.Format("Cleared {0} files for part {1}", total, part.Format()));
        }

        public void Clear(Index<PartId> parts)
        {
            foreach(var part in parts)
                Clear(part);
        }

        static Outcome<uint> Clear(FS.Files src)
            => src.Delete();

        void ClearStatus(PartId part, FS.FileExt ext, Count count)
            => Wf.Status(Msg.ClearedPartFiles.Format(count, ext, part));

        Outcome<uint> ClearExtracts(PartId part)
        {
            var kind = FS.XCsv;
            var files = Db.RawExtractFiles(part);
            var result = Clear(files);
            if(result)
                ClearStatus(part, kind, result.Data);
            else
                Wf.Error(result.Message);
            return result;
        }

        Outcome<uint> ClearHex(PartId part)
        {
            var kind = FS.PCsv;
            var files = Db.ParsedExtractPaths(part);
            var result = Clear(files);
            if(result)
                ClearStatus(part, kind, result.Data);
            else
                Wf.Error(result.Message);
            return result;
        }

        Outcome<uint> ClearAsm(PartId part)
        {
            var kind = FS.Asm;
            var files = Db.AsmCapturePaths(part);
            var result = Clear(files);
            if(result)
                ClearStatus(part, kind, result.Data);
            else
                Wf.Error(result.Message);
            return result;
        }

        Outcome<uint> ClearCilData(PartId part)
        {
            var kind = FS.IlData;
            var files = Db.CilPaths.CilDataPaths(part);
            var result = Clear(files);
            if(result)
                ClearStatus(part, kind, result.Data);
            else
                Wf.Error(result.Message);
            return result;
        }

        Outcome<uint> ClearCilCode(PartId part)
        {
            var kind = FS.Il;
            var files = Db.CilPaths.CilCodePaths(part);
            var result = Clear(files);
            if(result)
                ClearStatus(part, kind, result.Data);
            else
                Wf.Error(result.Message);
            return result;
        }
    }

    partial struct Msg
    {
        public static MsgPattern<Count,FS.FileExt,PartName> ClearedPartFiles => "Cleared {0} {1} files for part {2}";
    }
}