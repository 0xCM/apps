//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        public interface IProjectProperty : IProjectElement
        {
            dynamic Value {get;}
        }

        public interface IProjectProperty<T> : IProjectProperty
        {
            new T Value {get;}

            dynamic IProjectProperty.Value
                => Value;
        }

        public interface IProjectProperty<F,T> : IProjectProperty<T>, IProjectElement<F>
            where F : struct, IProjectProperty<F,T>
            where T : IProjectProperty
        {
        }

        public interface IBuildProperty : IProjectProperty
        {

            // string ITextual.Format()
            //     => string.Format("<{0}>{1}</{0}>", Name, Value);
        }

        public interface IBuildProperty<T> : IBuildProperty
        {
            new T Value {get;}

            dynamic IProjectProperty.Value
                => Value;
        }
    }
}