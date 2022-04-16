//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedMachine
    {
        public CaptureState Captured()
        {
            var dst = new CaptureState();
            _Capture.Captured(dst);
            return dst;
        }

        public MachineCapture Capture
        {
            [MethodImpl(Inline)]
            get => _Capture;
        }

        public class MachineCapture
        {
            public static MachineCapture create(XedMachine machine)
                => new MachineCapture(machine);

            public void Captured(CaptureState dst)
            {
                dst.FormPatterns = _FormPatterns;
            }

            readonly XedMachine Machine;

            ConcurrentDictionary<InstForm,HashSet<InstPattern>> _FormPatterns = new();

            MachineCapture(XedMachine machine)
            {
                Machine = machine;
            }

            public void Clear()
            {
                _FormPatterns.Clear();
            }

            public void FormPatterns()
            {
                var src = Machine.FormPatterns;
                if(src.IsNonEmpty)
                {
                    ref readonly var form = ref src.First.InstForm;
                    FormPatterns(form, src);
                }
            }

            void FormPatterns(InstForm form, Index<InstPattern> src)
            {
                HashSet<InstPattern> add(InstForm form)
                    => hashset(src.Storage);

                HashSet<InstPattern> update(InstForm form, HashSet<InstPattern> bucket)
                {
                    bucket.AddRange(src);
                    return bucket;
                }

                _FormPatterns.AddOrUpdate(form, add, update);
            }
        }
    }
}