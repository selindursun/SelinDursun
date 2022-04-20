using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BelgeOlusturucu.Models
{
    public class LoginViewModel
    {
        //Bu kısımda gerekli olacak propları tanımladım.
        // Giriş yaparken hangi alanın gerekli olduğunu belirtmek için Required attribute'unu kullandım. Buna benzer olarak Stringlength ile max karakter min karakter de belirleyebilirdik.Yani giriş kısmında farklı kısıtlamalar daha yapabilirdim.

        public String InvoiceNumber { get; set; }
        [Required(ErrorMessage = "Doldurulması gereken alan")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Doldurulması gereken alan")]
        public String Surname { get; set; }
        public DateTime InvoceTime { get; set; } = DateTime.Now.Date; //Fatura tarihini kullanıcının giriş yaptığı tarih olarak atamak istedim.
        public int Amount { get; set; } 


    }
}
