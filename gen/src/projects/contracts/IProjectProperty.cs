//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IProjectProperty : IProjectElement
    {
        string Value {get;}
    }

    public interface IProjectProperty<F> : IProjectProperty, IProjectElement<F>
        where F : struct, IProjectProperty<F>
    {

    }

    public interface IBuildProperty : ITextual
    {
        Identifier Name {get;}

        dynamic Value {get;}

        string ITextual.Format()
            => string.Format("<{0}>{1}</{0}>", Name, Value);
    }

    public interface IBuildProperty<T> : IBuildProperty
    {
        new T Value {get;}

        dynamic IBuildProperty.Value
            => Value;
    }

}