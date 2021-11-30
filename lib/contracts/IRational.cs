//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IRational<T> : ITextual
    {
        /// <summary>
        /// The dividend
        /// </summary>
        T Over {get;}

        /// <summary>
        /// The divisor
        /// </summary>
        T Under {get;}
    }

    [Free]
    public interface IRational<H,T> : IRational<T>
        where H : struct, IRational<H,T>
    {

    }
}