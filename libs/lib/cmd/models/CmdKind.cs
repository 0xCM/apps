//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Classifies concrete command types
    /// </summary>
    public enum CmdKind : byte
    {        
        None,

        [Symbol("app", "Classifies commands that are routed via the application api")]
        App,

        [Symbol("tool", "Classifies commands that are routed via the toolbase api")]
        Tool,

        [Symbol("cmd", "Classifies commands that are routed via cmd.exe")]
        Cmd,

        [Symbol("pwsh", "Classifies commands that are routed via pwsh.exe")]
        Pwsh,

        [Symbol("wsl", "Classifies commands that are routed via wsl.exe")]
        Wsl,

    }
}