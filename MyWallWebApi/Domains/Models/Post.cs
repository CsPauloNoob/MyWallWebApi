using MyWallWebApi.Domains.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MyWallWebApi.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }



        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get;}
    }
}