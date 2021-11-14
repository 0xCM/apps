//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmSlotType
    {
        AsmLayoutKind Kind {get;}
    }

    public interface IAsmSlotType<T> : IAsmSlotType
        where T : unmanaged, IAsmSlotType<T>
    {

    }
}