using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskWithReturnResult
{
    /// <summary>
    /// The task can return a result. There is no direct mechanism to return the result from a thread.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var _rectangles = new List<Rectangle>()
            {
                new Rectangle(10,15),
                new Rectangle(6,14),
                new Rectangle(18,45),
                new Rectangle(3,8),
                new Rectangle(20,9),
                new Rectangle(30,4),
                new Rectangle(40,17),
                new Rectangle(3,25),
                new Rectangle(2,35),
                new Rectangle(1,28)
            };


            var task = new Task<Rectangle>(() => GetMaxPeremetrRect(_rectangles));
            task.Start();
            task.Wait();
            System.Console.WriteLine(task.Result.Peremetr());
            System.Console.ReadLine();

        }

        private static Rectangle GetMaxPeremetrRect(IList<Rectangle> rectangles)
        {
            if (rectangles.Count == 0)
                return default;

            var result = rectangles[0];
            foreach (var item in rectangles)
            {
                if (result.Peremetr() < item.Peremetr())
                    result = item;
            }

            return result;
        }
        
    }
    public class Rectangle
    {
        private double width;
        private double height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public double Peremetr()
        {
            return 2 * (width + height);
        }
    }
}
