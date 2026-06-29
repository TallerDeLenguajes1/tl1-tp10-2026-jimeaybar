using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            string url = "https://pokeapi.co/api/v2/pokemon/pikachu";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(json);

                Console.WriteLine("=== INFORMACIÓN DEL POKÉMON ===\n");

                Console.WriteLine($"ID: {pokemon.id}");
                Console.WriteLine($"Nombre: {pokemon.name}");
                Console.WriteLine($"Altura: {pokemon.height}");
                Console.WriteLine($"Peso: {pokemon.weight}");

                File.WriteAllText("pokemon.json", json);

                Console.WriteLine("\nArchivo pokemon.json guardado correctamente.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error.");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
