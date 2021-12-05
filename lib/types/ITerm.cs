//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITerm : ITextual
    {
        bool IsEmpty
            => false;

        bool IsNonEmpty
            => !IsEmpty;

        string ITextual.Format()
            => string.Empty;
    }

    [Free]
    public interface ITerm<T> : ITerm
    {
        T Value {get;}
    }
}