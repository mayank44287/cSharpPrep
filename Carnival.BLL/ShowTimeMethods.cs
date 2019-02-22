using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carnival.DBL;
namespace Carnival.BLL
{
    public class ShowTimeMethods
    {
        List<Timings> templist = new List<Timings>();

        public List<Timings> ShowTime()
        {
            try
            {
                templist = ReadWriteFile.Read<Timings>();
                return templist;
            }
            catch (Exception ex)
            {
                string message = "error " + ex.Message;
                return templist;
            }
        }

        public void AddShowTime(int id,string showHour)
        {
            try
            {
                int flag = 0;
                templist = ReadWriteFile.Read<Timings>();
                templist.Add(new Timings { ShowTimeId = id, ShowTime = showHour });
                ReadWriteFile.Write(templist);
            }
            catch (Exception ex)
            {

                string message = "error " + ex.Message;
            }
        }

        public void DeleteShowTime(int id,out string message)
        {
            message = " ";
            try
            {
                templist = ReadWriteFile.Read<Timings>();
                foreach (var item in templist)
                {
                    if (item.ShowTimeId == id)
                    {
                        templist.Remove(item);
                    }
                    else
                    {
                        message = "not found";
                    }
                }
            }
            catch (Exception ex)
            {
                message = "error " + ex.Message;
            }
        }


    }
}
