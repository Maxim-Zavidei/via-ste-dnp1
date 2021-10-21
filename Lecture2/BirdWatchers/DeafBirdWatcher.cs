using System;

namespace BirdWatchers {
    class DeafBirdWatcher {
        public void React(string birdAction) {
            if (birdAction != "Bird sings") Console.WriteLine("DeafBirdWatcher: " + new string[] {"Ooh", "How nice", "Would you look at that"} [new Random().Next(0, 2)]);
        }
    }
}