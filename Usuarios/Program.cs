using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Usuarios
{
    class Program
    {
        // Cliente HTTP para realizar la petición
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/users/";

            try
            {
                // Realiza la petición GET
                HttpResponseMessage response = await client.GetAsync(url);

                // Verifica que la respuesta sea correcta
                response.EnsureSuccessStatusCode();

                Console.WriteLine(response.StatusCode);
                // Lee el contenido JSON
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);

                // Convierte el JSON en una lista de objetos Usuario
                List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);

                Console.WriteLine("PRIMEROS CINCO USUARIOS\n");

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Usuario {i + 1}");
                    Console.WriteLine($"Nombre : {usuarios[i].name}");
                    Console.WriteLine($"Email  : {usuarios[i].email}");

                    Console.WriteLine("Domicilio:");
                    Console.WriteLine($"Calle : {usuarios[i].address.street}");
                    Console.WriteLine($"Ciudad: {usuarios[i].address.city}");

                    Console.WriteLine("------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error:");
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}

/*using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Usuarios;
class Program
{

    static async Task Main(string[] args)
    {
        // Cliente HTTP para realizar la petición
        HttpClient clienteHttp = new HttpClient();
        const string urlApi = "https://jsonplaceholder.typicode.com/users/";
        const string archivoSalida = "usuarios.json";
        JsonSerializerOptions opcionesJson = new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        // Realiza la petición GET
        HttpResponseMessage respuesta = await clienteHttp.GetAsync(urlApi);

        // Verifica que la respuesta sea correcta
        respuesta.EnsureSuccessStatusCode();

        // Lee el contenido JSON
        string jsonCrudo = await respuesta.Content.ReadAsStringAsync();

        // Convierte el JSON en una lista de objetos Usuario
        List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonCrudo, opcionesJson);

        Console.WriteLine("PRIMEROS CINCO USUARIOS\n");

        foreach(Usuario usuario in usuarios)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Usuario {i + 1}");
                Console.WriteLine($"Nombre : {usuario.nombre}");
                Console.WriteLine($"Email  : {usuario.email}");

                Console.WriteLine("Domicilio:");
                Console.WriteLine($"Calle : {usuario.direccion.calle}");
                Console.WriteLine($"Ciudad: {usuario.direccion.ciudad}");

                Console.WriteLine("------------------------------");
            }
        }

        string jsonGuardado = JsonSerializer.Serialize(usuarios, opcionesJson);
        await File.WriteAllTextAsync(archivoSalida, jsonGuardado);

    }
}*/

