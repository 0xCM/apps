//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Z0.Parts.IntelIntrinsics;
    using static IntrinsicsDoc;
    using static core;

    public partial class IntelIntrinsics : AppService<IntelIntrinsics>
    {
        static internal ref readonly PartAssets Assets => ref AssetData;

        AppSvcOps AppSvc => Wf.AppSvc();

        AppDb AppDb => Wf.AppDb();

        DbSources Sources()
            => AppDb.Sources("intel");

        DbTargets Targets()
            => AppDb.Targets("intrinsics");

        FS.FilePath XmlSource()
            => Sources().Path(XmlFile);

        FS.FilePath DeclPath()
            => Targets().Path(DeclFile);

        FS.FilePath AlgPath()
            => Targets().Path(AlgFile);

        XmlDoc LoadDocXml()
            => XmlSource().ReadUtf8();

        Index<IntrinsicDef> ParseDoc()
            => read(LoadDocXml());

        public void EmitAlgorithms(ReadOnlySpan<IntrinsicDef> src)
        {
            var dst = text.emitter();
            AlgRender.render(src,dst);
            AppSvc.FileEmit(dst.Emit(), AlgPath(), TextEncodingKind.Utf8);
        }

        public void EmitDeclarations(ReadOnlySpan<IntrinsicDef> src)
        {
            var dst = DeclPath();
            var flow = EmittingFile(dst);
            var count = src.Length;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(string.Format("{0};", skip(src,i).Sig()));
            EmittedFile(flow, count);
        }

        public Index<IntrinsicRecord> EmitRecords(Index<IntrinsicDef> src)
        {
            var dst = alloc<IntrinsicRecord>(src.Count);
            records(src,dst);
            AppSvc.TableEmit(dst.Sort().Resequence(), Targets().Table<IntrinsicRecord>());
            return dst;
        }

        public Index<IntrinsicDef> Emit()
        {
            Targets().Clear();
            var parsed = ParseDoc();
            EmitAlgorithms(parsed);
            var records = EmitRecords(parsed);
            EmitDeclarations(parsed);
            return parsed;
        }

        const string intrinsics = "intel.intrinsics";

        const string sep = ".";

        const string refs = intrinsics + sep + nameof(refs);

        const string checks = intrinsics + sep + nameof(checks);

        const string specs = intrinsics + sep + nameof(specs);

        const string algs = intrinsics + sep + nameof(algs);

        const string sigs = intrinsics + sep + nameof(sigs);

        public static FS.FileName AlgFile => FS.file(algs, FS.Txt);

        public static FS.FileName DataFile => FS.file(intrinsics, FS.Csv);

        public static FS.FileName XmlFile => FS.file(intrinsics, FS.Xml);

        public static FS.FileName DeclFile = FS.file(intrinsics, FS.H);
    }
}