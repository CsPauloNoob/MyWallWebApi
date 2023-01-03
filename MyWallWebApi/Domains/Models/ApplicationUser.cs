using Microsoft.AspNetCore.Identity;
using MyWallWebApi.Models;
using System.Text.Json.Serialization;

namespace MyWallWebApi.Domains.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Post> Posts { get; set; }
    }
}
