//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IToolResultHandler
    {
        ToolIdOld Tool => default;

        bool CanHandle(TextLine src);

        bool Handle(TextLine src);
    }
}