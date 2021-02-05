using System;

namespace Day8DemoCNCToolList
{
    class Program
    {
        static void Main(string[] args)
        {
            var tool0 = new CNCTool();
            var tool1 = new CNCTool(1,"Endmill #1","Flat",4.0f,.5f,1.5f);
            var tool2 = new CNCTool(2, "Endmill #2", "Round", 4.5f, .33f, 2f, 1000, 10, 2);
            Console.WriteLine(tool0.ToString() + " created!");
            Console.WriteLine(tool1.ToString() + " created!");
            Console.WriteLine(tool2.ToString() + " created!");

        }
    }
}
