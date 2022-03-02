//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    partial class XedRules
    {
        [Record(TableName), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct MacroAssignment
        {
            public const byte FieldCount = 7;

            public const string TableName = "xed.rules.macros";

            public uint Seq;

            public RuleMacroName MacroName;

            public FieldAssignment A0;

            public FieldAssignment A1;

            public FieldAssignment A2;

            public FieldAssignment A3;

            public FieldAssignment A4;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,26,26,26,26,26};

            public static MacroAssignment Empty => default;
        }
    }
}