//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public class SdmSigDetails
    {
        public static SdmSigDetail define(in SdmOpCodeDetail src)
            => new SdmSigDetail(SdmOps.sig(src), new AsmOcExpr(src.OpCode));

        readonly Dictionary<string,List<SdmSigDetail>> Data;

        readonly List<SdmSigDetail> _Targets;

        readonly List<SdmSigDetail> _UniqueTargets;

        public SdmSigDetails()
        {
            Data = new();
            _Targets = new();
            _UniqueTargets = new();
        }

        public SdmSigDetail Include(in SdmOpCodeDetail src)
        {
            var sig = SdmOps.sig(src);
            var sd = define(src);
            var key = sd.Sig.Format().ToLowerInvariant();
            if(Data.TryGetValue(key, out var dst))
                dst.Add(sd);
            else
            {
                Data[key] = new();
                Data[key].Add(sd);
                _UniqueTargets.Add(sd);
            }
            _Targets.Add(sd);
            return sd;
        }

        public SdmSigDetail this[uint index]
            => _Targets[(int)index];

        public SdmSigDetail this[int index]
            => _Targets[(int)index];

        public uint SourceCount
            => (uint)Data.Count;

        public uint UniqueTargetCount
            => (uint)_UniqueTargets.Count;

        public uint TargetCount
            => (uint)_Targets.Count;

        public ReadOnlySpan<string> Sources
            => Data.Keys.Array();

        public ReadOnlySpan<SdmSigDetail> Targets
            => _Targets.ViewDeposited();

        public ReadOnlySpan<SdmSigDetail> UniqueTargets
            => _UniqueTargets.ViewDeposited();

        public bool Match(string sig, out List<SdmSigDetail> dst)
            => Data.TryGetValue(sig, out dst);
    }
}