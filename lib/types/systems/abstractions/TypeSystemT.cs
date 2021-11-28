//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class TypeSystem<T>
        where T : TypeSystem<T>, new()
    {
        public Label Name {get;}

        protected TypeSystem(Label name)
        {
            Name = name;
        }
    }
}