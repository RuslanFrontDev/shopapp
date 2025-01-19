namespace shopapp.entity.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string ImageUrl { get; set; }
    public bool IsApproved { get; set; }
    public List<ProductCategory> ProductCategory { get; set; }
}