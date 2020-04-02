using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelLibrary;
using Newtonsoft.Json;

namespace ConsumeRest2020
{
    public class GuestModel
    {
        private const string URI = "http://localhost:50328/API/Guests";

        public void Start()
        {
            //List<Guest> gæster = await GetGuestsAsync();
            //gæster = await GetGuestsAsync();
            //foreach (Guest guest in gæster)
            //{
             //   Console.WriteLine("Gæster ::" + guest);
            //}
            //Console.WriteLine("Hent nr 5" + GetOneGuest(5));
            //Console.WriteLine("Slet gæst nr 100");
            //Console.WriteLine("gæst nr 100 er slettet" + DeleteGuests(100));
            //Hotel newGuest = new Guest(46, "Carl","MadGade 23");
            //bool ok = Post(newGuest);
            //Console.WriteLine("Har oprettet gæst 100::" + ok);

            //Hotel newUpdatetGuest = new Guest(100, "ZoomUpdateGuest100", "New BullVej 23");
            //bool ok = Put(101, newUpdatetGuest);
            //Console.WriteLine("Har opdateret Guest 100::" + ok);
        }

        //Alle gæster
        public async Task <List<Guest>> GetGuestsAsync()
        {
            List<Guest> gæster = new List<Guest>();
            using (HttpClient client = new HttpClient())
            {
                string stringAsync = await client.GetStringAsync(URI);
                gæster = JsonConvert.DeserializeObject<List<Guest>>(stringAsync);
            }

            return gæster;
        }

        //En gæst
        public Guest GetOneGuest(int id)
        {
            Guest guest = new Guest();
            using (HttpClient client = new HttpClient())
            {
                Task<string> stringAsync = client.GetStringAsync(URI + "/" + id);
                string jsonString = stringAsync.Result;
                guest = JsonConvert.DeserializeObject<Guest>(jsonString);
            }

            return guest;
        }

        //Delete
        public bool DeleteGuests(int id)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {
                Task<HttpResponseMessage> deleteAsync = client.DeleteAsync(URI + "/" + id);
                HttpResponseMessage resp = deleteAsync.Result;
                if (resp.IsSuccessStatusCode)
                {
                    string jsonstr = resp.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonstr);
                }
                else
                {
                    ok = false;
                }

            }

            return ok;
        }

        //Post
        public bool Post(Guest guest)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(guest);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> postAsync = client.PostAsync(URI, content);
                HttpResponseMessage resp = postAsync.Result;

                if (resp.IsSuccessStatusCode)
                {
                    string jsonstr = resp.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonstr);
                }
                else
                {
                    ok = false;
                }
            }

            return ok;
        }

        //Put
        public bool Put(int id, Guest guest)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(guest);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> putAsync = client.PutAsync(URI + "/" + id, content);
                HttpResponseMessage resp = putAsync.Result;

                if (resp.IsSuccessStatusCode)
                {
                    string jsonstr = resp.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonstr);
                }
                else
                {
                    ok = false;
                }
            }

            return ok;
        }
    }
}
