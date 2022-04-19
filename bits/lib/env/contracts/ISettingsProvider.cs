//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes an application settings provider that supports settings persistence
    /// </summary>
    public interface ISettingsProvider : ITextual
    {
        /// <summary>
        /// The provided settings
        /// </summary>
        Settings Settings {get;}
    }
}