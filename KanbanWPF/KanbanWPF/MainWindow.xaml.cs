using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace KanbanWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {


        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new KanbanEntities())
            {
                string data = "";
                foreach (var list in db.lists)
                {

                    data += list.Name + "\n";
                    foreach (var card in list.Cards)
                    {
                        data += card.Text;
                        data += "\n";                   }
                        data += "\n";
                }
                DataBlock.Text = data;

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new KanbanEntities())
            {
                string listname = NewListBox.Text;
                var newie = db.Set<list>();
                newie.Add(new list { Name = listname, CreatedDate = DateTime.Now });
                db.SaveChanges();
                NewListBox.Clear();
                MessageBox.Show("You have added a new list.");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new KanbanEntities())
            {
                int cardlistid = 0 ;
                string cardname = CardNameBox.Text;
                string cardlist = CardListBox.Text;
                var newie = db.Set<Card>();
                var listadd = db.lists.Where(u => u.Name == cardlist);
                foreach (var u in listadd)
                {
                    cardlistid = u.ListId;
                }

                newie.Add(new Card { Text = cardname, CreatedDate = DateTime.Now, ListId = cardlistid });
                db.SaveChanges();
                NewListBox.Clear();
                MessageBox.Show("You have added a new card.");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new KanbanEntities())
            {
                string deletecardname = DeleteCardBox.Text;
                var deletecard = db.Cards.Where(u => u.Text == deletecardname);
                foreach (var u in deletecard)
                {
                    db.Cards.Remove(u);
                }

                db.SaveChanges();
                DeleteCardBox.Clear();
                MessageBox.Show("You have deleted a card.");
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new KanbanEntities())
            {
                string deletelistname = DeleteListBox.Text;
                var deletelist = db.lists.Where(u => u.Name == deletelistname);
                foreach (var u in deletelist)
                {
                    db.lists.Remove(u);
                }

                db.SaveChanges();
                DeleteCardBox.Clear();
                MessageBox.Show("You have deleted a list");

            }
        }

       
    }
}