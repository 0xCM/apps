//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Microsoft.SymbolStore;
    using Microsoft.SymbolStore.KeyGenerators;
    using SOS;

    public sealed class PdbSymbols : AppService<PdbSymbols>
    {
        /// <summary>
        /// Loads a symbol source from specified binary data
        /// </summary>
        /// <param name="pe">The pe data</param>
        /// <param name="pdb">The pdb data</param>
        [Op]
        public static PdbSymbolSource source(ReadOnlySpan<byte> pe, ReadOnlySpan<byte> pdb)
            => new PdbSymbolSource(pe,pdb);

        /// <summary>
        /// Loads a <see cref='PdbSymbolSource'/> for specified pe and pdb paths
        /// </summary>
        /// <param name="pe">The pe file path</param>
        /// <param name="pdb">The pdb file path</param>
        [Op]
        public static PdbSymbolSource source(FS.FilePath pe, FS.FilePath pdb)
            => new PdbSymbolSource(pe, pdb);

        /// <summary>
        /// Loads a <see cref='PdbSymbolSource'/> for specified pe, assuming the existence of a colocated pdb
        /// </summary>
        /// <param name="pe">The pe file path</param>
        [Op]
        public static PdbSymbolSource source(FS.FilePath pe)
            => new PdbSymbolSource(pe, pe.ChangeExtension(FS.Pdb));

        SymbolPaths SymPaths => Z0.SymbolPaths.create(Env);

        public FS.Files EmitDefaultSymbolPaths(FS.FilePath dst)
        {
            var paths = SymbolPaths(SymPaths.DefaultSymbolCache());
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