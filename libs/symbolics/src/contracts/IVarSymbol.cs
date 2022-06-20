//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IVarSymbol<T> : INamed<T>
        where T : unmanaged, ICharBlock<T>
    {
        new Name<T> Name {get;}

        Name INamed.Name
            => Name.ToString();
    }
}