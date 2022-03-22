//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static XedModels;
    using static XedRules;

    [Record(TableId)]
    public struct XedQueryResult
    {
        public const string TableId = "xed.query.result";

        public const string DisplayPattern = "class:{0,-24} form:{1,-32} category:{2,-16} isa:{3,-16} ext:{4,-16} attribs:{5}";

        public const byte FieldCount = 6;

        public string SearchPattern;

        public IClass Class;

        public IForm Form;

        public IsaKind Isa;

        public ExtensionKind Extension;

        public InstAttribs Attributes;

        public static XedQueryResult Empty => default;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{16,16,48,16,16,1};
    }
}