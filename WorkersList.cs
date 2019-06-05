using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Records
{
    public class WorkersList
    {
        List<Worker> personsList;
        Department department;

        public WorkersList(Department _department)
        {
            department = _department;
            personsList = new List<Worker>();
        }

        public bool ShowList()
        {
            Console.WriteLine(Worker.ColumnsHeading(department));
            personsList.Sort();

            foreach (var worker in personsList)
            {
                Console.WriteLine(worker.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Random key - save counted data, Esc - exit witout save");
            ConsoleKeyInfo key = Console.ReadKey(true);

            return (key.Key != ConsoleKey.Escape);
        }

        public void Read(string path)
        {
            StreamReader sr = null;
            FileStream fs = null;

            try
            {
                if (File.Exists(path))
                {
                    string line = null;

                    fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                    sr = new StreamReader(fs);

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] tab = line.Split(';');
                        if (CorrectData(tab))
                        {
                            if (department == Department.seller)
                            {
                                personsList.Add(new Seller(tab));
                            }
                            else if (department == Department.driver)
                            {
                                personsList.Add(new Driver(tab));

                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (sr !=null)
            {
                sr.Close();
            }
        }

        public void Save(string path)
        {
            StreamWriter sw = null;
            FileStream fs = null;

            try
            {
                fs = File.Create(path);
                sw = new StreamWriter(fs);
                foreach (var worker in personsList)
                {
                    sw.WriteLine(worker.TextToFile());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (sw != null)
            {
                sw.Close();
            }
        }

        private bool CorrectData(string[] tab)
        {
            bool correctData = false;
            double tmp;

            if (tab.Length == 5 && double.TryParse(tab[2], out tmp) && 
                double.TryParse(tab[3], out tmp) && double.TryParse(tab[4], out tmp))
            {
                correctData = true;
            }

            return correctData;
        }
    }
}