//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IWfEventId<T> : IComparable<T>, IEquatable<T>, INamed<T>, IChronic<T>, ITextual
        where T : struct, IWfEventId<T>
    {

    }
}