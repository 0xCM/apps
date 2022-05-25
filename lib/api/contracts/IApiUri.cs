//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiUri : IIdentified
    {
        string UriText {get;}

        string IIdentified.IdentityText
            => UriText;
    }

    [Free]
    public interface IApiUri<T> : IApiUri, IIdentification<T>
        where T : IApiUri<T>
    {

    }
}