using System;

namespace BirdWatchers {
    class BlindBirdWatcher {
        public void React(string birdAction) {
            if (birdAction == "Bird sings") Console.WriteLine("BlindBirdWatcher: " + new string[] {"Ooh", "How nice"} [new Random().Next(0, 1)]);
        }
    }
}