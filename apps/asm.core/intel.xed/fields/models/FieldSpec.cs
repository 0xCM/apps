//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct FieldSpec
        {
            public byte Seq;

            public byte Index;

            public FieldKind Kind;

            public Type DomainType;

            public PackedWidth DomainWidth;

            public Type StorageType;

            public StorageWidth StorageWidth;

            public TextBlock Description;

            public static FieldSpec Empty => default;
        }
    }
}