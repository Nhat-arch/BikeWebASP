namespace App.Models;

public class ImageModel
{
    public int ImageId { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public int ProductId { get; set; }
}
