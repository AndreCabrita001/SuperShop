using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SuperShop.Data.Entities
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The Field {0} can contain {1} characters length.")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        //public string ImageUrl { get; set; }
        public Guid ImageId { get; set; }

        [Display(Name = "Last Purchase")]
        public DateTime? LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }

        [Display(Name = "Is Avaliable")]
        public bool IsAvaliable { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }

        public User User { get; set; }

        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://supershoptpsi123.azurewebsites.net/images/no-image.png"
            : $"https://supershoptpsi123.blob.core.windows.net/products/{ImageId}";
        //{
            //get
            //{
            //    if(string.IsNullOrEmpty(ImageUrl))
            //    {
            //        return null;
            //    }

            //    return $"https://supershoptpsi123.azurewebsites.net{ImageUrl.Substring(1)}";
            //}


        //}
    }
}
