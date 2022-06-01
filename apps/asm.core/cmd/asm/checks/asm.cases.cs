//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("asm/cases/emit")]
        Outcome EmitAsmCases(CmdArgs args)
        {
            var src = AsmCases.mov();
            AppSvc.TableEmit(src, AppDb.ApiTargets().Table<AsmEncodingCase>());

            return true;
        }

        [CmdOp("asm/check/tokens")]
        void CheckAsmTokens()
        {
            var group = AsmSigTokens.create();
            var src = group.Set;
            var types = src.TokenTypes;
            for(var i=0; i<types.Length; i++)
            {
                var tokens = src.Tokens(skip(types,i));
                for(var j=0;j<tokens.Count; j++)
                {
                    ref readonly var token = ref tokens[j];
                    Write(token.Format());
                }
            }
        }
    }
}