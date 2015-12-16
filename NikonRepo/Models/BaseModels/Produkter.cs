using System;

namespace NikonRepo
{

	 public class Produkter
	{
		 public int ID { get; set; }
	     public int KategoriID { get; set; }
	     public string Overskrift   { get; set; }
	     public string Navn { get; set; }
	     public int Varenummer { get; set; }
	     public decimal Pris { get; set; }
	     public decimal Tilbudspris { get; set; }
	     public string Leveringstid { get; set; }
	     public int Lagerantal { get; set; }
	     public string Billede { get; set; }        
	     public string Beskrivelse { get; set; }        
	     public string Producent { get; set; }        
	 }

}
