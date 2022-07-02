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

    public sealed record class JsonGraph : Lineage<JsonGraph,string>
    {
        public JsonGraph()
            : base(EmptyString, sys.empty<string>())
        {

        }

        public JsonGraph(string node, string[] src)
        : base(node,src)
        {

        }

    }

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

        public Index<RuntimeLibraryInfo> RuntimeLibs()
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

        public Index<LibraryInfo> Libs()
        {
            var count = _CompilationLibraries.Count;
            var dst = alloc<LibraryInfo>(count);
            var src = _CompilationLibraries.View;
            for(var i=0; i<count; i++)
                api.extract(src[i], ref dst[i]);
            return dst;
        }
    }
}