//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct FlagAction
        {
            public RegFlag Flag {get;}

            public FlagActionKind ActionKind {get;}

            [MethodImpl(Inline)]
            public FlagAction(RegFlag f, FlagActionKind k)
            {
                Flag = f;
                ActionKind = k;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Flag == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Flag != 0;
            }

            public string Format()
                => string.Format("{0}-{1}", Symbols.expr(Flag), Symbols.expr(ActionKind));

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator FlagAction((RegFlag f, FlagActionKind k) src)
                => new FlagAction(src.f, src.k);
        }
    }
}