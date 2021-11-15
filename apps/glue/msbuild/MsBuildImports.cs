//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using System.Reflection;

    public readonly struct MsBuildImports
    {
        public Assembly MsBuildFramework
            => typeof(Microsoft.Build.Framework.BuildEngineResult).Assembly;

        public Assembly MsBuildTasks
            => typeof(Microsoft.Build.Tasks.AssignCulture).Assembly;

        public Assembly MsBuildUtilities
            => typeof(Microsoft.Build.Utilities.MuxLogger).Assembly;
    }
}