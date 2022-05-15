//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    public partial class XedImport : AppService<XedImport>
    {
        XedPaths XedPaths => Service(Wf.XedPaths);

        AppServices AppSvc => Service(Wf.AppServices);

        AppDb AppDb => Service(Wf.AppDb);

        XedRuntime Xed;

        public XedImport With(XedRuntime xed)
        {
            Xed = xed;
            return this;
        }

        public void Run()
        {
            ImportInstBlocks();
        }

        public static ref readonly Index<BlockField> BlockFields
        {
            [MethodImpl(Inline)]
            get => ref _BlockFields;
        }

        public void ImportInstBlocks()
        {
            using var importer = new InstBlockImporter(AppSvc);
            importer.Run();
        }

        static Index<BlockField> _BlockFields;

        static XedImport()
        {
            _BlockFields = Symbols.index<BlockField>().Kinds.ToArray();
        }
    }
}