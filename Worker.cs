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
    public class Worker
    {
        private const string URI = "http://localhost:50328/API/Hotels";

        public async Task Start()
        {
            List<Hotel> hoteller = await GetHotelsAsync();
            hoteller = await GetHotelsAsync();
            foreach (Hotel hotel in hoteller)
            {
               Console.WriteLine("Hoteller ::" + hotel);
            }
            //Console.WriteLine("Hent nr 5" + GetOneHotels(5));
            //Console.WriteLine("Slet hotel nr 100");
            //Console.WriteLine("Hotel nr 100 er slettet" + DeleteHotels(100));
            //Hotel newHotel = new Hotel(101, "ZoomHotel", "BullVej 23");
            //bool ok = Post(newHotel);
            //Console.WriteLine("Har oprettet Hotel 101::" + ok);

            //Hotel newUpdatetHotel = new Hotel(101, "ZoomUpdateHotel101", "New BullVej 23");
            //bool ok = Put(101, newUpdatetHotel);
            //Console.WriteLine("Har opdateret Hotel 101::" + ok);
        }

        //Alle hoteller
        public async  Task <List<Hotel>> GetHotelsAsync()
        {
            List<Hotel> hoteller = new List<Hotel>();
            using (HttpClient client = new HttpClient())
            {
                string jsonString = await client.GetStringAsync(URI);
                hoteller = JsonConvert.DeserializeObject<List<Hotel>>(jsonString);
            }

            return hoteller;
        }

        //Et hotel
        public async Task<Hotel> GetOneHotelsAsync(int id)
        {
            Hotel hotel = new Hotel();
            using (HttpClient client = new HttpClient())
            {
                string stringAsync = await client.GetStringAsync(URI + "/" + id);
                hotel = JsonConvert.DeserializeObject<Hotel>(stringAsync);
            }

            return hotel;
        }


        //Delete
        public async Task<bool> DeleteHotelsAsync(int id)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage deleteAsync = await client.DeleteAsync(URI + "/" + id);
                if (deleteAsync.IsSuccessStatusCode)
                {
                    string jsonstr = deleteAsync.Content.ReadAsStringAsync().Result;
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
        public async Task<bool> PostAsync(Hotel hotel)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(hotel);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "Application/json");
                HttpResponseMessage postAsync = await client.PostAsync(URI, content);

                if (postAsync.IsSuccessStatusCode)
                {
                  string jsonstr = postAsync.Content.ReadAsStringAsync().Result;
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
        public async Task<bool> Put(int id, Hotel hotel)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(hotel);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "Application/json");
                HttpResponseMessage putAsync = await client.PutAsync(URI + "/" + id, content);

                if (putAsync.IsSuccessStatusCode)
                {
                    string jsonstr = putAsync.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonstr);
                }
                else
                {
                    ok = false;
                }
            }

            return ok;
        }

        public async Task<List<Guest>> GetGuestsAsync()
        {
            List<Guest> gæster = new List<Guest>();
            using (HttpClient client = new HttpClient())
            {
                string stringAsync = await client.GetStringAsync(URI);
                gæster = JsonConvert.DeserializeObject<List<Guest>>(stringAsync);
            }

            return gæster;
        }


        public async Task<bool> PostGuestAsync(Guest guest)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(guest);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                HttpResponseMessage postAsync = await client.PostAsync(URI, content);
                if (postAsync.IsSuccessStatusCode)
                {
                    string jsonStr = postAsync.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonStr);
                }
                else
                {
                    ok = false;
                }
            }
            return ok;
        }

        public async Task<bool> DeleteGuestAsync(int id)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage deleteAsync = await client.DeleteAsync(URI + "/" + id);
                if (deleteAsync.IsSuccessStatusCode)
                {
                    string jsonStr = deleteAsync.Content.ReadAsStringAsync().Result;
                    ok = JsonConvert.DeserializeObject<bool>(jsonStr);
                }
                else
                {
                    ok = false;
                }
            }
            return ok;
        }

        public async Task<bool> PutGuestAsync(int id, Guest guest)
        {
            bool ok = false;
            using (HttpClient client = new HttpClient())
            {
                string jsonString = JsonConvert.SerializeObject(guest);
                StringContent content = new StringContent(jsonString, Encoding.UTF8, "Application/json");
                HttpResponseMessage putAsync = await client.PutAsync(URI + "/" + id, content);

                if (putAsync.IsSuccessStatusCode)
                {
                    string jsonstr = putAsync.Content.ReadAsStringAsync().Result;
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
