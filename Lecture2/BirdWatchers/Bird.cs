using System;

namespace BirdWatchers {
    class Bird {
        public Action<string> birdAction;

        public void FireEvent() {
            birdAction?.Invoke(
                new string[] {"Bird flaps wings", "Bird sings", "Bird does matting dance"}[new Random().Next(0, 2)]);
        }
    }
}