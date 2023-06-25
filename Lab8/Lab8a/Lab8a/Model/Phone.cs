using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8a.Model
{
    public class Phone
    {
        [JsonProperty("Id")]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [JsonProperty("Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name length must be between 3 and 50 characters")]
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [JsonProperty("Phone")]
        [RegularExpression(@"\+375\d{9}", ErrorMessage = "Phone format is +375(xx)xxx-xx-xx")]
        [Required(ErrorMessage = "Phone is required!")]
        public string Number { get; set; }
    }
}
