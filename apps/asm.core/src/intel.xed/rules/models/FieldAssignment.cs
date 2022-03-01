//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        public readonly struct FieldAssignment
        {
            public readonly FieldKind Field;

            readonly ulong Data;

            [MethodImpl(Inline)]
            public FieldAssignment(FieldKind field, ulong data)
            {
                Field = field;
                Data = data;
            }

            public string Format()
            {
                if(Field == 0)
                    return EmptyString;
                else
                    return string.Format("{0}={1}", FieldKinds[Field].Expr, Data.ToString());
            }

            public override string ToString()
                => Format();

            public static FieldAssignment Empty => new FieldAssignment(FieldKind.INVALID,0);
        }
    }
}