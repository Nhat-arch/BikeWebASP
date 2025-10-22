namespace App.Models;

public class ProductViewModel
{
    public ProductModel? Product { get; set; }
    public TypeModel? Type { get; set; }
    public BrandModel? Brand { get; set; }
    public List<ImageModel> ImageList { get; set; } = new List<ImageModel>();
    public List<ProductModel> ProductList { get; set; } = new List<ProductModel>();
    public List<TypeModel> TypeList { get; set; } = new List<TypeModel>();
    public List<BrandModel> BrandList { get; set; } = new List<BrandModel>();
}