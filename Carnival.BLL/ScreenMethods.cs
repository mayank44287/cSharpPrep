using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carnival.DBL;
using System.Data.SqlClient;


namespace Carnival.BLL
{
    public class ScreenMethods
    {
        List<Screen> templist = new List<Screen>();
        public List<Screen> ShowScreen()
        {
            try
            {
                templist = ReadWriteFile.Read<Screen>();
                return templist;
            }
            catch (Exception ex)
            {
                string message = "error " + ex.Message;
                return templist;
            }
        }

        public void AddScreen(int id, int capacity)
        {
            try
            {
                templist = ReadWriteFile.Read<Screen>();
                templist.Add(new Screen {ScreenId = id, Capacity = capacity });
                ReadWriteFile.Write(templist);
            }
            catch (Exception ex)
            {
                string message = "error " + ex.Message; 
            }
        }

        public void DeleteScreen(int screenId)
        {
            try
            {
                templist = ReadWriteFile.Read<Screen>();
                foreach (var item in templist)
                {
                    if (item.ScreenId == screenId)
                    {
                        templist.Remove(item);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = "error " + ex.Message;
            }
        }
    }
}
