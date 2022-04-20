using BelgeOlusturucu.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BelgeOlusturucu.Controllers
{
    public class AccountController : Controller
    {
        //Dışarıda iki tane metod tanımladım.Farklı yerlerden çağırıldığında kullanılabilmesi amaçlı.Aynı kodu tekrar tekrar yazmamak amaçlı dışarda tanımladım.

        public static void CreateTxt(LoginViewModel model)
        {
            //Fatura tutarını belirlemek için kendimce bir yöntem belirledim. fatura tarihindeki gün sayısını buldum ve bunu 22 ile çarptım. tutarı randomda atayabilirdim ama bir özellik katmak istedim. Yani fatura tutarını bulabilmek için kullanıcının giriş yaptığı tarih ayın kaçıncı günü bul ve 22 ile çarp.
            model.Amount = model.InvoceTime.Day * 22;
            string path2 = @"C:\Users\selin\Desktop\SablonDosyasi.txt"; //Dosya yolunu verdim
            FileStream fs2 = new FileStream(path2, FileMode.OpenOrCreate, FileAccess.Write); //Dosya varsa açtım yoksa oluşturdum
            StreamWriter sw2 = new StreamWriter(fs2); // yazmak için bir nesne oluşturdum ve yazma işlemlerini gerçekleştirdim.
            sw2.WriteLine("Konu:" + model.InvoceTime + "tarihli faturanız.");
            sw2.WriteLine($"Sayın {model.Name} {model.Surname},");
            sw2.WriteLine($"{model.InvoiceNumber} numaralı hizmet faturanız ekte gönderilmiştir.");
            sw2.WriteLine($"Bu dönem için fatura tutarınız: {model.Amount} TL.");
            sw2.WriteLine("Saygılarımızla,");
            sw2.Close();
            fs2.Close();
        }
        public static void CreateCsv(LoginViewModel model)
        {
            model.Amount = model.InvoceTime.Day * 22; //tutarı buldurdum.
            string path = @"C:\Users\selin\Desktop\VeriDosyasi.csv";//dosya yolunu verdim.
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);//dosyaya yapılacak işlemi belirledim.
            StreamWriter sw = new StreamWriter(fs);//dosyaya yazabilmek içiçn bir nesne oluşturdum
            sw.WriteLine($"{model.InvoiceNumber};{model.Name};{model.Surname};{model.Amount}");
            sw.Close();
            fs.Close();

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(); //Login saysafı yüklendiğinde view döndür.
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model) // Controller'ların add view ile view lerini oluşturup tasarımını yaptım.
        {
            if (!ModelState.IsValid) // eğer model durumu geçerli değilse. örneğin zorunlu alanlar doldurulmadıysa
            {
                ModelState.AddModelError("", "Veri girişleri düzgün olmalıdır!"); //Kullanıcıya bir mesaj verdim
                return View(model); //ve modeli döndürdüm.
            }
            else
            {
                // model geçerli ise bu kod bloguna gelerek yukarda oluşturduğum iki metodu çağırdım.
                CreateCsv(model);
                CreateTxt(model);
            }
            return RedirectToAction("Document", "Account"); //kullanıcı giriş yapa tıkladığında yönlendirileceği sayfayı belirledim.
        }

        public IActionResult Document(LoginViewModel model)
        {

            return View();
        }


    }
}
