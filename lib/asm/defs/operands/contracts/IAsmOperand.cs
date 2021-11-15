//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public interface IAsmOperand
    {
        AsmOpClass OpClass {get;}

        NativeSize Size {get;}

        ReadOnlySpan<byte> Data {get;}
    }

    public interface IAsmOperand<T> : IAsmOperand
        where T : unmanaged
    {

    }
}