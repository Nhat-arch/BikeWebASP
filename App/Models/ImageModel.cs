namespace App.Models;

public class ImageModel
{
    public int Id { get; set; }
    public string? ImagePath { get; set; }
    public int TrangThai { get; set; }
    public ProductModel Product { get; set; } = new ProductModel();
}
