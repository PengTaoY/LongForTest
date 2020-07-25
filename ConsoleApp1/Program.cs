using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Web;

namespace HttpDownloadDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpDownloadFile(@"http://risk.longfor.sit/file/download/noauth/138aa91f-d6dc-4e16-b056-756f6f1c69093", @"D:\123", true);
            HttpDownloadFile(@"http://risk.longfor.sit/file/download/noauth/02972f75-ded6-4061-9b1a-f2e4c8cd38b5", @"D:\123", true);
            HttpDownloadFile(@"https://www.cnblogs.com/images/logo_small.gif", @"D:\123", true);
            HttpDownloadFile(@"http://risk.longfor.sit/file/download/noauth/f33b1abf-b17d-4819-97ac-94f01481a52a", @"D:\123", true);

            Console.WriteLine("Hello World!");
        }

        public static void HttpDownloadFile(string url, string path, bool overwrite)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //发送请求并获取相应回应数据
            HttpWebResponse response;
            try
            {
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
            }

            //获取文件名
            string conentDisposition = response.Headers["Content-Disposition"];
            string fileName;
            if (string.IsNullOrEmpty(conentDisposition))
                fileName = response.ResponseUri.Segments[response.ResponseUri.Segments.Length - 1];
            else
                fileName = conentDisposition.Remove(0, conentDisposition.IndexOf("UTF-8''") + 7);

            fileName = HttpUtility.UrlDecode(fileName);

            #region 第二种方式
            //ContentDisposition contentDisposition = new ContentDisposition(conentDisposition);
            //string sss = contentDisposition.FileName;
            #endregion


            MemoryStream memoryStream = StreamToMemoryStream(response.GetResponseStream());



            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            using (Stream responseStream = response.GetResponseStream())
            {
                long totalLength = response.ContentLength;
                //创建本地文件写入流
                using (Stream stream = new FileStream(Path.Combine(path, fileName), overwrite ? FileMode.Create : FileMode.CreateNew))
                {
                    byte[] bArr = new byte[1024];
                    int size;
                    while ((size = responseStream.Read(bArr, 0, bArr.Length)) > 0)
                    {
                        stream.Write(bArr, 0, size);
                    }
                }
            }

           // DeleteFile(path, Path.Combine(path, fileName));

        }

        private static MemoryStream StreamToMemoryStream(Stream stream)
        {
            MemoryStream ms = new MemoryStream();
           
            while (true)
            {
                byte[] buffer = new byte[1024];
                int sz = stream.Read(buffer, 0, 1024);
                if (sz == 0) break;
                ms.Write(buffer, 0, sz);
            }
            ms.Position = 0;
            return ms;
        }

        public static void DeleteFile(string directoryPath, string fileName)
        {
            try
            {
                File.Delete(fileName);
            }
            catch (Exception)
            {
                Console.WriteLine($"{directoryPath}下没有该文件");
                throw;
            }
            
            //for (int i = 0; i < Directory.GetFiles(directoryPath).ToList().Count; i++)
            //{
            //    if (Directory.GetFiles(directoryPath)[i] == fileName)
            //    {
            //        File.Delete(fileName);
            //    }
            //}
        }

        public static void Httpdownload()
        {
            string url = @"http://risk.longfor.sit/file/download/noauth/138aa91f-d6dc-4e16-b056-756f6f1c6909";
            string newFileName = Guid.NewGuid().ToString();
            var httpClient = new System.Net.Http.HttpClient();

            var t = httpClient.GetByteArrayAsync(url);
            t.Wait();


            string fileExtension = (Path.GetExtension(url) ?? string.Empty).ToLower();
            if (string.IsNullOrWhiteSpace(newFileName))
            {
                newFileName = Path.GetFileName(url);
            }
            else
            {
                //文件名+文件后缀名
                newFileName = newFileName + fileExtension;
            }
            //return File(t.Result, "application/octet-stream", newFileName);

            File.WriteAllBytes($"D:\\123\\{newFileName}", t.Result);
        }

        class TestModel
        {
            public string Name { get; set; }

            public int Id { get; set; }
        }
    }
}
