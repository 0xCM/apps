//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    using K = llvm.LlvmConfigKind;

    partial class LlvmRecordEtl
    {
        public LlvmConfig ComputeConfig()
        {
            const string Pattern = "llvm-config --{0}";
            var result = Outcome.Success;
            var options = Symbols.index<K>().View;
            var count = options.Length;
            var dst = new LlvmConfig();
            for(var i=0; i<count; i++)
            {
                ref readonly var option = ref skip(options,i);
                result = OmniScript.Run(string.Format(Pattern, option.Expr), out var response);
                if(result.Fail)
                    Write(result.Message);

                if(response.Length != 0)
                    etl.store(option, first(response), dst);
            }

            return dst;
        }
    }
}