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

        XedRuntime Xed;

        Index<PointerWidth> PointerWidths;

        Symbols<VisibilityKind> Visibilities;

        Symbols<XedFieldType> FieldTypes;

        AppServices AppSvc => Service(Wf.AppServices);

        bool PllExec
        {
            [MethodImpl(Inline)]
            get => Xed.PllExec;
        }

        public XedRules With(XedRuntime xed)
        {
            Xed = xed ;
            return this;
        }

        [MethodImpl(Inline)]
        Label Label(string src)
            => Xed.Allocator.Label(src);

        [MethodImpl(Inline)]
        StringRef String(string src)
            => Xed.Allocator.String(src);

        public XedRules()
        {
            PointerWidths = map(PointerWidthKinds.View, s => (PointerWidth)s.Kind);
            Visibilities = Symbols.index<VisibilityKind>();
            FieldTypes = Symbols.index<XedFieldType>();
        }

        XedPaths XedPaths => Xed.Paths;

        AppDb AppDb => Service(Wf.AppDb);

        static Symbols<PointerWidthKind> PointerWidthKinds;

        static XedRules()
        {
            PointerWidthKinds = Symbols.index<PointerWidthKind>();
        }

        static MsgPattern<string> StepParseFailed => "Failed to parse step from '{0}'";
    }
}