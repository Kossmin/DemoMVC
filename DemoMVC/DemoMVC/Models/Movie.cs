using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using NewResources;
namespace DemoMVC.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [StringLength(60, MinimumLength = 5, ErrorMessageResourceType = typeof(NewResources.Resources), ErrorMessageResourceName ="TooShort")]
        [Display(Name = "Title", ResourceType = typeof(NewResources.Resources))]
        public string Title { get; set; }

        [Display(Name = "Date", ResourceType = typeof(NewResources.Resources))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(30)]
        [Display(Name = "Genre", ResourceType = typeof(NewResources.Resources))]
        public string Genre { get; set; }

        [Range(1, 100 , ErrorMessageResourceType = typeof(NewResources.Resources), ErrorMessageResourceName = "TooLong")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price", ResourceType = typeof(NewResources.Resources))]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}