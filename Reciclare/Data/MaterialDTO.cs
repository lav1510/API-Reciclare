namespace Reciclare.Models
{
    public class Material
    {
        public string Nume { get; set; }
        public int Id { get; set; }
        public IList<Produs> Produse { get; set; }
    }
}