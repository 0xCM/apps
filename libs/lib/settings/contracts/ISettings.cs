//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = SettingIndex;

    [Free]
    public interface ISettings : IExpr
    {
        Identifier Name {get;}

        SettingIndex Settings {get;}

        bool INullity.IsEmpty
            => Settings.IsEmpty;

        bool INullity.IsNonEmpty
            => Settings.IsNonEmpty;

        string IExpr.Format()
            => Settings.Format();
    }

    [Free]
    public interface ISettings<S> : ISettings
        where S : ISettings<S>
    {
        Identifier ISettings.Name
            => typeof(S).Name;

        SettingIndex ISettings.Settings
            => api.index((S)this);
    }
}