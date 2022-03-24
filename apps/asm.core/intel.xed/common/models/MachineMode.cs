//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public readonly struct MachineMode
        {
            public readonly ModeKind Kind;

            [MethodImpl(Inline)]
            public MachineMode(ModeKind mode)
            {
                Kind = mode;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator MachineMode(ModeKind src)
                => new MachineMode(src);

            [MethodImpl(Inline)]
            public static implicit operator ModeKind(MachineMode src)
                => src.Kind;
        }
    }
}