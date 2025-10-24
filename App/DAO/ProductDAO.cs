// using App.Models;
// using MySql.Data.MySqlClient;

// namespace App.DAO
// {
//     public class ProductDAO
//     {
//         public List<BrandModel> LayDSBrand()
//         {
//             var ds = new List<BrandModel>();

//             using (var conn = DataProvider.Connect())
//             {
//                 string query = "SELECT * from Brand where TrangThai = 1";

//                 using (var dr = DataProvider.Read(query, conn))
//                 {
//                     while (dr.Read())
//                     {
//                         ds.Add(new BrandModel
//                         {
//                             BrandId = int.Parse(dr["BrandId"].ToString()),
//                             BrandName = dr["BrandName"].ToString()
//                         });
//                     }
//                 }
//             }
//             return ds;
//         }
//         public List<TypeModel> LayDSType()
//         {
//             var ds = new List<TypeModel>();

//             using (var conn = DataProvider.Connect())
//             {
//                 string query = "SELECT * from Type where TrangThai = 1";

//                 using (var dr = DataProvider.Read(query, conn))
//                 {
//                     while (dr.Read())
//                     {
//                         ds.Add(new TypeModel
//                         {
//                             TypeId = int.Parse(dr["TypeId"].ToString()),
//                             TypeName = dr["TypeName"].ToString()
//                         });
//                     }
//                 }
//             }
//             return ds;
//         }
//         public List<ProductModel> LayDSProduct()
//         {
//             var ds = new List<ProductModel>();

//             using (var conn = DataProvider.Connect())
//             {
//                 string query = "SELECT * from Product where TrangThai = 1";

//                 using (var dr = DataProvider.Read(query, conn))
//                 {
//                     while (dr.Read())
//                     {
//                         ds.Add(new ProductModel
//                         {
//                             ProductId = int.Parse(dr["ProductId"].ToString()),
//                             ProductName = dr["ProductName"].ToString(),
//                             BrandId = int.Parse(dr["BrandId"].ToString()),
//                             TypeId = int.Parse(dr["TypeId"].ToString()),
//                             ProductPrice = decimal.Parse(dr["ProductPrice"].ToString()),
//                             ProductDescription = dr["ProductDescription"].ToString(),
//                             LuotXem = int.Parse(dr["LuotXem"].ToString())
//                         });
//                     }
//                 }
//             }
//             return ds;
//         }
//         public List<ImageModel> LayDSImage()
//         {
//             var ds = new List<ImageModel>();

//             using (var conn = DataProvider.Connect())
//             {
//                 string query = "SELECT * from Image";

//                 using (var dr = DataProvider.Read(query, conn))
//                 {
//                     while (dr.Read())
//                     {
//                         ds.Add(new ImageModel
//                         {
//                             ImageId = int.Parse(dr["ImageId"].ToString()),
//                             ProductId = int.Parse(dr["ProductId"].ToString()),
//                             ImagePath = dr["ImagePath"].ToString()
//                         });
//                     }
//                 }
//             }
//             return ds;
//         }
//         public ProductViewModel LayDS()
//         {
//             var p = new ProductViewModel();
//             p.Product = new ProductModel();
//             p.BrandList = LayDSBrand();
//             p.TypeList = LayDSType();
//             p.ProductList = LayDSProduct();
//             p.ImageList = LayDSImage();
//             return p;
//         }
//         public int Them(ProductModel p)
//         {
//             using (var conn = DataProvider.Connect())
//             {
//                 string them = $"insert into Product (ProductName,BrandId,TypeId,ProductPrice,ProductDescription,TrangThai) values (@ProductName,@BrandId,@TypeId,@ProductPrice,@ProductDescription,1)";
//                 var par = new MySqlParameter[]{
//                 new MySqlParameter("@ProductName", p.ProductName),
//                 new MySqlParameter("@BrandId", p.BrandId),
//                 new MySqlParameter("@TypeId", p.TypeId),
//                 new MySqlParameter("@ProductPrice", p.ProductPrice),
//                 new MySqlParameter("@ProductDescription", p.ProductDescription)
//             };
//                 int kq = DataProvider.Execute(them, conn, par);
//                 return kq;
//             }
//         }
//         public int ThemBrand(BrandModel b)
//         {
//             using (var conn = DataProvider.Connect())
//             {
//                 string them = $"insert into Brand (BrandName,TrangThai) values (@BrandName,1)";
//                 var par = new MySqlParameter[]{
//                 new MySqlParameter("@BrandName", b.BrandName)
//             };
//                 int kq = DataProvider.Execute(them, conn, par);
//                 return kq;
//             }
//         }
//         public int ThemType(TypeModel t)
//         {
//             using (var conn = DataProvider.Connect())
//             {
//                 string them = $"insert into Type (TypeName,TrangThai) values (@TypeName,1)";
//                 var par = new MySqlParameter[]{
//                 new MySqlParameter("@TypeName", t.TypeName)
//             };
//                 int kq = DataProvider.Execute(them, conn, par);
//                 return kq;
//             }
//         }
//         public int ThemImage(ImageModel img)
//         {
//             using (var conn = DataProvider.Connect())
//             {
//                 string them = $"insert into Image (ImagePath,ProductId) values (@ImagePath,@ProductId)";
//                 var par = new MySqlParameter[]{
//                 new MySqlParameter("@ImagePath", img.ImagePath),
//                 new MySqlParameter("@ProductId", img.ProductId)
//             };
//                 int kq = DataProvider.Execute(them, conn, par);
//                 return kq;
//             }
//         }
//     }
// }
