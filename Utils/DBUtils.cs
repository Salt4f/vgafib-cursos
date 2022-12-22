using System.Text;
using System.Text.Json;
using VGAFIBCursos.Data;
using VGAFIBCursos.Models;

namespace VGAFIBCursos.Utils
{
    public class DBUtils
    {

        public static async Task InitDB(DataContext context)
        {

            var cartel = await File.ReadAllBytesAsync("database-init/cartel.png");
            var base64 = Convert.ToBase64String(cartel);

            var cursoStr = await File.ReadAllTextAsync("database-init/curso.json", Encoding.UTF8);

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(cursoStr)))
            {
                var aux = await JsonSerializer.DeserializeAsync<Curso>(ms);
                aux!.Image = base64;

                await context.AddAsync(aux);
                await context.SaveChangesAsync();
            }

        }

    }
}
