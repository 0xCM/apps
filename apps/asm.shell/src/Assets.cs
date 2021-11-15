//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class AsmShellAssets : Assets<AsmShellAssets>
    {
         public Asset ToolsConfigCmd() => Asset("tools.config.txt");

         public Asset ToolsEmitConfigCmd() => Asset("tools.emit-config.txt");

         public Asset ToolsEmitHelpCmd() => Asset("tools.emit-help.txt");
    }
}
