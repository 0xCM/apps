//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.SymbolStore;
    using Microsoft.SymbolStore.KeyGenerators;
    using SOS;

    using static Root;

    public sealed class PdbSymbolStore : AppService<PdbSymbolStore>
    {
        public FS.Files EmitDefaultSymbolPaths(FS.FilePath dst)
        {
            var paths = SymbolPaths(Db.DebugSymbolPaths().DefaultSymbolCache());
            var buffer = text.buffer();
            FS.render(paths.View, buffer);
            using var writer = dst.Writer();
            writer.Write(buffer.Emit());
            return paths;
        }

        public DirectorySymbolStore DirectoryStore(FS.FolderPath dir)
            => new DirectorySymbolStore(tracer(Wf), null, dir.Name);

        public SymbolStoreFile SymbolFile(FS.FilePath src)
            => new SymbolStoreFile(src.Stream(), src.FileName.Name);

        public KeyGenerator KeyGenerator(SymbolStoreFile src)
            => new PortablePDBFileKeyGenerator(tracer(Wf), src);

        public Index<SymbolStoreKey> Identities(KeyGenerator src)
            => src.GetKeys(KeyTypeFlags.IdentityKey).Array();

        public Index<SymbolStoreKey> Identities(SymbolStoreFile src)
            => Identities(KeyGenerator(src)).Array();

        public Index<SymbolStoreKey> SymbolKeys(KeyGenerator src)
            => src.GetKeys(KeyTypeFlags.IdentityKey).Array();

        public Index<SymbolStoreKey> SymbolKeys(SymbolStoreFile src)
            => SymbolKeys(KeyGenerator(src)).Array();

        public FS.Files SymbolPaths(FS.FolderPath src)
            => src.Files(FS.Pdb, true);

        [MethodImpl(Inline)]
        static ITracer tracer(IWfRuntime wf)
            => new SymbolTracer(wf);
    }
}