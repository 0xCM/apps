//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    [Free]
    public interface ISettings : ITextual
    {
        Identifier Name {get;}

        Settings Settings {get;}

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