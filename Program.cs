using CcatApi.Mapper;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CcatApi
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            using (HttpClient htpc = new HttpClient())
            {
                while (true)
                {
                    try
                    {
                        string Curl = await RequestCat(htpc, Linkables.CatLink);
                        await PostDisc(Linkables.DiscordWebh, Curl);

                        Console.ForegroundColor = ConsoleColor.DarkGray;

                        Console.WriteLine(" ");
                        Console.WriteLine(" [ = ]  ==========================  [ = ]");
                        Console.WriteLine($" [ CAT ] Request Posted, Sent to webhook, Sleeping for {Linkables.SleepTime}");
                        Console.WriteLine($" [ FORMAT ] Pulled Format Type, {Linkables.SerType}"); // Hash out if using RNG Search
                        Console.WriteLine($" [ WEBHOOK ] Sent Location, {Linkables.DiscordWebh}");
                        Console.WriteLine(" [ = ]  ==========================  [ = ]");
                        Console.WriteLine(" ");

                        Thread.Sleep(Linkables.SleepTime); // Sleeping For a good 15s to ensure to not get Ratelimited
                    }
                    catch (Exception cats)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($" [ MEOW ] Internal Error : {cats}");
                    }
                }
            }
        }



        #region Post Embed [ ## Discord Webhook] , Request Cats [ ## From catapi]
        static async Task<string> RequestCat(HttpClient htpc, string CatRQ)
        {
            HttpResponseMessage resp = await htpc.GetAsync(CatRQ);

            if (resp.IsSuccessStatusCode)
            {
                string con = await resp.Content.ReadAsStringAsync();
                JArray jsr = JArray.Parse(con);
                string Catimg = jsr[0]["url"].ToString();
                return Catimg;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new Exception($" [ MEOW ] Internal Error, API CODE : {resp.StatusCode}");
            }
        }
        static async Task PostDisc(string Dwebhok, string CatRQ)
        {
            using (HttpClient htpc = new HttpClient())
            {

                var payl = new
                {
                    content = "",
                    embeds = new[]
                    {
                    new
                    {
                        image = new
                        {
                            url = CatRQ
                        }
                    }
                }
                };

                string jsp = Newtonsoft.Json.JsonConvert.SerializeObject(payl);
                var con = new StringContent(jsp, System.Text.Encoding.UTF8, "application/json");
                await htpc.PostAsync(Dwebhok, con);
            }
        }
        #endregion

    }
}
