//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public class AsmForms
    {
        public static AsmForm define(in AsmSig sig, in AsmOpCode opcode)
            => new AsmForm("x", sig, opcode);

        readonly Dictionary<string,List<AsmForm>> Data;

        readonly List<AsmForm> _Targets;

        readonly List<AsmForm> _UniqueTargets;

        public AsmForms()
        {
            Data = new();
            _Targets = new();
            _UniqueTargets = new();
        }

        public void Include(in AsmForm src)
        {
            var key = src.Sig.Format().ToLowerInvariant();
            if(Data.TryGetValue(key, out var dst))
                dst.Add(src);
            else
            {
                Data[key] = new();
                Data[key].Add(src);
                _UniqueTargets.Add(src);
            }
            _Targets.Add(src);
        }

        public AsmForm Include(in SdmOpCodeDetail src)
        {
            var result = AsmSigs.parse(src.Sig, out var sig);
            if(result.Fail)
                Errors.Throw(result.Message);

            result = AsmOpCodes.parse(src.OpCode, out var opcode);
            if(result.Fail)
                Errors.Throw(result.Message);

            var form = define(sig,opcode);
            var key = form.Sig.Format().ToLowerInvariant();
            if(Data.TryGetValue(key, out var dst))
                dst.Add(form);
            else
            {
                Data[key] = new();
                Data[key].Add(form);
                _UniqueTargets.Add(form);
            }
            _Targets.Add(form);
            return form;
        }

        public AsmForm this[uint index]
            => _Targets[(int)index];

        public AsmForm this[int index]
            => _Targets[(int)index];

        public uint SourceCount
            => (uint)Data.Count;

        public uint UniqueTargetCount
            => (uint)_UniqueTargets.Count;

        public uint TargetCount
            => (uint)_Targets.Count;

        public ReadOnlySpan<string> Sources
            => Data.Keys.Array();

        public ReadOnlySpan<AsmForm> Targets
            => _Targets.ViewDeposited();

        public ReadOnlySpan<AsmForm> UniqueTargets
            => _UniqueTargets.ViewDeposited();

        public bool Match(string sig, out List<AsmForm> dst)
            => Data.TryGetValue(sig, out dst);
    }
}