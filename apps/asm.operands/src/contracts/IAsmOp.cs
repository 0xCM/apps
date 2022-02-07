//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Characterizes an asm operand representation
    /// </summary>
    public interface IAsmOp
    {
        AsmOpKind OpKind => default;

        AsmOpClass OpClass => (AsmOpClass)OpKind;

        NativeSize Size => (NativeSizeCode)((ushort)OpKind >> 8);
    }

    public interface IAsmOp<T> : IAsmOp
        where T : unmanaged
    {

    }
}