//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    [Free]
    public unsafe class MemCmd : CmdService<MemCmd>
    {
        [CmdOp("mem/show")]
        Outcome ShowMemHex(CmdArgs args)
        {
            var address = MemoryAddress.Zero;
            var result = DataParser.parse(arg(args,0), out address);
            if(result)
            {

                var size = 16u;
                if(args.Count >= 2)
                    result = DataParser.parse(arg(args,1), out size);

                if(result)
                {
                    ref readonly var src = ref address.Ref<byte>();
                    var data = Refs.cover(src,size);
                    var hex = data.FormatHex();
                    Write(string.Format("{0,-16}: {1}", address, hex));
                }

            }
            return result;
        }

        [CmdOp("mem/modules")]
        void ListModules()
        {
            var src = ImageMemory.modules();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var module = ref skip(src,i);
                var @base = module.BaseAddress;
                var size = module.ModuleMemorySize;
                Write(string.Format("{0:D3} | {1,-16} | {2,-16} | {3}",i,  @base, size, module.Path.ToUri()));
            }
        }
    }
}