//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public abstract class TypeSystem<T> : ITypeSystem
        where T : TypeSystem<T>, new()
    {
        public Label Name {get;}

        public abstract ReadOnlySpan<TypeKind> Kinds {get;}

        protected TypeSystem(Label name)
        {
            Name = name;
        }
    }
}