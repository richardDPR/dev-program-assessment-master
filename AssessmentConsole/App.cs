using System;
using System.Linq;
using Assessment;

namespace AssessmentConsole
{
    public class App
    {
        public bool ProcessOption(string option) 
        {
            if (option == "1")
            {
                StartPagination();
                return false;
            }
            else if (option == "0")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Option Incorrect!");
                return false;
            }
            
        }

        private void StartPagination()
        {
            string option = GetOption(
                @"Pagination commands\n
                1. Source data
                0. Back
                ");
             if (option == "1")
             {
                ProcessPagination();
             }
        }

        private void ProcessPagination()
        {
            string option = GetOption(
                @"Type: \n
                1. Comma separated data(,)
                2. Pipe separated data(|)
                3. Space separated data( )
                0. Go Back
                ");
            if (option == "1" || option == "2" || option == "3") 
            {
                string data = GetOption("Source data");
                NavigateData(data, option);
            }
            // se saltaba a la primera pagina
            else if (option == "0" || option == null)
            {
                StartPagination();
            }
            else
            {
                Console.WriteLine("option incorrect!");
                ProcessPagination();
            }
       
        }

        private void NavigateData(string data, string option)
        { 
            string pageSize = GetOption("Type the Page size");
            if (pageSize != "")
            {
                IElementsProvider<string> provider = new StringProvider();
                IPagination<string> pagination = new PaginationString(data, int.Parse(pageSize), provider);
                DoNavigation(pagination);
            }
            else
            {
                Console.WriteLine("data incorrect!");

            }

        }

        private void DoNavigation(IPagination<string> pagination)
        {
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("Current Page:" + pagination);
                string option = GetOption(
                @"Type: \n
                1. First page
                2. Next page
                3. Previous page
                4. Last page
                5. Go to page
                0. Go Back
                ");
                if (option == "1") 
                {
                    pagination.FirstPage();
                    //pagination.LastPage();
                } 
                else if (option == "2")
                {
                    pagination.NextPage();
                    //exit = true;
                }
                else if (option == "3")
                {
                    pagination.PrevPage();
                }
                else if (option == "4")
                {
                    pagination.LastPage();
                }
                else if (option == "5")
                {
                    pagination.GoToPage(5);
                }
                else
                {
                    exit = true;
                }
            }
    
        }

        

        private string GetOption(string message)
        {
            Console.WriteLine(message);
            Console.Write(" > ");
            return Console.ReadLine();
            
            /*Console.WriteLine(message);
            Console.Write("> ");
            return Console.ReadLine();*/
        }
    }
}