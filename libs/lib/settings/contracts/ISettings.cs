//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    [Free]
    public interface ISettings : IExpr
    {
        Name Name {get;}

        SettingLookup Settings {get;}

        bool INullity.IsEmpty
            => Settings.IsEmpty;

        bool INullity.IsNonEmpty
            => Settings.IsNonEmpty;

        string IExpr.Format()
            => Settings.Format();
    }

    [Free]
    public interface ISettings<S> : ISettings
        where S : ISettings<S>, new()
    {
        Name ISettings.Name
            => typeof(S).Name;

        SettingLookup ISettings.Settings
            => api.lookup((S)this);
    }
}