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
        public static Index<FieldSpec> FieldSpecs()
        {
            return data(nameof(FieldSpecs), calc);

            Index<FieldSpec> calc()
            {
                var src = typeof(OperandState).InstanceFields().Tagged<RuleFieldAttribute>().ToIndex();
                var count = src.Length;
                Index<FieldSpec> dst = core.alloc<FieldSpec>(ReflectedFields.FieldCount);
                for(var i=z8; i<count; i++)
                {
                    ref var field = ref src[i];
                    ref var record = ref dst[i + 1];

                    var tag = field.Tag<RuleFieldAttribute>().Require();
                    record.Seq = i;
                    record.Kind = tag.Kind;
                    record.Index = (byte)tag.Kind;
                    record.StorageType = field.FieldType;
                    record.DomainType = tag.EffectiveType;
                    record.DomainWidth = tag.Width;
                    record.StorageWidth = (byte)XedFields.width(field.FieldType);
                    record.Description = tag.Description;
                }
                return dst;
            }
        }

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

        XedDocs Docs => Service(Wf.XedDocs);

        static Symbols<PointerWidthKind> PointerWidthKinds;

        static XedRules()
        {
            PointerWidthKinds = Symbols.index<PointerWidthKind>();
       }

        static MsgPattern<string> StepParseFailed => "Failed to parse step from '{0}'";
    }
}