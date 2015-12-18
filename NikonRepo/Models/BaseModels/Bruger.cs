using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace NikonRepo
{

	 public class Bruger
	{
		 public int ID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
	     public string Password { get; set; }

     }

}
