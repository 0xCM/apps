//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a nonparametric application setting
    /// </summary>
    public interface ISetting : ITextual
    {
        /// <summary>
        /// The setting name
        /// </summary>
        VarName Name {get;}

        /// <summary>
        /// The setting value
        /// </summary>
        dynamic Value {get;}

        string ITextual.Format()
            => $"{Name}={Value}";
    }

    public interface ISetting<T> : ISetting
    {
        new T Value {get;}

        dynamic ISetting.Value
            => Value;
    }
}