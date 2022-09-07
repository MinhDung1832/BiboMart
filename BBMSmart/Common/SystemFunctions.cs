using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ProductAllTool.Common
{
    public class SystemFunctions
    {
        private static string uploadurl = ConfigurationManager.AppSettings.Get("Media_Url");
        private static string uploadFileurl = ConfigurationManager.AppSettings.Get("Mediafile_Url");
        private static string uploadkey = ConfigurationManager.AppSettings.Get("Media_Key");
        public static void SaveSession(string controller, string action)
        {
            HttpContext.Current.Session["prev_action"] = action;
            HttpContext.Current.Session["prev_control"] = controller;
        }

        public static async Task<string> UploadIMG(string folder, string files)
        {
            var client = new HttpClient();
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);
                form.Add(DictionaryItems, "model");
                var stream = new FileStream(files, FileMode.Open);
                HttpContent content = new StringContent("");
                content = new StreamContent(stream);
                form.Add(content, "myFiles", files);
                form.Add(new StringContent(folder), "dir");
                client.DefaultRequestHeaders.Add("Authorization", uploadkey);
                HttpResponseMessage response = await client.PostAsync(uploadurl, form);
                string res = await response.Content.ReadAsStringAsync();


                if ((int)response.StatusCode == 200)
                {
                    Root result = JsonConvert.DeserializeObject<Root>(res);
                    return result.files[0].url;
                }
                else
                {
                    return "Ảnh sai định dạng hoặc quá lớn.";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public static async Task<string> UploadIMGDirect(string folder, HttpPostedFile files)
        {
            var client = new HttpClient();
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);
                form.Add(DictionaryItems, "model");
                var stream = files.InputStream;
                HttpContent content = new StringContent("");
                content = new StreamContent(stream);
                form.Add(content, "myFiles", files.FileName);
                form.Add(new StringContent(folder), "dir");
                client.DefaultRequestHeaders.Add("Authorization", uploadkey);
                HttpResponseMessage response = await client.PostAsync(uploadurl, form);
                string res = await response.Content.ReadAsStringAsync();


                if ((int)response.StatusCode == 200)
                {
                    Root result = JsonConvert.DeserializeObject<Root>(res);
                    return result.files[0].url;
                }
                else
                {
                    return "Ảnh sai định dạng hoặc quá lớn.";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }

        public static async Task<string> UploadIMGDirect_Multiple(string folder, HttpPostedFileBase files)
        {
            var client = new HttpClient();
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);
                form.Add(DictionaryItems, "model");
                var stream = files.InputStream;
                HttpContent content = new StringContent("");
                content = new StreamContent(stream);
                form.Add(content, "myFiles", files.FileName);
                form.Add(new StringContent(folder), "dir");
                client.DefaultRequestHeaders.Add("Authorization", uploadkey);
                HttpResponseMessage response = await client.PostAsync(uploadurl, form);
                string res = await response.Content.ReadAsStringAsync();
                if ((int)response.StatusCode == 200)
                {
                    Root result = JsonConvert.DeserializeObject<Root>(res);
                    return result.files[0].url;
                }
                else
                {
                    return "Ảnh sai định dạng hoặc quá lớn.";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }


        public static async Task<string> Upload_File_Direct(string folder, HttpPostedFile files)
        {
            var client = new HttpClient();
            try
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);
                form.Add(DictionaryItems, "model");
                var stream = files.InputStream;
                HttpContent content = new StringContent("");
                content = new StreamContent(stream);
                form.Add(content, "myFiles", files.FileName);
                form.Add(new StringContent(folder), "dir");
                client.DefaultRequestHeaders.Add("Authorization", uploadkey);
                HttpResponseMessage response = await client.PostAsync(uploadFileurl, form);
                string res = await response.Content.ReadAsStringAsync();


                if ((int)response.StatusCode == 200)
                {
                    Root result = JsonConvert.DeserializeObject<Root>(res);
                    return result.files[0].url;
                }
                else
                {
                    return "Ảnh sai định dạng hoặc quá lớn.";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public class File
        {
            public string mimetype { get; set; }
            public string url { get; set; }
            public long timestamp { get; set; }
        }

        public class Root
        {
            public int error { get; set; }
            public string message { get; set; }
            public List<File> files { get; set; }
        }

    }
}