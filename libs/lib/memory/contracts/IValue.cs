//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <def>
    /// A value is a concretized thing
    /// </def>
    public interface IValue
    {
        dynamic Value {get;}
    }

    /// <summary>
    /// Characterizes a value of parametric type
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    public interface IValue<T> : IValue
    {
        new T Value {get;}

        dynamic IValue.Value
            => Value;
    }
}