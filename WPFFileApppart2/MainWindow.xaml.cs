using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace WPFFileApppart2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void checkIfFileExists_Click(object sender, RoutedEventArgs e)
        {
            string searchPath = folderSearchTxtBox.Text + "\\";
            string itemSearch = $"{itemSearchTxtBox.Text}";

            string searchItem = $"{searchPath}{itemSearch}";

            outPutWindowTxtBox.Text = searchItem;

            if (itemSearchTxtBox.Text == "")
            {
                MessageBox.Show($"The Item SearchBox CAN NOT Be empty. Please try again...");
                itemSearchTxtBox.Text = "";
                outPutWindowTxtBox.Text = "";
            }
            else if (!File.Exists($"{searchPath}{itemSearch}"))
            {
                outPutWindowTxtBox.Text = $"NO the file you searched for: {itemSearch}\n ||Does NOT Exits||";
            }
            else
            {
                outPutWindowTxtBox.Text = $"Congradulations! The File you searched for: {itemSearch}\n ||Does Exits||";
            }
        }

        private void deleteFile_Click(object sender, RoutedEventArgs e)
        {
            string searchPath = folderSearchTxtBox.Text + "\\";
            string itemSearch = $"{itemSearchTxtBox.Text}";
            string searchItem = $"{searchPath}{itemSearch}";

            if (itemSearchTxtBox.Text == "")
            {
                MessageBox.Show($"The Item SearchBox CAN NOT Be empty. Please try again...");
                itemSearchTxtBox.Text = "";
                outPutWindowTxtBox.Text = "";
            }
            else
            {
                outPutWindowTxtBox.Text = searchItem;
                outPutWindowTxtBox.Text = $"The File you selected for delection: ||{itemSearch}|| --will now be Deleted\n";
                File.Delete(searchItem);
                outPutWindowTxtBox.Text += $"||{itemSearch}|| --has been deleted.\rWhy not try the `Check if file exists` button to verify!";
            }
        }

        private void ddoesDirectoryExist_Click(object sender, RoutedEventArgs e)
        {
            string searchPath = folderSearchTxtBox.Text + "\\";
            string itemSearch = $"{itemSearchTxtBox.Text}";
            string searchItem = $"{searchPath}{itemSearch}";
            outPutWindowTxtBox.Text = searchItem;

            if(itemSearchTxtBox.Text == "")
            {
                MessageBox.Show($"The Item SearchBox CAN NOT Be empty. Please try again...");
                itemSearchTxtBox.Text = "";
            }
            else if (!Directory.Exists($"{searchPath}{itemSearch}"))
            {
                outPutWindowTxtBox.Text = $"NO the Directory you searched for: {itemSearch}\n ||Does NOT Exits||";
            }
            else
            {
                outPutWindowTxtBox.Text = $"The Directory you searched for: {itemSearch}\n ||Congrats!! It DOES Exit||";
            }
        }

        private void fileExtention_Click(object sender, RoutedEventArgs e)
        {
            string searchPath = folderSearchTxtBox.Text + "\\";
            string itemSearch = $"{itemSearchTxtBox.Text}";
            string searchItem = $"{searchPath}{itemSearch}";
            string txt = ".txt";
            string jpg = ".jpg";
            outPutWindowTxtBox.Text = searchItem;


            if (itemSearchTxtBox.Text == "")
            {
                MessageBox.Show($"The Item SearchBox CAN NOT Be empty. Please try again...");
                itemSearchTxtBox.Text = "";
                outPutWindowTxtBox.Text = "";
            }
            else
            {
                outPutWindowTxtBox.Text = searchItem;

                if (searchItem.Contains(".txt"))
                {
                    outPutWindowTxtBox.Text = $"The Extention of the File you selected : {itemSearch} \nhas an extention of :{txt}";
                }
                else if (searchItem.Contains(".jpg"))
                {
                    outPutWindowTxtBox.Text = $"The Extention of the File you selected : {itemSearch} \nhas an extention of :{jpg}";
                }
            }
        }

        private void createDirectory_Click(object sender, RoutedEventArgs e)
        {
            string searchPath = folderSearchTxtBox.Text + "\\";
            string itemSearch = $"{itemSearchTxtBox.Text}";
            string searchItem = $"{searchPath}{itemSearch}";
            outPutWindowTxtBox.Text = searchItem;

            if (itemSearchTxtBox.Text == "")
            {
                MessageBox.Show($"The Item SearchBox CAN NOT Be empty. Please try again...");
                itemSearchTxtBox.Text = "";
            }
            else if (Directory.Exists($"{searchPath}{itemSearch}"))
            {
                outPutWindowTxtBox.Text = $"Directory {searchItem} Already exists. \nNothing new to create.\r";
                Directory.CreateDirectory(searchItem);
                //outPutWindowTxtBox.Text += $"The requested directory: {itemSearch} -- Has been Created! \nThis request has been completed! \nWhy not try the `Does Directory Exist` Button to Verify!";
            }
            else
            {
                outPutWindowTxtBox.Text = $"Directory: {searchItem} \ndoes NOT currently exist. \nWill now create the requested directory!\r";
                Directory.CreateDirectory(searchItem);
                outPutWindowTxtBox.Text += $"The requested directory: {itemSearch} -- Has been Created! \nThis request has been completed! \nWhy not try the `Does Directory Exist` Button to Verify!";
            }
        }

        private void filesInDirectory_Click(object sender, RoutedEventArgs e)
        {
            string searchPath = folderSearchTxtBox.Text + "\\";
            string itemSearch = $"{itemSearchTxtBox.Text}";
            string searchItem = $"{searchPath}{itemSearch}";
            
            DirectoryInfo directoryInfo = new DirectoryInfo(searchPath);
            FileInfo[] files = directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly);
            outPutWindowTxtBox.Text = $"{files.Length.ToString()} --Total number of files in Folder!";
        }

        private void findSubDirectories_Click(object sender, RoutedEventArgs e)
        {
            string searchPath = folderSearchTxtBox.Text + "\\";
            string itemSearch = $"{itemSearchTxtBox.Text}";
            string searchItem = $"{searchPath}{itemSearch}";

            string[] directories = Directory.GetDirectories(searchPath, "*", SearchOption.TopDirectoryOnly);

            foreach (string dir in directories)
            {
                outPutWindowTxtBox.Text += $"{dir}\n";
            }
        }

        private void moveDirectory_Click(object sender, RoutedEventArgs e)
        {
            //string searchPath = folderSearchTxtBox.Text + "\\";
            string searchPath = folderSearchTxtBox.Text;
            string itemSearch = $"{itemSearchTxtBox.Text}";
            string searchItem = $"{searchPath}{itemSearch}";
            
            string sourceFile = folderSearchTxtBox.Text;
            string destinationFile = itemSearchTxtBox.Text;
            Directory.Move(sourceFile, destinationFile);

            //if (itemSearchTxtBox.Text == "")
            //{
            //    MessageBox.Show($"The Item SearchBox/Destination Location Line CAN NOT Be empty. \nPlease try again or add the missing information...");
            //    itemSearchTxtBox.Text = "";
            //}
            //else if (!Directory.Exists($"{itemSearch}"))
            //{
            //    outPutWindowTxtBox.Text = $"{itemSearch}\rThat location does not exits. \nSince this is a move, please provide a legitamate move location.";
            //}
            //else
            //{
            //    Directory.Move(searchPath, itemSearch);
            //}

        }

        private void deleteDirectory_Click(object sender, RoutedEventArgs e)
        {
            string searchPath = folderSearchTxtBox.Text + "\\";
            string itemSearch = $"{itemSearchTxtBox.Text}";
            string searchItem = $"{searchPath}{itemSearch}";

            if (itemSearchTxtBox.Text == "")
            {
                MessageBox.Show($"The Item SearchBox CAN NOT Be empty. Please try again...");
                itemSearchTxtBox.Text = "";
            }
            else if (!Directory.Exists($"{searchItem}"))
            {
                outPutWindowTxtBox.Text = $"Directory {searchItem} does NOT currently exist. \nThere is currenly no folder/directory to be deleted. Please try again\r";
            }
            else
            {
                Directory.Delete(searchItem);
                outPutWindowTxtBox.Text = $"The requested directory: {itemSearch} -- Has been Deleted! \nThis request has been completed! \nWhy not try the `Does Directory Exist` Button to Verify the deletion!";
            }
        }

        private void fndFileType_Click(object sender, RoutedEventArgs e)
        {
            string searchPath = folderSearchTxtBox.Text + "\\";
            string itemSearch = $"{itemSearchTxtBox.Text}";
            string searchItem = $"{searchPath}{itemSearch}";
            string txt = "*.txt";

            // FileInfo[] fileInfo = GetFilesFromFolder(@"C:\Test", (extension == "") ? "txt" : extension);
            string[] files = Directory.GetFiles(searchPath, "*.txt", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                outPutWindowTxtBox.Text += $"{file}\n";
            }
        }
        private void moveFile_Click(object sender, RoutedEventArgs e)
        {


            string searchPath = folderSearchTxtBox.Text;
            string itemSearch = $"{itemSearchTxtBox.Text}";
            string searchItem = $"{searchPath}{itemSearch}";

            string sourceFile = folderSearchTxtBox.Text;
            string destinationFile = itemSearchTxtBox.Text;
            File.Move(sourceFile, destinationFile);

            //string sourcePath = folderSearchTxtBox.Text + "\\";
            //string destinationItem = $"{itemSearchTxtBox.Text}";
            //string searchItem = $"{sourcePath}{destinationItem}";

            //if (itemSearchTxtBox.Text == "")
            //{
            //    MessageBox.Show($"The Item SearchBox CAN NOT Be empty. Please try again...");
            //    itemSearchTxtBox.Text = "";
            //}
            //else
            //{
            //    File.Move(sourcePath, searchItem);
            //}
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
