//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a pararametric text block bound to an arbitrary number of variables
    /// </summary>
    public interface ITextTemplate : INullity
    {
        TextBlock Pattern {get;}

        Index<object> Parameters {get;}

        uint ParameterCount
            => Parameters.Count;

        bool INullity.IsEmpty
            => Pattern.IsEmpty;

        bool INullity.IsNonEmpty
            => Pattern.IsNonEmpty;
    }
}