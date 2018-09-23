using System;
using System.IO;
using System.Collections;
using Castle.DynamicProxy;

namespace StajyerApp.Infrastructure.Interceptors
{
 public  class Interceptor : IInterceptor
    {
       // Log4NetLibrary.IDbLogService log = new Log4NetLibrary.DbLogService("SqlLog");
        public void Intercept(IInvocation invocation)
        { 
            //LoggingToFile logla = new LoggingToFile();
            try
            {
                //Metoda gelen ilk isteği logluyoruz.    
                // Console.WriteLine("{0} isimli metoda istek geldi", invocation.Method.Name);  
                //İsteği yapan kullanıcının işlemi yapma yetkisi var mı yok mu kontrolünü burada yapabiliriz.
                //Eğer yetkisi varsa metodu çalıştır.
                invocation.Proceed();
                //Metod bilgilerini konsol ekranına yazdırmak için kullanılan metod
               
                ConsolaYaz(invocation);

                //log.Error("Bu hatayı yakaladım işte");
                //string xxx = invocation.Method.Name;
                //string cccc = (string)invocation.InvocationTarget.ToString();
                //NativeMethods.AllocConsole();
                //IntPtr stdHandle = NativeMethods.GetStdHandle(NativeMethods.STD_OUTPUT_HANDLE);
                //Console.WriteLine(invocation.Arguments);

                //StreamWriter yaz;
                //yaz = File.AppendText("C:deneme.txt");

                //yaz.Write(invocation.Method.Name);

                //yaz.Close();

                // Yoksa Exception fırlatılabilir.

                //Console.WriteLine("{0} isimli metodun çalışması sona erdi.", invocation.Method.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu {0}", ex.ToString());
            }
        }

        /// <summary>
        ///Metod Bilgilerini Consol ekranına yazdıryoruz 
        /// </summary>
        /// <param name="invocation"></param>
        void ConsolaYaz(IInvocation invocation)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;


            Console.WriteLine("Metod Adı : " + invocation.Method.Name);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Dönüş Değeri : " + invocation.ReturnValue);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Dal Sınıf Adı : " + invocation.TargetType.Name);

            //Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine(invocation.ReturnValue);
            //Console.WriteLine(invocation.MethodInvocationTarget);
            
            //Console.WriteLine(invocation.GenericArguments);

            if (invocation.ReturnValue is IList)
            {
                foreach (var item in (IList)invocation.ReturnValue)
                {

                }
            }

            if (invocation.Arguments.Length > 0)
            {
                Console.WriteLine("");

                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;


                Console.Write("Parametreler : ");
                foreach (var item in invocation.Arguments)
                {
                    Console.Write(item.ToString() + " , ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("");
                Console.WriteLine("");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("");
            }

            //Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("_______________________________________________________________________________________");
            Console.WriteLine("");
        }
    }

     class TextYaz
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_directory"></param>
        /// <param name="_fileName"></param>
        /// <param name="text"></param>

      static public void TextDosyasinaYaz(string _directory, string _fileName, params string[] text)
        {
            // System.IO.File.WriteAllLines(_directory + "\\" + _fileName, text);
            string yeniText = null;

            foreach (var txt in text)
            {
                yeniText = yeniText + txt;
            }

            if (yeniText != null)
            {
                dosyayaYaz(_directory, _fileName, yeniText);
            }
        }

      public  static void dosyayaYaz(string _directory, string _fileName, string _text)
        {

            StreamWriter dosya;

            File.Open(_directory + "\\" + _fileName, FileMode.Append, FileAccess.Write, FileShare.Read);



            if (File.Exists(_directory + "\\" + _fileName) == true)
            {
                dosya = new StreamWriter(_directory + "\\" + _fileName);
            }
            else
            {
                dosya = new StreamWriter(_directory + "\\" + _fileName);
            }

            //Dosyamıza birinci satırı yazalım
            dosya.WriteLine(_text);
            //Dosyamızın kapatılım..
            dosya.Close();
        }

    //    static public void TextDosyasinaYaz(string _directory, string _fileName, string text)
    //    {
    //        System.IO.File.WriteAllText(_directory + "\\" + _fileName, text);
    //    }

    //    static public void TextDosyasinaYaz(string _directory, string _fileName, string noWriteText, params string[] writeText)
    //    {
    //        using (
    //            System.IO.StreamWriter file = new System.IO.StreamWriter(_directory + "\\" + _fileName))
    //        {
    //            foreach (string line in writeText)
    //            {
    //                If the line doesn't contain the word 'Second', write the line to the file.
    //                if (!line.Contains(noWriteText))
    //                {
    //                    file.WriteLine(line);
    //                }
    //            }
    //        }
    //    }

    //    static public void TextDosyasinaYaz(string _directory, string _fileName, string _text, string writeText)
    //    {
    //        using (
    //            System.IO.StreamWriter file = new System.IO.StreamWriter(_directory + "\\" + _fileName))
    //        {

    //            file.WriteLine(writeText);

    //        }
    //    }


    //    static public string metniTamamla(string _text, int _karakterSayisi)
    //    {
    //        int textsayisi = _text.Length;

    //        int eklenecekBosluk = _karakterSayisi - textsayisi;

    //        string boslukMetin = null;
    //        for (int i = 0; i < eklenecekBosluk; i++)
    //        {
    //            boslukMetin = boslukMetin + " ";
    //        }

    //        return _text + boslukMetin;

    //    }



    //    static public string metinSonunaVirgulKoy(string _text, int _karakterSayisi)
    //    {
    //        return _text + ";";
    //    }
    }
}
