//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class ShellAssets : Assets<ShellAssets>
    {
        static ShellAssets _Service = new();

        public static ref readonly ShellAssets Service => ref _Service;

        public Asset ArchiveCapture() => Asset("archive-capture.template");
    }
}