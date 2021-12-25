//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class EnvWs : Workspace<EnvWs>, IEnvWs
    {
        public Settings Globals()
            => Settings("global");

        Settings Load(FS.FilePath src)
        {
            var dst = Z0.Settings.Empty;
            try
            {
                dst = Z0.Settings.parse(src.ReadLines());
            }
            catch(Exception e)
            {
                term.error(e);
            }
            return dst;
        }

        public Settings Settings(string id)
            => Load(Root + FS.file(id, FS.Settings));

        [MethodImpl(Inline)]
        public static EnvWs create(FS.FolderPath root)
            => new EnvWs(root);

        [MethodImpl(Inline)]
        internal EnvWs(FS.FolderPath root)
            : base(root)
        {
        }
    }
}
