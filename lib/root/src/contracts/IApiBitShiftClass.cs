//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = ApiBitShiftClass;
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    /// <summary>
    /// Characterizes a bitshift operation classifier
    /// </summary>
    [Free]
    public interface IApiBitShiftClass : IApiClass<K>
    {
        new ApiBitShiftClass Kind {get;}

        K IApiClass<K>.Kind
            => Kind;
    }
}