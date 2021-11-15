//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using M = Microsoft.Extensions.DependencyModel;

    using static core;
    using static JsonDepsModel;

    using api = JsonDepsLoader;

    public class JsonDeps
    {
        readonly M.DependencyContext Source;

        readonly Index<M.CompilationLibrary> _CompilationLibraries;

        readonly Index<M.RuntimeLibrary> _RuntimeLibraries;

        readonly M.CompilationOptions _Options;

        readonly Index<M.RuntimeFallbacks> RuntimeGraph;

        internal JsonDeps(M.DependencyContext src)
        {
            Source = src;
            _CompilationLibraries = src.CompileLibraries.Array();
            _RuntimeLibraries = src.RuntimeLibraries.Array();
            _Options = src.CompilationOptions;
            RuntimeGraph = src.RuntimeGraph.Array();
        }

        public Options Options()
        {
            var dst = new Options();
            return api.extract(_Options, ref dst);
        }

        public TargetInfo Target()
        {
            var dst = new TargetInfo();
            return api.extract(Source, ref dst);
        }

        public ReadOnlySpan<RuntimeLibraryInfo> RuntimeLibs()
        {
            var count = _RuntimeLibraries.Count;
            if(count != 0)
            {
                var dst = sys.alloc<RuntimeLibraryInfo>(count);
                var src = _RuntimeLibraries;
                for(var i=0; i<count; i++)
                    api.extract(src[i], ref dst[i]);
                return dst;
            }
            else
            {
                return sys.empty<RuntimeLibraryInfo>();
            }
        }

        public Index<string> Graph
            => RuntimeGraph.SelectMany(x => x.Fallbacks);

        public ReadOnlySpan<LibraryInfo> Libs()
        {
            var count = _CompilationLibraries.Count;
            var dst = span<LibraryInfo>(count);
            var src = _CompilationLibraries.View;
            for(var i=0; i<count; i++)
                api.extract(src[i], ref dst[i]);
            return dst;
        }
    }
}