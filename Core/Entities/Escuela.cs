namespace Core.Entities
{
    public class Escuela : BaseEntity
    {
        public string Nombre { get; set; }
        public Institucion Institucion { get; set; }
        public int InstitucionId { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;
    }
}