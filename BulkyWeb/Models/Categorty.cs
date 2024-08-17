using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
	public class Categorty
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[DisplayName("Category Name")]
		public string Name { get; set; }
		[DisplayName("Category order")]
		public int DisplayOrder { get; set; }
	}
}

