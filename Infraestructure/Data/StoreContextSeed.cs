using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Instituciones.Any())
                {
                    context.Instituciones.AddRange(JsonSerializer.Deserialize<List<Institucion>>(File.ReadAllText("../Infraestructure/Data/SeedData/Instituciones.json")));
                }

                if (!context.Escuelas.Any())
                {
                    context.Escuelas.AddRange(JsonSerializer.Deserialize<List<Escuela>>(File.ReadAllText("../Infraestructure/Data/SeedData/Escuelas.json")));
                }

                if (!context.Cursos.Any())
                {
                    context.Cursos.AddRange(JsonSerializer.Deserialize<List<Curso>>(File.ReadAllText("../Infraestructure/Data/SeedData/Cursos.json")));
                }

                if (!context.TiposEvaluacion.Any())
                {
                    context.TiposEvaluacion.AddRange(JsonSerializer.Deserialize<List<TipoEvaluacion>>(File.ReadAllText("../Infraestructure/Data/SeedData/TiposEvaluacion.json")));
                }

                if (!context.Numerales.Any())
                {
                    context.Numerales.AddRange(JsonSerializer.Deserialize<List<Numeral>>(File.ReadAllText("../Infraestructure/Data/SeedData/Numerales.json")));
                }

                if (!context.Evaluaciones.Any())
                {
                    context.Evaluaciones.AddRange(JsonSerializer.Deserialize<List<Evaluacion>>(File.ReadAllText("../Infraestructure/Data/SeedData/Evaluaciones.json")));
                }

                if (!context.Preguntas.Any())
                {
                    context.Preguntas.AddRange(JsonSerializer.Deserialize<List<Pregunta>>(File.ReadAllText("../Infraestructure/Data/SeedData/Preguntas.json")));
                }

                if (!context.Respuestas.Any())
                {
                    context.Respuestas.AddRange(JsonSerializer.Deserialize<List<Respuesta>>(File.ReadAllText("../Infraestructure/Data/SeedData/Respuestas.json")));
                }

                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}