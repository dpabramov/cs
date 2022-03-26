using System;
using System.IO;
using System.Text;

namespace _08_WriteToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"file_name.txt";
            string text = "Привет World! 100₽";
            //Чтобы русские символы записывались корректно используем Unicode
            byte[] array = Encoding.UTF8.GetBytes(text);
            //а для только латинских символов ASCII
            //byte[] array = Encoding.ASCII.GetBytes(text);

            FileStream fileStream = new FileStream(
                fileName,
                //создаем файл, если он есть, то удаляем и создаем новый
                FileMode.Create,
                //открываем для записи
                FileAccess.Write, 
                //пока файл открыт для записи его параллельно можно читать
                FileShare.Read);

            fileStream.Write(array);
            fileStream.Close();

            //дозапишем в файл
            FileStream fs = new FileStream(
                fileName,
                //дозаписать в файл если он есть, создать файл если его нет
                FileMode.OpenOrCreate,
                FileAccess.Write,
                //пока не закрыли, читать его нельзя 
                FileShare.None);

            //перемещаем курсор в конец файла для последующей записи
            //сместиться от конца файла на ноль.
            fs.Seek(0, SeekOrigin.End);
            //осуществляем дозапись в файл
            fs.Write(array);
            //записать из буфера операционной системы в файл
            //если этого не сделать, то запишется на диск при выполнении Close()
            fs.Flush();
            //в эот момент данные в файл уже дозаписались, но файл еще не закрыт
            fs.Close();
        }
    }
}
