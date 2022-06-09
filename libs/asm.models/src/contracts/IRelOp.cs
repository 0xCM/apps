//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IRelOp : IAsmOp, ITextual
    {
        AsmRelKind RelKind {get;}

        uint Value {get;}
    }

    public interface IRelOp<T> : IRelOp
        where T : unmanaged
    {
        new T Value {get;}

        uint IRelOp.Value
            => core.bw32(Value);

        NativeSize IAsmOp.Size
            => Sizes.native(core.width<T>());

        AsmRelKind IRelOp.RelKind
            => (AsmRelKind)(byte)Size;

        AsmOpClass IAsmOp.OpClass
            => AsmOpClass.Rel;
    }
}