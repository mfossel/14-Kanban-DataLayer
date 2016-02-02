using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _14_KanbanDataLayer
{
    class Program
    {
       


        static void Main(string[] args)
        {
           using (var db = new KanbanEntities1())
            {
              
                foreach (var list in db.lists)
                {
                    
                    Console.WriteLine(list.Name + "\n");
                    foreach (var card in list.Cards)
                    {
                        Console.WriteLine("\t" + card.Text);
                    }
                    Console.WriteLine("\n");
                }

                Console.WriteLine("Enter the name of the list you want to add: ");

                string listname = Console.ReadLine();

                var newie = db.Set<list>();
                newie.Add(new list { Name = listname, CreatedDate = DateTime.Now });
                db.SaveChanges();


                foreach (var list in db.lists)
                {

                    Console.WriteLine(list.Name + "\n");
                    foreach (var card in list.Cards)
                    {
                        Console.WriteLine("\t" + card.Text);
                    }
                    Console.WriteLine("\n");
                }





                Console.ReadLine();



            }
        }
    }
}
