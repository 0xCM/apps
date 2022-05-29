//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public ref struct PdbReader
    {
        [MethodImpl(Inline), Op]
        public static HResult<PdbMethod> method(PdbReader reader, CliToken token)
        {
            HResult result = reader.Provider.GetMethod((int)token, out var accessor);
            if(result)
                return PdbMethod.adapt(accessor);
            else
                return result;
        }

        public static PdbReader create(IWfRuntime wf, in PdbSymbolSource src)
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

        public static PdbReader create(IWfRuntime wf, FS.FilePath pe, FS.FilePath pdb)
        {
            if(!pe.Exists)
                Throw.sourced(FS.Msg.DoesNotExist.Format(pe));
            if(!pdb.Exists)
                Throw.sourced(FS.Msg.DoesNotExist.Format(pdb));
            return create(wf, PdbSymbolSource.create(pe, pdb));
        }

        static object importer(in PdbSymbolSource src)
            => SymUnmanagedReaderFactory.CreateSymReaderMetadataImport(SymMetadataProvider.create(src));

        static ISymUnmanagedReader5 portable(in PdbSymbolSource src)
            => (ISymUnmanagedReader5)new SymBinder().GetReaderFromStream(src.PdbStream, importer(src));

        static ISymUnmanagedReader5 legacy(in PdbSymbolSource src)
            => SymUnmanagedReaderFactory.CreateReader<ISymUnmanagedReader5>(src.PdbStream, SymMetadataProvider.create(src));

        Index<PdbDocument> _Documents;

        Index<ISymUnmanagedDocument> UnmanagedDocs;

        Index<PdbMethods> _DocumentMethods;

        public PdbSymbolSource Source {get;}

        internal readonly ISymUnmanagedReader5 Provider;

        Index<PdbMethod> _Methods;

        [MethodImpl(Inline)]
        internal PdbReader(IWfRuntime wf, PdbSymbolSource src, ISymUnmanagedReader5 provider)
        {
            Source = src;
            Provider = provider;
            UnmanagedDocs = provider.GetDocuments();
            _Documents = provider.GetDocuments().Select(PdbDocument.adapt);
            _DocumentMethods = UnmanagedDocs.Storage.Map(doc => PdbMethods.load(provider,doc));
            _Methods = Index<PdbMethod>.Empty;
        }

        public void Dispose()
        {
            Source.Dispose();
        }

        public HResult<PdbMethod> Method(CliToken token)
            => method(this, token);

        public ReadOnlySpan<PdbMethod> Methods
        {
            get
            {
                if(_Methods.IsEmpty)
                {
                    _Methods = _DocumentMethods.SelectMany(x => x.Methods).Select(PdbMethod.adapt);
                }
                return _Methods;
            }
        }

        public ReadOnlySpan<PdbDocument> Documents
        {
            [MethodImpl(Inline)]
            get => _Documents.View;
        }
    }
}