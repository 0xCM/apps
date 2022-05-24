//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiCollection
    {
        internal Index<ResolvedPart> _ResolvedParts;

        internal ApiCollection()
        {
            _ResolvedParts = new();
        }

        public ReadOnlySpan<ResolvedPart> ResolvedParts
        {
            [MethodImpl(Inline)]
            get => _ResolvedParts.View;
        }
    }
}