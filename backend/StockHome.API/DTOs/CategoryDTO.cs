namespace StockHome.API.DTOs
{
    public class CategoryDTO
    {
        public record Response(int Id, string Name);
        public record Create(string Name);
        public record Update(int Id, string Name);

    }
}
