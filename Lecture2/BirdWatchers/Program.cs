namespace BirdWatchers {
    class Program {
        static void Main(string[] args) {
            var Bird = new Bird();
            var BirdWatcher = new BirdWatcher();
            var DeafBirdWatcher = new DeafBirdWatcher();
            var BlindBirdWatcher = new BlindBirdWatcher();
            Bird.birdAction += BirdWatcher.React;
            Bird.birdAction += DeafBirdWatcher.React;
            Bird.birdAction += BlindBirdWatcher.React;
            Bird.FireEvent();
        }
    }
}