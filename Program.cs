using System.Security.Principal;
using MovieManagementApp.Models;

namespace MovieManagementApp
{
    internal class Program
    {
        public static List<Movie> movies = new List<Movie>();
        
        static void Main(string[] args)
        {
            string creater = "SarojKumar";
            while (true)
            {
                Console.WriteLine($"Welcome to movie store developed by : {creater}\n" +
                    $"What do you wise to do ?\n" +
                    $"1.Add New Movie \n" +
                    $"2.Display All Movies\n" +
                    $"3.Find Movie by Id \n" +
                    $"4.Remove an Movie By Id\n" +
                    $"5.Clear all Movies \n" +
                    $"6.Exit \n"
                    );
                int choice = Convert.ToInt32(Console.ReadLine());
                DoTask(choice);
            }
        }
        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddMovie();
                    break;
                case 2:
                    DisplayAllMovies();
                    break;
                case 3:
                    FindMovie();
                    break;
                case 4:
                    RemoveMovie();
                    break;
                case 5:
                    ClearAllMovies();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter a valid input.");
                    break;
            }
        }
        static void AddMovie()
        {
            if(movies.Count==5)
            {
                Console.WriteLine("Capacity Over ! You can not add New Movie ..\n");
            }
            else
            {
                Console.WriteLine("Enter Id : ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Movie Number : ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Year of release : ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Genre : ");
                string genre = Console.ReadLine();
                movies.Add(Movie.AddNewMovie(id, name, year, genre));
                Console.WriteLine("Your Movie is created successfully !\n");
            }
        }
        static void DisplayAllMovies()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("There is no Movie to display ! \n");
            }
            else
                movies.ForEach(item => Console.WriteLine(item));
        }
        static void FindMovie()
        {
            Movie findID = FindID();
            if (findID != null)
                Console.WriteLine(findID);
            else
                Console.WriteLine("Movie not found\n");
        }
        static void RemoveMovie()
        {
            Movie findID = FindID();
            if (findID != null)
            {
                movies.Remove(findID);
                Console.WriteLine("Your Movie is removed successfully !\n");
            }
            else
                Console.WriteLine("Movie not found\n");
        }
        static void ClearAllMovies()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("There is no Movie to Clear ! \n");
            }
            else
                movies.Clear();
        }



        static Movie FindID()
        {
            Console.WriteLine("Enter the ID : ");
            int id = Convert.ToInt32(Console.ReadLine());
            return movies.Where(item => item.Id == id).FirstOrDefault();
        }
    }
}
