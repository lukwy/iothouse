using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace IoTHouse.Controllers
{
    [Route("api/[controller]")]
    public class IoTHouseController : Controller
    {
        // GET api/iothouse
        [HttpGet]
        public void Get()
       {
            var regId = "1:585358758942:android:4c0ee01717128c1b";
            string SERVER_API_KEY = "AAAAiEoZ1B4:APA91bER2aHusnWukC230JNC-1OxLV9qgcGVFVfqhq7K2p5uNACSnHrVmXs0v1WGNdx5iKIm8DD7Eq__pFA44U9XeYIN0iw51GZdXgaejzxryqD2aJmLrw5miQ31pLYHr6ISt1C9i85R";
            var SENDER_ID = "585358758942";
            var value = "Test Notification";
            WebRequest tRequest;
            tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));

            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

            string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + regId + "";
            Console.WriteLine(postData);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;

            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse tResponse = tRequest.GetResponse();

            dataStream = tResponse.GetResponseStream();

            StreamReader tReader = new StreamReader(dataStream);

            string sResponseFromServer = tReader.ReadToEnd();


            tReader.Close();
            dataStream.Close();
            tResponse.Close();
        }

        // GET api/iothouse/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"IoTHouse {id}";
        }

        // POST api/iothouse
        [HttpPost]
        public void Post([FromBody]string value)
        {
            try
            {
                var applicationID = "AIza---------4GcVJj4dI";

                var senderId = "57-------55";

                string deviceId = "euxqdp------ioIdL87abVL";

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";

                tRequest.ContentType = "application/json";

                Byte[] byteArray = Encoding.UTF8.GetBytes("asdf");

                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

                tRequest.ContentLength = byteArray.Length;


                using (Stream dataStream = tRequest.GetRequestStream())
                {

                    dataStream.Write(byteArray, 0, byteArray.Length);


                    using (WebResponse tResponse = tRequest.GetResponse())
                    {

                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {

                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {

                                String sResponseFromServer = tReader.ReadToEnd();

                                string str = sResponseFromServer;

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                string str = ex.Message;

            }
        }

        // PUT api/iothouse/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/iothouse/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
