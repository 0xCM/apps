//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-command-line-reference?view=vs-2019
    /// </summary>
    public enum BuildLogVerbosity : byte
    {
        normal,

        quiet,

        minimial,

        detailed,

        diagnostic
    }
}