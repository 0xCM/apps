//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a function that accepts an input of parametric type
    /// </summary>
    /// <typeparam name="T">The input type</typeparam>
    [Free]
    public delegate void Receiver<T>(in T src);

    /// <summary>
    /// Characterizes a receiver that accepts a pointer
    /// </summary>
    /// <typeparam name="T">The stream element type</typeparam>
    [Free]
    public unsafe delegate void PointedReceiver<T>(T* pSrc)
        where T : unmanaged;
}