//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IEnvWs : IWorkspace
    {
        Settings Globals();

        Settings Settings(string id);
    }
}