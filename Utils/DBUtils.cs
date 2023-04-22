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

            var cursoStr = await File.ReadAllTextAsync("database-init/curso.json", Encoding.UTF8);
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(cursoStr)))
            {
                var cursos = await JsonSerializer.DeserializeAsync<Curso[]>(ms);
                foreach (var curso in cursos!)
                {
                    var cartel = await File.ReadAllBytesAsync("database-init/cartel.png");
                    var base64 = Convert.ToBase64String(cartel);

                    curso.Image = base64;
                    await context.AddAsync(curso);
                }
                await context.SaveChangesAsync();
            }

        }

    }
}
