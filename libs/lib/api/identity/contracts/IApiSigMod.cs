//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IApiSigMod<T> : ITextual
        where T : struct, IApiSigMod<T>
    {
        NameOld Name {get;}

        ApiSigModKind Kind {get;}
    }
}