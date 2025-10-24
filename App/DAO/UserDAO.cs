// using MySql.Data.MySqlClient;
// using App.Models;
// using Microsoft.AspNetCore.Identity;

// namespace App.DAO;

// public class UserDAO
// {
//     private readonly IPasswordHasher<IdentityUser> _pH = new PasswordHasher<IdentityUser>();
//     public UserModel LayUser(string username)
//     {
//         var user = new UserModel();
//         using (var conn = DataProvider.Connect())
//         {
//             string select = "select * from User where TrangThai = 1 and Username = @Username Limit 1";
//             var par = new MySqlParameter("@Username", username);
//             using (var dr = DataProvider.Read(select, conn, par))
//             {
//                 while (dr.Read())
//                 {
//                     user.Username = dr["Username"].ToString();
//                     user.Password = dr["Password"].ToString();
//                     user.RoleId = int.Parse(dr["RoleId"].ToString());
//                 }
//             }
//         }
//         return user;
//     }
//     public int Register(UserModel user)
//     {
//         using (var conn = DataProvider.Connect())
//         {
//             string create = "insert into User(Username,Password,RoleId,TrangThai) Values(@Username,@Password,3,1)";
//             var par = new MySqlParameter[]{
//                 new MySqlParameter("@Username", user.Username),
//                 new MySqlParameter("@Password", _pH.HashPassword(null, user.Password)),
//             };
//             var kq = DataProvider.Execute(create, conn, par);
//             return kq;
//         }
//     }
//     public bool Login(string username, string password)
//     {
//         var user = LayUser(username);
//         if (user.Password == null)
//         {
//             return false;
//         }
//         return VerifyPass(password, user.Password);
//     }
//     public bool VerifyPass(string pass, string hashedPass)
//     {
//         ;
//         return PasswordVerificationResult.Success == _pH.VerifyHashedPassword(null, hashedPass, pass);
//     }
//     public int getRole(string username)
//     {
//         var user = LayUser(username);
//         return user.RoleId;
//     }
// }
