//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITerm : ITextual
    {
        bool IsEmpty
            => false;

        bool IsNonEmpty
            => !IsEmpty;
    }

    [Free]
    public interface ITerm<T> : ITerm
    {
        T Value {get;}
    }
}