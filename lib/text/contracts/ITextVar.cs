//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextVar : ITextual, INullity, IVar<string>
    {
        bool INullity.IsEmpty
            => text.empty(Value);
    }

    public interface ITextVar<K> : ITextVar
        where K : ITextVarKind, new()
    {
        K VarKind  => new K();
    }
}