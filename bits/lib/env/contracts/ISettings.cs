//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ISettings : ITextual
    {
        Identifier Name
            => GetType().Name;

        Settings Settings
            => api.from(this);

        string ITextual.Format()
            => Settings.Format();
    }

    [Free]
    public interface ISettings<S> : ISettings
        where S : ISettings<S>
    {
        Identifier ISettings.Name
            => typeof(S).Name;

        Settings ISettings.Settings
            => api.from((S)this);
    }
}