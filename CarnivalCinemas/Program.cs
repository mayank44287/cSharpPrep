using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carnival.BLL;
using Carnival.DBL;

namespace CarnivalCinemas
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    MainMenu();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static void MainMenu()
        {
            string message = "erererererasdasda";
            Console.WriteLine("Here are your choices");
            Console.WriteLine("1. Log In");
            Console.WriteLine("2. Exit");
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter User Id");
                        string id = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        string pass = Console.ReadLine();
                        Business bobj = new Business();
                        int flag = bobj.CheckCredentials(id, pass, out message);
                        if (flag == 1)
                        {
                            Console.WriteLine("Login Successfull");
                            UserMenu();
                        }
                        if(flag == 2)
                        {
                            AdminMenu();
                        }
                        if(flag == 0)
                        {
                            Console.WriteLine("Wrong Credentials");
                        }
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }
            }
            catch(Exception ex)
            {
                message = "error..." + ex.Message;
            }
        }

        static void AdminMenu()
        {
            string message = "added";
            Console.WriteLine("1. Edit User Database");
            Console.WriteLine("2. Edit Movie Datbase");
            Console.WriteLine("3. Edit Screen Database");
            Console.WriteLine("4. Edit ShowTime Database");
            Console.WriteLine("5. Edit Show DataBase");
            Console.WriteLine("6. Back");
            int choice = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (choice)
                {
                    case 1:
                        UserDataBase();
                        AdminMenu();
                        break;

                    case 2:
                        MovieDataBase();
                        break;

                    case 3:
                        ScreenDataBase();
                        break;

                    case 4:
                        ShowTimeDataBase();
                        AdminMenu();
                        
                        break;

                    case 5:
                        
                        break;

                    case 6:
                        goto label;
                        break;
                }
            label:    return;
            }
            catch (Exception ex)
            {
                 message = "error" + ex.Message;

            }
            
        }

        static void MovieDataBase()
        {
            Console.WriteLine("1. View Movies");
            Console.WriteLine("2. Add Movie");
            Console.WriteLine("3. Delete Movie");
            Console.WriteLine("4. Back");
            int choice = Convert.ToInt32(Console.ReadLine());
            Business bobj = new Business();
            try
            {
                switch (choice)
                {
                    case 1:
                        bobj.ViewMovDetails();
                        MovieDataBase();
                        break;
                    case 2:
                        Console.WriteLine("Enter Movie Id");
                        int movId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Movie Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Movie Description");
                        string descr = Console.ReadLine();
                        Console.WriteLine("Enter the price");
                        int mPrice = Convert.ToInt32(Console.ReadLine());
                        bobj.AddMovie(movId, name, descr, mPrice);
                        MovieDataBase();
                        break;

                    case 3:
                        bobj.ViewMovDetails();
                        Console.WriteLine("enter the movie id");
                        int id = Convert.ToInt32(Console.ReadLine());
                        bobj.RemoveMovie(id);
                        MovieDataBase();
                        break;

                    case 4:
                        goto label;
                        break;
                }
                label: return;
            }
            catch(Exception ex)
            {
                string message = "error" + ex.Message;
            }
        }

        static void ScreenDataBase()
        {
            Console.WriteLine("1. View Screens");
            Console.WriteLine("2. Add Screen");
            Console.WriteLine("3. Delete Screen");
            Console.WriteLine("4. Back");
            try
            {
            int choice = Convert.ToInt32(Console.ReadLine());
            ScreenMethods scobj = new ScreenMethods();
            List<Screen> templist = new List<Screen>();
            int screenId = 0;
                switch (choice)
                {
                    case 1:
                        templist = scobj.ShowScreen();
                        foreach (var item in templist)
                        {
                            Console.WriteLine("Screen Id " + item.ScreenId);
                            Console.WriteLine("Screen Capacit " + item.Capacity);
                        }
                        ScreenDataBase();
                        break;

                    case 2:
                        Console.WriteLine("enter the screen id");
                        screenId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the Screen Capacity");
                        int capacity = Convert.ToInt32(Console.ReadLine());
                        scobj.AddScreen(screenId, capacity);
                        ScreenDataBase();
                        break;

                    case 3:
                        Console.WriteLine("enter the screen id to delete");
                        screenId = Convert.ToInt32(Console.ReadLine());
                        ScreenDataBase();
                        break;

                    case 4:
                        goto label;
                        break;

                    default:
                        break;
                }
            label: return;
            }
            catch (Exception ex)
            {
                string message = "error " + ex.Message;
            }
        }

        static void ShowTimeDataBase()
        {
            Console.WriteLine("1. View Show time");
            Console.WriteLine("2. Add Show time");
            Console.WriteLine("3. Delete Show time");
            Console.WriteLine("4. Back");
            try
            {
                List<Timings> templist = new List<Timings>();
                ShowTimeMethods stobj = new ShowTimeMethods();
                int showTimeId = 0;
                string message = " ";
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        templist = stobj.ShowTime();
                        foreach (var item in templist)
                        {
                            Console.WriteLine("ShowTimeId " + item.ShowTimeId);
                            Console.WriteLine("Show Time  " + item.ShowTime);
                        }
                        ScreenDataBase();
                        break;

                    case 2:
                        Console.WriteLine("enter show id");
                        showTimeId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter show hour");
                        string hour = Console.ReadLine();
                        stobj.AddShowTime(showTimeId,hour);
                        ShowTimeDataBase();
                        break;

                    case 3:
                        Console.WriteLine("enter the show time id");
                        showTimeId = Convert.ToInt32(Console.ReadLine());
                        stobj.DeleteShowTime(showTimeId,out message);
                        ShowTimeDataBase();
                        break;

                    case 4:
                        goto label;
                        break;
                    
                }
            label: return;
            }
            catch (Exception ex)
            {
                string message = "error " + ex.Message;
            }
        }

        static void UserDataBase()
        {
            string message = "error";
            Console.WriteLine("1. View user database");
            Console.WriteLine("2. Add User");
            Console.WriteLine("3. Remove User");
            Console.WriteLine("4. Back");
            int choice = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (choice)
                {
                    case 1:
                        Business b2obj = new Business();
                        b2obj.ViewUser();
                        UserDataBase();
                        break;

                    case 2:
                        Console.WriteLine("enter user Id");
                        string id = Console.ReadLine();
                        Console.WriteLine(("enter password"));
                        string pass = Console.ReadLine();
                        Business bobj = new Business();
 
                        bobj.CreateId(id, pass);
                        UserDataBase();
                        break;
                    case 3:
                        Business bobj3 = new Business();
                        Console.WriteLine("enter the User Id");
                        string delId = Console.ReadLine();
                        bobj3.RemoveUser(delId);
                        UserDataBase();
                        break;

                    case 4:
                        goto label;
                        break;
                    
                 }
            }
            catch (Exception ex)
            {
                message = "error..." + ex.Message;   
            }
            label: return;
        }

        static void UserMenu()
        {
            string message = "error";
            Business bobj = new Business();
            Console.WriteLine("1. Show Details");
            Console.WriteLine("2. Book Tickets");
            Console.WriteLine("3. Back");
            int choice = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (choice)
                {
                    case 1:
                        bobj.ViewMovDetails();
                        UserMenu();
                        break;

                    case 2:
                        Business b1obj = new Business();
                        Console.WriteLine("enter movie id ");
                        int mId = Convert.ToInt32(Console.ReadLine());
                        b1obj.ShowRequiredMovie(mId);
                        Console.WriteLine("enter screen Id");
                        int sId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("enter the time");
                        int hr = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("No of seats");
                        int seats = Convert.ToInt32(Console.ReadLine());
                        b1obj.BookTickets(mId,sId,hr,seats);
                        UserMenu();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                message = "error" + ex.Message;
            }
            
           

    
        }


    }
}
