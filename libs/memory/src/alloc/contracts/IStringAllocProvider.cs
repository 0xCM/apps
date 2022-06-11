//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IStringAllocProvider
    {
        Label Label(string src);

        StringRef String(string src);
    }
}