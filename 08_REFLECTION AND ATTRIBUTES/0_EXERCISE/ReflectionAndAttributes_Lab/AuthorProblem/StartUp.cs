using System;

namespace AuthorProblem
{
    [Author("Desi")]
    public class StartUp
    {
        [Author("Desi")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
