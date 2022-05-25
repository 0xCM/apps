//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;

    partial class CheckCmd
    {
        [CmdOp("memory/emit")]
        Outcome EmitMemory(CmdArgs args)
        {
            var dst = ProjectDb.LogTable<ProcessMemoryRegion>();
            AppSvc.TableEmit(ImageMemory.regions().View, dst);
            return true;
        }

        [CmdOp("memory/dump")]
        void EmitDump()
        {
            Wf.RuntimeServices().EmitContext();
        }

        [CmdOp("native/check")]
        Outcome CheckNativeTypes(CmdArgs args)
        {
            try
            {
                RunNativeChecks();
                return true;
            }
            catch(Exception e)
            {
                return e;
            }
        }

        void RunNativeChecks()
        {
            var t0 = NativeTypes.seg(NativeSegKind.Seg128x16i);
            Write(t0.Format());

            var t1 = NativeTypes.seg(NativeSegKind.Seg16u);
            Write(t1.Format());

            CheckNativeAlloc();
        }


        void CheckNativeAlloc()
        {
            var n = n16;
            var count = Numbers.count(n);
            byte length = (byte)n;
            var result = Outcome.Success;
            using var native = NativeCells.alloc<string>(count, out var id);
            var bits = PolyBits.bitstrings(n);
            for(var i=0u; i<count; i++)
            {
                var offset = i*n;
                native.Content(i) = new string(slice(bits, offset, n));
            }
        }

        [CmdOp("check/api/metadata")]
        Outcome CheckMetadata(CmdArgs args)
        {
            CheckMetadata(PartId.Lib);
            return true;
        }

        [CmdOp("check/ancestry")]
        void CheckAncestors()
        {
            AncestryChecks.create(Wf).Run();
        }

        void CheckMetadata(PartId part)
        {
            var tool = Wf.Roslyn();

            if(ApiRuntimeCatalog.FindComponent(part, out var assembly))
            {
                var name = string.Format("z0.{0}.compilation", part.Format());
                var metadata = SourceSymbolic.metaref(assembly);
                var comp = tool.Compilation(name, metadata);
                var symbol = comp.GetAssemblySymbol(metadata);
                var gns = symbol.GlobalNamespace;
                var types = gns.GetTypes();
                iter(types, show);
            }

            void show(CaSymbolModels.TypeSymbol src)
            {
                Write(src);
                var members = src.GetMembers();
                var count = members.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var member = ref skip(members,i);
                    var desc = string.Format("{0}", member.Format());
                    var locations = member.Locations;
                    if(locations.Length != 0)
                    {
                        ref readonly var loc = ref first(locations);
                        if(loc != null)
                        {
                            desc += string.Format("{0} {1}", desc, loc.ToString());
                        }
                    }

                    Write(desc);
                }
            }
        }
    }
}