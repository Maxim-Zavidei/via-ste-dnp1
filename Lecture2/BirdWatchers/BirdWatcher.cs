using System;

namespace BirdWatchers {
    class BirdWatcher {
        public void React(string birdAction) {
            Console.WriteLine("BirdWatcher: " + new string[] {"Ooh", "How nice", "Would you look at that"} [new Random().Next(0, 2)]);
        }
    }
}