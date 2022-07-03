//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using M = Microsoft.Extensions.DependencyModel;

    using static core;
    using static JsonDepsModel;

    using api = JsonDeps;

    public class JsonDepsSources
    {
        readonly M.DependencyContext Source;

        readonly Index<M.CompilationLibrary> _CompilationLibraries;

        readonly Index<M.RuntimeLibrary> _RuntimeLibraries;

        readonly M.CompilationOptions _Options;

        readonly Index<M.RuntimeFallbacks> RuntimeGraph;

        internal JsonDepsSources(M.DependencyContext src)
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

        public Index<RuntimLib> RuntimeLibs()
        {
            var count = _RuntimeLibraries.Count;
            if(count != 0)
            {
                var dst = sys.alloc<RuntimLib>(count);
                var src = _RuntimeLibraries;
                for(var i=0; i<count; i++)
                    api.extract(src[i], ref dst[i]);
                return dst;
            }
            else
            {
                return sys.empty<RuntimLib>();
            }
        }

        public Index<JsonGraph> RuntimeFallbacks()
        {
            var src = RuntimeGraph;
            var count = src.Count;
            var dst = new JsonGraph();
            var nodes = list<JsonGraph>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var f = ref src[i];
                nodes.Add(new JsonGraph(f.Runtime, f.Fallbacks.Array()));
            }
            return nodes.ToIndex();
        }

        public Index<Library> Libs()
        {
            var count = _CompilationLibraries.Count;
            var dst = alloc<Library>(count);
            var src = _CompilationLibraries.View;
            for(var i=0; i<count; i++)
                api.extract(src[i], ref dst[i]);
            return dst;
        }
    }
}