using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronPirate.PoseTheCat {
    public class EventsDefine {
        public static Action onPoseStart;
        public static Action onFitStart;
        public static Action<bool> onEndGame;
    }
}
