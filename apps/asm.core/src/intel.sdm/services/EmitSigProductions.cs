//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    //public struct AsmSig

    partial class IntelSdm
    {
        Outcome EmitSigProductions(ReadOnlySpan<SdmOpCodeDetail> src, bool check = false)
        {
            var result = Outcome.Success;
            var sigs = SdmOps.sigs(src);
            var targets = sigs.UniqueTargets;
            var count = targets.Length;
            var buffer = text.buffer();
            var prods = alloc<AsmSigProduction>(count);
            for(var i=0; i<count; i++)
            {
                var sig = skip(targets,i).Sig;
                var sigx = SymbolizeExpression(sig);
                seek(prods,i) = new AsmSigProduction(sig, sigx);
            }

            var path = SdmPaths.SigProductions();
            var emitting = EmittingFile(path);
            Rules.emit(prods, path);
            EmittedFile(emitting, count);

            if(check)
            {
                result = ValidateSigs(prods);
            }
            return result;
        }

        Outcome ValidateSigs(ReadOnlySpan<AsmSigProduction> src)
        {
            var count = src.Length;
            var output = LoadSigProductions();
            var result = Outcome.Success;
            if(count != output.Count)
                result = (false,string.Format("Record count mismatch: {0} != {1}", count, output.Count));

            if(result.Fail)
                return result;

            for(var i=0; i<count; i++)
            {
                ref readonly var expect = ref src[i];
                ref readonly var actual = ref output[i];

                if(actual == null)
                {
                    result = (false, string.Format("Null production for '{0}'", expect.Source));
                    break;
                }

                if(actual.Source == null)
                {
                    result = (false, string.Format("Source for '{0}' is null",  expect.Source));
                    break;
                }

                if(!actual.Target.IsValid)
                {
                    result = (false, string.Format("Target for '{0}' is invalid",  expect.Target));
                    break;
                }

                if(!expect.Source.Content.Equals(actual.Source.Content))
                {
                    result = (false, string.Format("'{0}' != '{1}'",  expect.Source, actual.Source));
                    break;
                }

                if(actual.Target == null)
                {
                    result = (false, string.Format("Target for '{0}' is null",  expect.Target));
                    break;
                }

                if(!expect.Target.Format().Equals(actual.Target.Format()))
                {
                    result = (false, string.Format("'{0}' != '{1}'",  expect.Target, actual.Target));
                    break;
                }
            }
            return result;
        }
    }
}