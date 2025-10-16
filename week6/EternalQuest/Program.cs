class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🎮 Welcome to ETERNAL QUEST! 🎮");
        Console.WriteLine("Track your goals and earn points for personal growth!\n");

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
