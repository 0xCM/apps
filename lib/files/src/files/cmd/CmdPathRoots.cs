//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct CmdPathRoots
    {
        /// <summary>
        /// The windows sdk installation root
        /// </summary>
        public FS.FolderPath WinSdk;

        /// <summary>
        /// The Visual Stuidio installation root
        /// </summary>
        public FS.FolderPath Msvs;

        /// <summary>
        /// The LLVM source root
        /// </summary>
        public FS.FolderPath LlvmRoot;
    }
}