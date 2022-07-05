//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IVarResolver
    {
        IExprDeprecated Resolve(NameOld name);

        T Resolve<T>(NameOld name)
            where T : IExprDeprecated;
    }
}