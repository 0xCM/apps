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
        string Name {get;}

        /// <summary>
        /// The setting value
        /// </summary>
        dynamic Value {get;}
    }

    public interface ISetting<T> : ISetting
    {
        new T Value {get;}

        dynamic ISetting.Value
            => Value;
    }

    public interface ISetting<K,V> : ISetting<V>
    {
        new K Name {get;}

        string ISetting.Name
            => Name.ToString();

        string ITextual.Format()
            => Settings.format(Name, Value);
    }

    public interface ISetting<H,K,V> : ISetting<K,V>
        where H : struct, ISetting<H,K,V>
    {

    }
}