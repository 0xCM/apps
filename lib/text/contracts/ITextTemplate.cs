//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextTemplate : ITextual, INullity
    {
        TextBlock Pattern {get;}

        object[] Parameters {get;}

        uint ParameterCount {get;}

        bool INullity.IsEmpty
            => Pattern.IsEmpty;

        bool INullity.IsNonEmpty
            => Pattern.IsNonEmpty;
    }
}