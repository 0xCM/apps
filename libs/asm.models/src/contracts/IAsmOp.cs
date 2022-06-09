//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an asm operand representation
    /// </summary>
    [Free]
    public interface IAsmOp : ITextual
    {
        AsmOpKind OpKind {get;}

        AsmOpClass OpClass {get;}

        NativeSize Size {get;}
    }

    [Free]
    public interface IAsmOp<T> : IAsmOp
        where T : unmanaged
    {

    }
}