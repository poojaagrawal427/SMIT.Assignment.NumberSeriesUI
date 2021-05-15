using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;

namespace SMIT.Assignment.Numbers
{
    public class Numbers : INumbers
    {
        public void GenerateSeries(long pEndNumber)
        {
            try
            {
                for (int i = 1; i <= pEndNumber; i++)
                {
                    List<string> tempList = new List<string>();
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        tempList.Add("Bingo!");
                    }
                    else if (i % 3 == 0)
                    {
                        tempList.Add((i * 3).ToString());

                    }
                    else
                    {
                        tempList.Add((i * 5).ToString());
                    }

                    NumberModel.Instance.Series = new ObservableCollection<string>(tempList);
                    System.Threading.Thread.Sleep(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
