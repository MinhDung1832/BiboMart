using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using ProductAllTool.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProductAllTool.Controllers
{
    public class HomeController : Controller
    {
        // GET: ProductImageWeb
        public ActionResult Index()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                ViewBag.status = 1;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        public ActionResult Index2()
        {
            if (Session["uid"] != null && Session["uid"].ToString().Length > 0)
            {
                ViewBag.status = 1;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        [HttpPost]
        public ActionResult getData(string typeFill,string lsSku)
        {
            try
            {
                lsSku = lsSku.Replace("\n", ",");
                //lsSku = lsSku.Replace(",", "','");
                //data Session

                //List<ItemWeb> LS_itemWebs = await DataAccess.DataAccess.getProduct(typeFill,"'"+lsSku+"'");

                List<ItemWeb> LS_itemWebs = DataAccess.DataAccess.getProduct_v2(typeFill,lsSku);



                if (LS_itemWebs.Count > 0)
                {
                    Session["LS_itemWebs"] = LS_itemWebs;

                    return Json(JsonConvert.SerializeObject(LS_itemWebs));
                }
                else
                {
                    return Json("");
                }
            }
            catch (Exception)
            {
                return Json("");
            }

        }

        public void ExportExcel()
        {

            //DataTable dt = new DataTable();
            // dll referred NPOI.dll and NPOI.OOXML 

            IWorkbook workbook= new XSSFWorkbook();
            

            //productItem itemGet = (productItem)Session["itemGet"];

            ISheet sheet1 = workbook.CreateSheet("Sheet 1");

            //make a header row 
            IRow row1 = sheet1.CreateRow(0);

            ICell cell_header_s1_m1 = row1.CreateCell(0);
            cell_header_s1_m1.SetCellValue("Mã sản phẩm");

            ICell cell_header_s1_m2 = row1.CreateCell(1);
            cell_header_s1_m2.SetCellValue("Tên sản phẩm");

            ICell cell_header_s1_1 = row1.CreateCell(2);
            cell_header_s1_1.SetCellValue("Giá bán");

            ICell cell_header_s1_2 = row1.CreateCell(3);
            cell_header_s1_2.SetCellValue("Link SP");

            ICell cell_header_s1_3 = row1.CreateCell(4);
            cell_header_s1_3.SetCellValue("Ảnh");

            sheet1.SetColumnWidth(3, 12000);

            List<ItemWeb> LS_itemWebs = (List<ItemWeb>)Session["LS_itemWebs"];
            if (LS_itemWebs != null)
            {
                for (int i = 0; i < LS_itemWebs.Count(); i++)
                {
                    try
                    {
                        IRow row = sheet1.CreateRow(i + 1);
                        row.Height = 4000;

                        ICell cell_m1 = row.CreateCell(0);
                        cell_m1.SetCellValue(LS_itemWebs[i].sku);

                        ICell cell_m2 = row.CreateCell(1);
                        cell_m2.SetCellValue(LS_itemWebs[i].name);

                        ICell cell_1 = row.CreateCell(2);
                        cell_1.SetCellValue(LS_itemWebs[i].price);

                        ICell cell_2 = row.CreateCell(3);
                        cell_2.SetCellValue(LS_itemWebs[i].url);


                        var webClient = new WebClient();
                        webClient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:71.0) Gecko/20100101 Firefox/71.0");

                        byte[] data = webClient.DownloadData(LS_itemWebs[i].image_link);
                        //System.IO.File.ReadAllBytes(@"");
                        int pictureIndex = workbook.AddPicture(data, PictureType.PNG);

                        ICreationHelper helper = workbook.GetCreationHelper();
                        IDrawing drawing = sheet1.CreateDrawingPatriarch();
                        IClientAnchor anchor = new XSSFClientAnchor(); //helper.CreateClientAnchor();

                        anchor.Col1 = 4;
                        anchor.Col2 = 5;
                        anchor.Row1 = i + 1;
                        anchor.Row2 = i + 2;
                        anchor.Dx1 = 500;
                        anchor.Dx2 = 500;

                        anchor.AnchorType = AnchorType.MoveDontResize;

                        IPicture picture = drawing.CreatePicture(anchor, pictureIndex);
                    }
                    catch (Exception ex)
                    {
                        DataAccess.LogBuild.CreateLogger(JsonConvert.SerializeObject(LS_itemWebs[i]), "ExportExcel");
                        DataAccess.LogBuild.CreateLogger(ex.ToString(), "ExportExcel");
                    }
                    
                }
            }

            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "ImageOfProductBySKU_"+ DateTime.Now.ToString("yyyyMMddHHmmss") + @".xlsx"));
                    Response.BinaryWrite(exportData.ToArray());

                Response.End();
            }
        }
    }
}