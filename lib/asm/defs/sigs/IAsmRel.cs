//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public interface IAsmRel : ITextual
    {
        AsmSigs.RelToken Kind {get;}

        string Name {get;}

        string ITextual.Format()
            => Name;
    }

    public interface IAsmRel<T> : IAsmRel
        where T : unmanaged
    {

    }
}