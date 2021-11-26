//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Microsoft.DiaSymReader;
    using Microsoft.DiaSymReader.PortablePdb;

    partial struct PdbServices
    {
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

        /// <summary>
        /// Loads a symbol source from specified binary data
        /// </summary>
        /// <param name="pe">The pe data</param>
        /// <param name="pdb">The pdb data</param>
        [Op]
        public static PdbSymbolSource source(ReadOnlySpan<byte> pe, ReadOnlySpan<byte> pdb)
            => new PdbSymbolSource(pe,pdb);

        public static PdbReader reader(IWfRuntime wf, in PdbSymbolSource src)
        {
            var flow = wf.Running(Msg.CreatingPdbReader.Format(src.PdbPath));
            var reader = default(PdbReader);
            if(src.IsPortable)
                reader = new PdbReader(wf, src, portable(src));
            else
                reader = new PdbReader(wf, src, legacy(src));
            wf.Ran(flow, Msg.CreatedPdbReader.Format(src.PdbPath));
            return reader;
        }

        public static PdbReader reader(IWfRuntime wf, FS.FilePath pe, FS.FilePath pdb)
        {
            if(!pe.Exists)
                Throw.sourced(FS.Msg.DoesNotExist.Format(pe));
            if(!pdb.Exists)
                Throw.sourced(FS.Msg.DoesNotExist.Format(pdb));
            return reader(wf, source(pe, pdb));
        }

        static SymMetadataProvider metaprovider(in PdbSymbolSource source)
            => new SymMetadataProvider(source);

        static object importer(in PdbSymbolSource src)
            => SymUnmanagedReaderFactory.CreateSymReaderMetadataImport(metaprovider(src));

        static ISymUnmanagedReader5 portable(in PdbSymbolSource src)
            => (ISymUnmanagedReader5)new SymBinder().GetReaderFromStream(src.PdbStream, importer(src));

        static ISymUnmanagedReader5 legacy(in PdbSymbolSource src)
            => SymUnmanagedReaderFactory.CreateReader<ISymUnmanagedReader5>(src.PdbStream, metaprovider(src));
    }
}