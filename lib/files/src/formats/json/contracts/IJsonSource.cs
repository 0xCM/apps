//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IJsonSource : ITextual
    {
        JsonText ToJson();

        string ITextual.Format()
            => ToJson().Format();
    }

    [Free]
    public interface IJsonSource<H> : IJsonSource
        where H : struct, IJsonSource<H>
    {

    }
}