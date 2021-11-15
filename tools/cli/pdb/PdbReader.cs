//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.DiaSymReader;

    using static Root;
    using static PdbServices;
    using static PdbModel;

    public ref struct PdbReader
    {
        Index<Document> _Documents;

        DocumentMethods _DocumentMethods;

        public PdbSymbolSource Source {get;}

        internal ISymUnmanagedReader5 Provider {get;}

        Index<Method> _Methods;

        [MethodImpl(Inline)]
        internal PdbReader(IWfRuntime wf, PdbSymbolSource src, ISymUnmanagedReader5 provider)
        {
            Source = src;
            Provider = provider;
            _DocumentMethods = methods(provider);
            _Documents = _DocumentMethods.Keys.Array().Select(adapt);
            _Methods = Index<Method>.Empty;
        }

        public void Dispose()
        {
            Source.Dispose();
        }

        public HResult<Method> Method(CliToken token)
            => method(this, token);

        public ReadOnlySpan<Method> Methods
        {
            get
            {
                if(_Methods.IsEmpty)
                    _Methods = _DocumentMethods.Values.Array().SelectMany(x => x).Select(PdbServices.adapt);
                return _Methods.View;
            }
        }

        public ReadOnlySpan<Document> Documents
        {
            [MethodImpl(Inline)]
            get => _Documents.View;
        }
    }
}