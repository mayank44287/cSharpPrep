using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Carnival.DBL;

namespace Carnival.BLL
{
    public class Business
    {
        public int CheckCredentials(string Id, string pass, out string message)
        {
            message = "remove this later";
            int flag = 0;
            Console.WriteLine("asdasd");
            List<Login> tempList = ReadWriteFile.Read<Login>();
            Console.WriteLine("asdasdas");
            if (Id == "admin" & pass == "admin")
            {
                
                flag = 2;
                return flag;
            }
            else
            {
                try
                {
                    foreach (var item in tempList)
                    {
                        if (item.UserId == Id & item.Password == pass)
                        {
                            flag = 1;
                            return flag;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = "error..." + ex.Message;
                }
            }
            return flag;
        }



        public void AddMovie(int mId,string mName,string mDescr,int mPrice)
        {
            try
            {
                List<Movie> templist = ReadWriteFile.Read<Movie>();
                Movie mobj = new Movie();
                mobj.MovId = mId;
                mobj.MovName = mName;
                mobj.MovDescription = mDescr;
                mobj.price = mPrice;
                templist.Add(mobj);
                ReadWriteFile.Write<Movie>(templist);
            }
            catch (Exception ex)
            {
               string  message = "error" + ex.Message;
            }
        }

        public void ViewMovDetails()
        {
            string message;
            try
            {
                List<Movie> templist = ReadWriteFile.Read<Movie>();
                message = " ";
                foreach (var item in templist)
                {
                    Movie mobj = (Movie)item;
                    Console.WriteLine("Movie Id :   " + mobj.MovId);
                    Console.WriteLine("Movie Name :    " + mobj.MovName);
                    Console.WriteLine("Movie Description :  " + mobj.MovDescription);
                    Console.WriteLine("Price :   " + mobj.price);
                    Console.WriteLine("_______________________________________________________");
                }
            }
            catch (Exception ex)
            {
                message = "error" + ex.Message;
            }
        }

        public void DeleteMovie()
        {

        }

        public void CreateId(string id, string pass)
        {
            List<Login> templist = ReadWriteFile.Read<Login>();
            templist.Add(new Login { UserId = id, Password = pass});
            Console.WriteLine("{0} your id is created  ", id);
            ReadWriteFile.Write<Login>(templist);
        }

        public void ViewUser()
        {
            string message;
            try
            {
                List<Login> templist = ReadWriteFile.Read<Login>();
                foreach (var item in templist)
                {
                    Login obj = (Login)item;
                    Console.WriteLine("User Id :    " + obj.UserId);
                    Console.WriteLine("Password :   " + obj.Password);
                    Console.WriteLine("--------------------");
                }

            }
            catch (Exception ex)
            {

                message = "error ..." + ex.Message;
            }
           
        }

        public void RemoveUser(string delId)
        {
            string message = "error";
            List<Login> templist = ReadWriteFile.Read<Login>();
            try
            {
                foreach (var item in templist)
                {
                    Login obj = (Login)item;
                    if (obj.UserId == delId)
                    {
                        templist.Remove(obj);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                message = "error" + ex.Message;
              
            }
            //ReadWriteFile.LogCredentials = templist;
            ReadWriteFile.Write(templist);
            Console.WriteLine("User id {0} deleted", delId);
        }

        public void RemoveMovie(int movId)
        {
            string message = "error";
            List<Movie> templist = ReadWriteFile.Read<Movie>();
            try
            {
                foreach (var item in templist)
                {
                    Movie obj = (Movie)item;
                    if (obj.MovId == movId)
                    {
                        templist.Remove(obj);
                        break;
                    }

                }
            }
            catch(Exception ex)
            {
                message = "error" + ex.Message;
            }
            ReadWriteFile.Write<Movie>(templist);
            Console.WriteLine("Movie Removed");
            Console.WriteLine("-------------------------------");
            
        }

        public void ShowRequiredMovie(int mId)
        {
            string message = "error";
            List<Movie> templist = ReadWriteFile.Read<Movie>();
            foreach (var item in templist)
            {
                Movie mobj = (Movie)item;
                if (mobj.MovId == mId)
                {
                    Console.WriteLine("Movie Id " + mobj.MovId);
                    Console.WriteLine("Movie Name " + mobj.MovName);
                    Console.WriteLine("Movie Date " + mobj.date);
                    Console.WriteLine("Seats Left   "+mobj.SeatsLeft);
                    Console.WriteLine("-----------------------------");
                }
            }

        }

        public void BookTickets(int mId, int sId, int hr,int seats)
        {
            string message = "error";
            List<Movie> templist = ReadWriteFile.Read<Movie>();

            foreach (var item1 in templist)
            {
                Movie mobj = (Movie)item1;
                if (mobj.MovId == mId & mobj.ScreenId == sId & mobj.date.Hour == hr)
                {
                    if (mobj.SeatsLeft >= seats)
                    {
                        mobj.SeatsLeft -= seats;
                        Console.WriteLine("{0} seats booked", seats);
                    }
                    else
                    {
                        Console.WriteLine("{0} number of seats not available in this screen, try for another screen",seats);
                        Console.WriteLine("-------------------------------");
                        return;
                    }

                }   
            }
            ReadWriteFile.Write<Movie>(templist);
           
        }
    }
}
