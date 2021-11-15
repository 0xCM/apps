//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using api = JsonSettings;

    /// <summary>
    /// Characterizes an app settings collection
    /// </summary>
    public interface IJsonSettings : IEnumerable<ISetting>, ITextual
    {
        Option<string> Setting(string name);

        string this[string name] {get;}

        IEnumerable<ISetting> All {get;}

        IEnumerator<ISetting> IEnumerable<ISetting>.GetEnumerator()
            => All.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => All.GetEnumerator();

        string ITextual.Format()
            => api.format(this);

        ISettingsAdapter<T> Adapt<T>()
            where T : ISettingsAdapter<T>, new()
        {
            var adapter = new T();
            return adapter.Adapt(this);
        }
    }
}