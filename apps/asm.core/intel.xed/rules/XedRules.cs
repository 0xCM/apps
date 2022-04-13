//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    [ApiHost]
    public partial class XedRules : AppService<XedRules>
    {
        const string xed = "xed";

        const NumericKind Closure = UnsignedInts;

        Index<PointerWidth> PointerWidths;

        Symbols<VisibilityKind> Visibilities;

        Symbols<XedFieldType> FieldTypes;

        static AppData AppData
        {
            [MethodImpl(Inline)]
            get => AppData.get();
        }

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => AppData.PllExec();
        }

        public XedRules()
        {
            PointerWidths = map(PointerWidthKinds.View, s => (PointerWidth)s.Kind);
            Visibilities = Symbols.index<VisibilityKind>();
            FieldTypes = Symbols.index<XedFieldType>();
        }

        XedPaths XedPaths => Service(Wf.XedPaths);

        AppDb AppDb => Service(Wf.AppDb);

        XedLookups XedTables => Service(Wf.XedTables).Data;

        XedDocs Docs => Service(Wf.XedDocs);

        static Symbols<PointerWidthKind> PointerWidthKinds;

        static XedRules()
        {
            PointerWidthKinds = Symbols.index<PointerWidthKind>();
       }

        static MsgPattern<string> StepParseFailed => "Failed to parse step from '{0}'";
    }
}