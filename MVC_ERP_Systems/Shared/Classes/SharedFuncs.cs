using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Mail;
using System.Globalization;

using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

//using BL = BLL.ArHelper.UlpHelper;
//using BLWF = BLL.ArHelper.WfHelper;
using System.Web.UI.HtmlControls;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace MVC_ERP_Systems.SharedClasses
{
    public struct SMessage
    {
        /// success, warning, info, danger
        public string Stat { get; set; }
        public string SEM { get; set; }

    }



    /// <summary>
    /// Main class for Functions 
    /// </summary>
    public class SFncs
    {
        public static List<SMessage> lom = new List<SMessage>();
        //public  List<MessageSt> LOM = new List<MessageSt>();



        #region Enumerables

        public enum MAIN_SYS
        {
            ULP = 70,
            CTS = 88,
            wf = 98
        }

        public struct Book
        {
            public static decimal price;
            public static string title;
            public static string author;

            public static long ID { get; set; }
            public static long ST_TRANS_TYPES_ID { get; set; }
            public static string SUBJECT { get; set; }
            public static string TEXT { get; set; }
            public static DateTime CREATION_DATE { get; set; }

            public static void FindAndSelectTreeNode(TreeView TV, string SearchValue)
            {
                TV.CollapseAll();

                foreach (TreeNode node in TV.Nodes)
                {
                    FindNode(node, SearchValue);
                }
            }
        }

        #endregion

        #region Find Node And Select

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TV"></param>
        /// <param name="SearchValue"></param>
        public static void FindAndSelectTreeNode(TreeView TV, string SearchValue)
        {
            TV.CollapseAll();

            foreach (TreeNode node in TV.Nodes)
            {
                FindNode(node, SearchValue);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="SearchValue"></param>
        public static void FindNode(TreeNode node, string SearchValue)
        {
            if (node.Value == SearchValue)
                ExpandUpwards(node);
            else
                foreach (TreeNode sub in node.ChildNodes)
                {
                    FindNode(sub, SearchValue);
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public static void ExpandUpwards(TreeNode node)
        {
            node.Expand();

            if (node.Parent != null)
                ExpandUpwards(node.Parent);
        }

        #endregion

        #region Show System Messages

        /// <summary>
        /// Clear System Message
        /// </summary>
        public static void MSG(params HtmlContainerControl[] SEM)
        {
            foreach (HtmlContainerControl sem in SEM)
            {
                sem.InnerText = string.Empty;
                sem.Visible = false;
            }
        }

        /// <summary>
        /// Show System Message
        /// </summary>
        /// <param name="message">Enter The Message</param>
        /// <param name="type">The Type Of The Message S=Success F=Failed I=Info W=Warning</param>
        /// <param name="SEM">The Control that using to display The Message</param>
        public static void MSG(string message, char type, HtmlContainerControl SEM)
        {
            if (type == 'S')
            {
                SEM.InnerText = message;
                SEM.Attributes["class"] = "alert alert-success";
                SEM.Visible = true;
            }
            else if (type == 'F')
            {
                SEM.InnerText = " خطأ !!! -- " + message;
                SEM.Attributes["class"] = "alert alert-danger";
                SEM.Visible = true;
            }
            else if (type == 'I')
            {
                SEM.InnerText = " توضيح !!! -- " + message;
                SEM.Attributes["class"] = "alert alert-info";
                SEM.Visible = true;
            }
            else if (type == 'W')
            {
                SEM.InnerText = " تنبيه !!! -- " + message;
                SEM.Attributes["class"] = "alert alert-warning";
                SEM.Visible = true;
            }
        }

        /// <summary>
        /// Show System Message
        /// </summary>
        /// <param name="message">Enter The Message</param>
        /// <param name="type">The Type Of The Message S=Success F=Failed I=Info W=Warning</param>
        /// <param name="SEM">The Control that using to display The Message</param>
        /// <param name="plus">Message + another </param>
        public static void MSG(string message, char type, HtmlContainerControl SEM, bool plus)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");

            if (type == 'S')
            {
                div.InnerText = message;
                div.Attributes["class"] = "alert alert-success";
                SEM.Controls.Add(div);
            }
            else if (type == 'F')
            {
                div.InnerText = " خطأ !!! -- " + message;
                div.Attributes["class"] = "alert alert-danger";
                SEM.Controls.Add(div);
            }
            else if (type == 'I')
            {
                div.InnerText = " توضيح !!! -- " + message;
                div.Attributes["class"] = "alert alert-info";
                SEM.Controls.Add(div);
            }
            else if (type == 'W')
            {
                div.InnerText = " تحذير !!! -- " + message;
                div.Attributes["class"] = "alert alert-warning";
                SEM.Controls.Add(div);
            }

            SEM.Visible = true;
        }

        #endregion

        /// <summary>
        /// Clear All Controls
        /// </summary>
        /// <param name="parent">Always Pass : this</param>
        public static void ClearControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if ((c.GetType() == typeof(TextBox)))  //Clear TextBox
                {
                    ((TextBox)(c)).Text = "";
                }
                if ((c.GetType() == typeof(DropDownList)))  //Clear DropDownList
                {
                    ((DropDownList)(c)).ClearSelection();
                }
                if ((c.GetType() == typeof(CheckBox)))  //Clear CheckBox
                {
                    ((CheckBox)(c)).Checked = false;
                }
                if ((c.GetType() == typeof(CheckBoxList)))  //Clear CheckBoxList
                {
                    ((CheckBoxList)(c)).ClearSelection();
                }
                if ((c.GetType() == typeof(RadioButton)))  //Clear RadioButton
                {
                    ((RadioButton)(c)).Checked = false;
                }
                if ((c.GetType() == typeof(RadioButtonList)))  //Clear RadioButtonList
                {
                    ((RadioButtonList)(c)).ClearSelection();
                }
                //if ((c.GetType() == typeof(HiddenField)))  //Clear HiddenField
                //{
                //    ((HiddenField)(c)).Value = "";
                //}
                if ((c.GetType() == typeof(Label)))  //Clear Label
                {
                    ((Label)(c)).Text = "";
                }
                if (c.HasControls())
                {
                    ClearControls(c);
                }
            }
        }

        /// <summary>
        /// To download files from Server
        /// </summary>
        /// <param name="FilePath">file path pass it with Server.MapPath</param>
        public static void DownloadFile(string FilePath)
        {
            // Get the physical Path of the file
            System.IO.FileInfo file = new System.IO.FileInfo(FilePath);

            if (file.Exists)
            {
                //byte[] bytes = System.Text.Encoding.ASCII.GetBytes(FilePath);

                //HttpContext.Current.Response.Clear();
                //HttpContext.Current.Response.ClearHeaders();
                //HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                //HttpContext.Current.Response.AddHeader("Content-Length", bytes.Length.ToString());
                //HttpContext.Current.Response.ContentType = GetFileExtension(file.Extension.ToLower());
                //HttpContext.Current.Response.OutputStream.Write(bytes, 0, bytes.Length);
                //HttpContext.Current.Response.Flush();
                //HttpContext.Current.Response.End();



                HttpContext.Current.Response.ClearContent();
                // Add the file name and attachment
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                // Add the file size into the response header
                HttpContext.Current.Response.AddHeader("Content-Length", Convert.ToString(file.Length));
                // Set the ContentType
                HttpContext.Current.Response.ContentType = GetFileExtension(file.Extension.ToLower());
                // Write the file into the response
                HttpContext.Current.Response.TransmitFile(file.FullName);
                HttpContext.Current.Response.End();
            }
            else
            {
                throw new Exception("الملف غير موجود");
            }
        }

        /// <summary>
        /// To download files from Server
        /// </summary>
        /// <param name="filePath">file path pass it with Server.MapPath</param>
        public static void DownloadFile(string FilePath, string FileName)
        {
            // Get the physical Path of the file
            System.IO.FileInfo file = new System.IO.FileInfo(FilePath);

            if (file.Exists)
            {
                HttpContext.Current.Response.ClearContent();
                // Add the file name and attachment
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
                // Add the file size into the response header
                HttpContext.Current.Response.AddHeader("Content-Length", Convert.ToString(file.Length));
                // Set the ContentType
                HttpContext.Current.Response.ContentType = GetFileExtension(file.Extension.ToLower());
                // Write the file into the response
                HttpContext.Current.Response.TransmitFile(file.FullName);
                HttpContext.Current.Response.End();
            }
            else
            {
                throw new Exception("الملف غير موجود");
            }
        }

        /// <summary>
        /// Set Content Type
        /// </summary>
        /// <param name="fileExtension"></param>
        /// <returns></returns>
        private static string GetFileExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".docx":
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        //public static DataTable GetPerms(long USER_ID, string PAGE_NAME)
        //{
        //    using (BL.Users user = new BL.Users())
        //    {
        //        user.ID = USER_ID;
        //        user.PAGE_NAME = PAGE_NAME;

        //        return user.GetPerms();
        //    }
        //}

        #region FavScreen

        //public static DataRow SelectFromFavScreen(long EMP_NO, string SCREEN_NAME)
        //{
        //    using (BL.Users_Settings statuse = new BL.Users_Settings())
        //    {
        //        statuse.SCREEN_NAME = SCREEN_NAME;
        //        statuse.EMP_NO = EMP_NO;

        //        return statuse.SelectFromFavScreen();
        //    }
        //}

        //public static long InsertFav_Screen(long EMP_NO, string SCREEN_NAME)
        //{
        //    using (BL.Users_Settings statuse = new BL.Users_Settings())
        //    {
        //        statuse.SCREEN_NAME = SCREEN_NAME;
        //        statuse.EMP_NO = EMP_NO;

        //        return statuse.InsertFav_Screen();

        //    }
        //}

        //public static bool DeleteFav_Screen(long EMP_NO, string SCREEN_NAME)
        //{
        //    using (BL.Users_Settings statuse = new BL.Users_Settings())
        //    {
        //        statuse.SCREEN_NAME = SCREEN_NAME;
        //        statuse.EMP_NO = EMP_NO;

        //        return statuse.DeleteFav_Screen();
        //    }
        //}

        #endregion

        ///// <summary>
        ///// Trace the User moves on Requests.
        ///// </summary>
        ///// <param name="REQ_ID"></param>
        ///// <param name="PROCEDURE_TYPE_ID"></param>
        ///// <param name="REASON"></param>
        ///// <param name="CREATION_USER_ID"></param>
        ///// <returns></returns>
        //public static long Trac_OF_Req(
        //    long REQ_ID,
        //    long PROCEDURE_TYPE_ID,
        //    string REASON,
        //    long CREATION_USER_ID
        //    )
        //{
        //    using (BL.Users trac = new BL.Users())
        //    {
        //        trac.REQ_ID = REQ_ID;
        //        trac.PROCEDURE_TYPE_ID = PROCEDURE_TYPE_ID;
        //        trac.REASON = REASON;
        //        trac.CREATION_USER_ID = CREATION_USER_ID;
        //        trac.CREATION_DATE_H = TvisFunc.GregToHijri(DateTime.Now, "yyyy/MM/dd");

        //        return trac.Trac_OF_Req();
        //    }
        //}

        //public static DataRow GetEMP_DEP_NAME(long EMP_NO)
        //{
        //    using (BLWF.WFL user = new BLWF.WFL())
        //    {
        //        user.ID = USER_ID;
        //        user.PAGE_NAME = PAGE_NAME;

        //        return user.GetPerms();
        //    }
        //}

        public static string GetLoPageName(Page page)
        {
            return Path.GetFileNameWithoutExtension(page.AppRelativeVirtualPath).ToLower();
        }

        public static string GetLoPageName(string page)
        {
            return page.ToLower();
        }

        public static string FixGenText(string Text)
        {
            string ss = "<div align = \"right\">" + Text + "</div>";

            ss = ss.Replace("style=\"text-align: center;\"", "align = \"center\"");
            ss = ss.Replace("small", "10");
            ss = ss.Replace("medium", "15");
            ss = ss.Replace("-webkit-xxx-large", "45");
            ss = ss.Replace("xx-large", "35");
            ss = ss.Replace("x-large", "30");
            ss = ss.Replace("large", "25");

            return ss;
        }

        #region numbers Checking
        
        public static bool IsInt(string aInt64)
        {
            Int64 temp_big_int;
            return Int64.TryParse(aInt64, out temp_big_int); ;
        }

        public static bool IsNumber(string aNumber)
        {
            double temp_big_int;
            return double.TryParse(aNumber, out temp_big_int); ;
        }

        #endregion

        #region DateTime

        /// <summary>
        /// int[0] is Years
        /// int[1] is Months
        /// int[2] is days
        /// int[3] is Hours
        /// int[4] is Minutes
        /// int[5] is Seconds
        /// int[6] is Milliseconds
        /// </summary>
        /// <param name="StartDate">dd/MM/yyyy</param>
        /// <param name="EndDate">dd/MM/yyyy</param>
        /// <param name="format">D means in days onty , YMD means years ,months days .....</param>
        /// <returns></returns>
        public static int[] Get_HijriDiff_Y_M_D(string StartDate, string EndDate, string format)
        {
            short StartDateYear = Convert.ToInt16(StartDate.Substring(0, 4));
            short StartDateMonth = Convert.ToInt16(StartDate.Substring(5, 2));
            short StartDateday = Convert.ToInt16(StartDate.Substring(8, 2));

            short EndDateYear = Convert.ToInt16(EndDate.Substring(0, 4));
            short EndDateMonth = Convert.ToInt16(EndDate.Substring(5, 2));
            short EndDateday = Convert.ToInt16(EndDate.Substring(8, 2));

            CultureInfo arCul = new CultureInfo("ar-SA");
            UmAlQuraCalendar h = new UmAlQuraCalendar();
            arCul.DateTimeFormat.Calendar = h;

            DateTime StartDatedat = new DateTime(StartDateYear, StartDateMonth, StartDateday, h);
            DateTime EndDatedat = new DateTime(EndDateYear, EndDateMonth, EndDateday, h);


            int adys = 0;
            int amns = 0;
            int ayrs = 0;


            if (format == "YMD")
            {
                bool itsmns = false;
                bool itdys = false;

                while (StartDatedat < EndDatedat)
                {
                    if (!itsmns)
                    {
                        StartDatedat = h.AddYears(StartDatedat, 1);


                        if (StartDatedat > EndDatedat) // اقل من سنة
                        {
                            StartDatedat = h.AddYears(StartDatedat, -1);
                            itsmns = true;
                        }
                        else
                        {
                            ayrs++;
                        }
                    }
                    else
                    {
                        if (!itdys)
                        {
                            StartDatedat = h.AddMonths(StartDatedat, 1);

                            if (StartDatedat > EndDatedat) // اقل من شهر
                            {
                                StartDatedat = h.AddMonths(StartDatedat, -1);
                                itdys = true;
                            }
                            else
                            {
                                amns++;
                            }
                        }
                        else
                        {
                            StartDatedat = h.AddDays(StartDatedat, 1);


                            if (StartDatedat > EndDatedat) // اقل من يوم
                            {
                                StartDatedat = h.AddDays(StartDatedat, -1);
                            }
                            else
                            {
                                adys++;
                            }
                        }
                    }
                }
            }
            else
            {
                adys = Convert.ToInt32((EndDatedat - StartDatedat).TotalDays + 1);
            }

            TimeSpan difference = EndDatedat.Subtract(StartDatedat);

            int[] Resut = new int[7];
            Resut[0] = ayrs;
            Resut[1] = amns;
            Resut[2] = adys;
            Resut[3] = difference.Hours;
            Resut[4] = difference.Minutes;
            Resut[5] = difference.Seconds;
            Resut[6] = difference.Milliseconds;

            //"الفرق : " +
            //ayrs.ToString() + " سنة" +
            //", " + amns.ToString() + " شهر" +
            //", " + adys.ToString() + " يوم" +
            //", " + difference.Hours.ToString() + " ساعة" +
            //", " + difference.Minutes.ToString() + " دقيقة" +
            //", " + difference.Seconds.ToString() + " ثانية" +
            //", " + difference.Milliseconds.ToString() + " جزء من الثانية";

            return Resut;
        }

        /// <summary>
        /// Convert Hijri Date to it's equivalent Gregorian Date
        /// and return it in specified format
        /// </summary>
        /// <PARAM name="hijri">Example: 25/05/1437</PARAM>
        /// <PARAM name="format">Example: dd/MM/yyyy</PARAM>
        /// <returns></returns>
        public static DateTime HijriToGreg(string hijri, string format)
        {
            CultureInfo arCul = new CultureInfo("ar-SA");
            UmAlQuraCalendar h = new UmAlQuraCalendar();
            arCul.DateTimeFormat.Calendar = h;

            try
            {
                DateTime tempDate = DateTime.ParseExact(hijri, format, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                if (tempDate.Year >= 1800 && tempDate.Year <= 2600)
                    return tempDate;
                else
                    throw new Exception("لا يمكن تحويل التاريخ الهجري إلى ميلادي");
            }
            catch (Exception)
            {
                throw new Exception("لا يمكن تحويل التاريخ الهجري إلى ميلادي");
            }

            //// we can chech if it is hijri or not
            //if (IsHijri(hijri, arCul))
            //{
            //    return DateTime.ParseExact(hijri, format, arCul.DateTimeFormat);
            //}
            //else
            //{
            //    throw new Exception("لا يمكن تحويل التاريخ الهجري إلى ميلادي");
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="greg">Example: 25/05/2016</PARAM>
        /// <PARAM name="format">Example: dd/MM/yyyy</PARAM>
        /// <returns></returns>
        public static string GregToHijri(DateTime greg, string format)
        {
            CultureInfo arCul = new CultureInfo("ar-SA");
            UmAlQuraCalendar h = new UmAlQuraCalendar();
            arCul.DateTimeFormat.Calendar = h;

            return greg.ToString(format, arCul.DateTimeFormat);
        }

        /// <summary>
        /// Check if string is hijri date and then return true 
        /// </summary>
        /// <PARAM name="hijri"></PARAM>
        /// <returns></returns>
        public static bool IsHijri(string hijri)
        {
            if (hijri.Length <= 0)
            {
                //cur.Trace.Warn("IsHijri Error: Date String is Empty");
                return false;
            }

            try
            {
                CultureInfo arCul = new CultureInfo("ar-SA");
                HijriCalendar h = new HijriCalendar();
                arCul.DateTimeFormat.Calendar = h;

                DateTime tempDate = DateTime.ParseExact(hijri, "dd/MM/yyyy",
                     arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
                if (tempDate.Year >= 1800 && tempDate.Year <= 2500)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                //throw new Exception("لا يمكن التحقق من صحة التاريخ الهجري");
                //cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" +  ex.Message);
                return false;
            }
        }

        /// <summary>
        /// تحويل من هجري لميلادي ومن ميلادي لهجري
        /// </summary>
        /// <param name="DateConv"></param>
        /// <param name="Calendar">HI OR GR</param>
        /// <param name="DateLangCulture">ar-sa or en-us</param>
        /// <returns></returns>
        public static string ConvertDateCalendar(string DateConv, string Calendar, string DateLangCulture, string fromat)
        {
            DateTimeFormatInfo DTFormat;
            DateLangCulture = DateLangCulture.ToLower();
            /// We can't have the hijri date writen in English. We will get a runtime error - LAITH - 11/13/2005 1:01:45 PM -

            if (Calendar == "HI" && DateLangCulture.StartsWith("en-"))
            {
                DateLangCulture = "ar-sa";
            }

            /// Set the date time format to the given culture - LAITH - 11/13/2005 1:04:22 PM -
            DTFormat = new System.Globalization.CultureInfo(DateLangCulture, false).DateTimeFormat;

            /// Set the calendar property of the date time format to the given calendar - LAITH - 11/13/2005 1:04:52 PM -
            switch (Calendar)
            {
                case "HI":
                    DTFormat.Calendar = new System.Globalization.HijriCalendar();
                    break;

                case "GR":
                    DTFormat.Calendar = new System.Globalization.GregorianCalendar();
                    break;

                default:
                    return "";
            }

            /// We format the date structure to whatever we want - LAITH - 11/13/2005 1:05:39 PM -
            DTFormat.ShortDatePattern = fromat;
            return (Convert.ToDateTime(DateConv).Date.ToString(fromat, DTFormat));



            //DateTime PDateConv = Convert.ToDateTime(DateConv);

            //DateTimeFormatInfo DTFormat;
            //DateLangCulture = DateLangCulture.ToLower();
            ///// We can't have the hijri date writen in English. We will get a runtime error

            //if (Calendar == "HI" && DateLangCulture.StartsWith("en-"))
            //{
            //    DateLangCulture = "ar-sa";
            //}

            ///// Set the date time format to the given culture
            //DTFormat = new CultureInfo(DateLangCulture, false).DateTimeFormat;

            ///// Set the calendar property of the date time format to the given calendar
            //switch (Calendar)
            //{
            //    case "HI":
            //        DTFormat.Calendar = new HijriCalendar();
            //        break;

            //    case "GR":
            //        DTFormat.Calendar = new GregorianCalendar();
            //        break;

            //    default:
            //        return "";
            //}

            ///// We format the date structure to whatever we want
            //DTFormat.ShortDatePattern = fromat;
            //return (PDateConv.Date.ToString(fromat, DTFormat));
        }

        /// <summary>
        /// Add Years or Months or days
        /// </summary>
        /// <param name="Date">yyyy/MM/dd</param>
        /// <param name="Part">Y=Year, M=Month, D=Day</param>
        /// <param name="Val">Give it Value</param>
        /// <param name="format">Give it format</param>
        /// <returns></returns>
        public static string Hij_AddPart(string Date, string Part, int Val, string format)
        {
            int Year = Convert.ToInt32(Date.Substring(0, 4));
            int Month = Convert.ToInt32(Date.Substring(5, 2));
            int day = Convert.ToInt32(Date.Substring(8, 2));

            CultureInfo arCul = new CultureInfo("ar-SA");
            UmAlQuraCalendar h = new UmAlQuraCalendar();
            arCul.DateTimeFormat.Calendar = h;

            DateTime dat = new DateTime();

            if (Part == "Y")
            {
                dat = h.AddYears(new DateTime(Year, Month, day, h), Val);
            }
            else if (Part == "D")
            {
                dat = h.AddDays(new DateTime(Year, Month, day, h), Val);
            }

            return dat.ToString(format, arCul.DateTimeFormat);
        }
        #endregion


        /// <summary>
        /// Get The public IP of Client
        /// </summary>
        /// <returns></returns>
        public string GetClientIP()
        {
            string VisitorsIPAddr = string.Empty;

            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            return VisitorsIPAddr;
        }

        /// <summary>
        /// Generate Random Code
        /// </summary>
        /// <returns></returns>
        public static int GenerateRandomCode()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 12345678);
        }

        public static int GenerateRandomCode5()
        {
            Random rnd = new Random();
            return rnd.Next(10000, 99999);
        }

        /// <summary>
        /// Generate Random Code
        /// </summary>
        /// <returns></returns>
        public static int GenerateRandom5Code()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 12345);
        }

        /// <summary>
        /// Send mails
        /// </summary>
        /// <param name="emailTo"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void SentMail(string emailTo, string subject, string body)
        {
            string smtpAddress = "iumail.iu.edu.sa";
            //int portNumber = 587;
            int portNumber = 25;
            bool enableSSL = false;

            string emailFrom = "erp_services@iu.edu.sa";
            string password = "erp_services";

            string Username = "erp_services";
            string domain = "iu.edu.sa";


            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                // Can set to false, if you are sending pure text.

                //mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
                //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(Username, password, domain);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }


            //string smtpAddress = "smtp.mail.yahoo.com";
            //int portNumber = 587;
            //bool enableSSL = true;

            //string emailFrom = "mohm4z@yahoo.com";
            //string password = "mohm05428";
            //string emailTo = "Baljjorashi@gmail.com";

            /*\
             * Gmail SMTP port (TLS): 587
             * Gmail SMTP port (SSL): 465
             */


            //string smtpAddress = "smtp.gmail.com";
            //int portNumber = 587;
            //bool enableSSL = true;

            //string emailFrom = "techvilmail@gmail.com";
            //string password = "TVIS14520";

        }


        #region File Manager

        /// دمج ملفات PDF
        public static void MergePDFs(string targetPath, params string[] pdfs)
        {
            using (PdfDocument targetDoc = new PdfDocument())
            {
                foreach (string pdf in pdfs)
                {
                    try
                    {
                        using (PdfDocument pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                        {
                            for (int i = 0; i < pdfDoc.PageCount; i++)
                            {
                                targetDoc.AddPage(pdfDoc.Pages[i]);
                            }
                        }

                        File.Delete(pdf);
                    }
                    catch (Exception)
                    {
                    }
                }

                targetDoc.Save(targetPath);
            }
        }

        /// حذف كل الملفات المؤقتة القديمة
        public static void DeleteOldTempFiles(string DirectoryName)
        {
            string[] files = Directory.GetFiles(DirectoryName);

            foreach (string file in files)
            {
                try
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.LastAccessTime < DateTime.Now.AddDays(-1))
                    {
                        fi.Delete();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        #endregion
    }


    ///// <summary>
    ///// Summary description for Dates.
    ///// </summary>
    //public class Dates
    //{
    //    private HttpContext cur;

    //    private const int startGreg = 1900;
    //    private const int endGreg = 2100;
    //    private string[] allFormats ={"yyyy/MM/dd","yyyy/M/d",
    //        "dd/MM/yyyy","d/M/yyyy",
    //        "dd/M/yyyy","d/MM/yyyy","yyyy-MM-dd",
    //        "yyyy-M-d","dd-MM-yyyy","d-M-yyyy",
    //        "dd-M-yyyy","d-MM-yyyy","yyyy MM dd",
    //        "yyyy M d","dd MM yyyy","d M yyyy",
    //        "dd M yyyy","d MM yyyy"};
    //    private CultureInfo arCul;
    //    private CultureInfo enCul;
    //    private HijriCalendar h;
    //    private GregorianCalendar g;

    //    public Dates()
    //    {
    //        cur = HttpContext.Current;

    //        arCul = new CultureInfo("ar-SA");
    //        enCul = new CultureInfo("en-US");

    //        h = new HijriCalendar();
    //        g = new GregorianCalendar(GregorianCalendarTypes.USEnglish);

    //        arCul.DateTimeFormat.Calendar = h;
    //    }

    //    /// <summary>
    //    /// Check if string is hijri date and then return true 
    //    /// </summary>
    //    /// <PARAM name="hijri"></PARAM>
    //    /// <returns></returns>
    //    public bool IsHijri(string hijri)
    //    {
    //        if (hijri.Length <= 0)
    //        {
    //            cur.Trace.Warn("IsHijri Error: Date String is Empty");
    //            return false;
    //        }

    //        try
    //        {
    //            DateTime tempDate = DateTime.ParseExact(hijri, allFormats,
    //                 arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
    //            if (tempDate.Year >= startGreg && tempDate.Year <= endGreg)
    //                return true;
    //            else
    //                return false;
    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("IsHijri Error :" + hijri.ToString() + "\n" +
    //                              ex.Message);
    //            return false;
    //        }
    //    }

    //    /// <summary>
    //    /// Check if string is Gregorian date and then return true 
    //    /// </summary>
    //    /// <PARAM name="greg"></PARAM>
    //    /// <returns></returns>
    //    public bool IsGreg(string greg)
    //    {
    //        if (greg.Length <= 0)
    //        {

    //            cur.Trace.Warn("IsGreg :Date String is Empty");
    //            return false;
    //        }
    //        try
    //        {
    //            DateTime tempDate = DateTime.ParseExact(greg, allFormats,
    //                enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
    //            if (tempDate.Year >= startGreg && tempDate.Year <= endGreg)
    //                return true;
    //            else
    //                return false;
    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("IsGreg Error :" + greg.ToString() + "\n" + ex.Message);
    //            return false;
    //        }

    //    }

    //    /// <summary>
    //    /// Return Formatted Hijri date string 
    //    /// </summary>
    //    /// <PARAM name="date"></PARAM>
    //    /// <PARAM name="format"></PARAM>
    //    /// <returns></returns>
    //    public string FormatHijri(string date, string format)
    //    {
    //        if (date.Length <= 0)
    //        {

    //            cur.Trace.Warn("Format :Date String is Empty");
    //            return "";
    //        }
    //        try
    //        {
    //            DateTime tempDate = DateTime.ParseExact(date,
    //               allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
    //            return tempDate.ToString(format, arCul.DateTimeFormat);

    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("Date :\n" + ex.Message);
    //            return "";
    //        }

    //    }

    //    /// <summary>
    //    /// Returned Formatted Gregorian date string
    //    /// </summary>
    //    /// <PARAM name="date"></PARAM>
    //    /// <PARAM name="format"></PARAM>
    //    /// <returns></returns>
    //    public string FormatGreg(string date, string format)
    //    {
    //        if (date.Length <= 0)
    //        {
    //            cur.Trace.Warn("Format :Date String is Empty");
    //            return "";
    //        }
    //        try
    //        {
    //            DateTime tempDate = DateTime.ParseExact(date, allFormats,
    //                enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
    //            return tempDate.ToString(format, enCul.DateTimeFormat);

    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("Date :\n" + ex.Message);
    //            return "";
    //        }

    //    }

    //    /// <summary>
    //    /// Return Today Gregorian date and return it in yyyy/MM/dd format
    //    /// </summary>
    //    /// <returns></returns>
    //    public string GDateNow()
    //    {
    //        try
    //        {
    //            return DateTime.Now.ToString("yyyy/MM/dd", enCul.DateTimeFormat);
    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("GDateNow :\n" + ex.Message);
    //            return "";
    //        }
    //    }

    //    /// <summary>
    //    /// Return formatted today Gregorian date based on your format
    //    /// </summary>
    //    /// <PARAM name="format"></PARAM>
    //    /// <returns></returns>
    //    public string GDateNow(string format)
    //    {
    //        try
    //        {
    //            return DateTime.Now.ToString(format, enCul.DateTimeFormat);
    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("GDateNow :\n" + ex.Message);
    //            return "";
    //        }
    //    }

    //    /// <summary>
    //    /// Return Today Hijri date and return it in yyyy/MM/dd format
    //    /// </summary>
    //    /// <returns></returns>
    //    public string HDateNow()
    //    {
    //        try
    //        {
    //            return DateTime.Now.ToString("yyyy/MM/dd", arCul.DateTimeFormat);
    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("HDateNow :\n" + ex.Message);
    //            return "";
    //        }
    //    }

    //    /// <summary>
    //    /// Return formatted today hijri date based on your format
    //    /// </summary>
    //    /// <PARAM name="format"></PARAM>
    //    /// <returns></returns>
    //    public string HDateNow(string format)
    //    {
    //        try
    //        {
    //            return DateTime.Now.ToString(format, arCul.DateTimeFormat);
    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("HDateNow :\n" + ex.Message);
    //            return "";
    //        }

    //    }

    //    /// <summary>
    //    /// Convert Hijri Date to it's equivalent Gregorian Date
    //    /// </summary>
    //    /// <PARAM name="hijri"></PARAM>
    //    /// <returns></returns>
    //    public string HijriToGreg(string hijri)
    //    {

    //        if (hijri.Length <= 0)
    //        {

    //            cur.Trace.Warn("HijriToGreg :Date String is Empty");
    //            return "";
    //        }
    //        try
    //        {
    //            DateTime tempDate = DateTime.ParseExact(hijri, allFormats,
    //               arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
    //            return tempDate.ToString("yyyy/MM/dd", enCul.DateTimeFormat);
    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("HijriToGreg :" + hijri.ToString() + "\n" + ex.Message);
    //            return "";
    //        }
    //    }

    //    /// <summary>
    //    /// Convert Hijri Date to it's equivalent Gregorian Date
    //    /// and return it in specified format
    //    /// </summary>
    //    /// <PARAM name="hijri"></PARAM>
    //    /// <PARAM name="format"></PARAM>
    //    /// <returns></returns>
    //    public string HijriToGreg(string hijri, string format)
    //    {

    //        if (hijri.Length <= 0)
    //        {

    //            cur.Trace.Warn("HijriToGreg :Date String is Empty");
    //            return "";
    //        }
    //        try
    //        {
    //            DateTime tempDate = DateTime.ParseExact(hijri,
    //               allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
    //            return tempDate.ToString(format, enCul.DateTimeFormat);

    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("HijriToGreg :" + hijri.ToString() + "\n" + ex.Message);
    //            return "";
    //        }
    //    }

    //    /// <summary>
    //    /// Convert Gregoian Date to it's equivalent Hijir Date
    //    /// </summary>
    //    /// <PARAM name="greg"></PARAM>
    //    /// <returns></returns>
    //    public string GregToHijri(string greg)
    //    {

    //        if (greg.Length <= 0)
    //        {

    //            cur.Trace.Warn("GregToHijri :Date String is Empty");
    //            return "";
    //        }
    //        try
    //        {
    //            DateTime tempDate = DateTime.ParseExact(greg, allFormats,
    //                enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
    //            return tempDate.ToString("yyyy/MM/dd", arCul.DateTimeFormat);

    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("GregToHijri :" + greg.ToString() + "\n" + ex.Message);
    //            return "";
    //        }
    //    }

    //    /// <summary>
    //    /// Convert Hijri Date to it's equivalent Gregorian Date and
    //    /// return it in specified format
    //    /// </summary>
    //    /// <PARAM name="greg"></PARAM>
    //    /// <PARAM name="format"></PARAM>
    //    /// <returns></returns>
    //    public string GregToHijri(string greg, string format)
    //    {

    //        if (greg.Length <= 0)
    //        {

    //            cur.Trace.Warn("GregToHijri :Date String is Empty");
    //            return "";
    //        }
    //        try
    //        {

    //            DateTime tempDate = DateTime.ParseExact(greg, allFormats,
    //                enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
    //            return tempDate.ToString(format, arCul.DateTimeFormat);

    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("GregToHijri :" + greg.ToString() + "\n" + ex.Message);
    //            return "";
    //        }
    //    }

    //    /// <summary>
    //    /// Return Gregrian Date Time as digit stamp
    //    /// </summary>
    //    /// <returns></returns>
    //    public string GTimeStamp()
    //    {
    //        return GDateNow("yyyyMMddHHmmss");
    //    }

    //    /// <summary>
    //    /// Return Hijri Date Time as digit stamp
    //    /// </summary>
    //    /// <returns></returns>
    //    public string HTimeStamp()
    //    {
    //        return HDateNow("yyyyMMddHHmmss");
    //    }

    //    /// <summary>
    //    /// Compare two instaces of string date 
    //    /// and return indication of thier values 
    //    /// </summary>
    //    /// <PARAM name="d1"></PARAM>
    //    /// <PARAM name="d2"></PARAM>
    //    /// <returns>positive d1 is greater than d2,
    //    /// negative d1 is smaller than d2, 0 both are equal</returns>
    //    public int Compare(string d1, string d2)
    //    {
    //        try
    //        {
    //            DateTime date1 = DateTime.ParseExact(d1, allFormats,
    //                arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
    //            DateTime date2 = DateTime.ParseExact(d2, allFormats,
    //                arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
    //            return DateTime.Compare(date1, date2);
    //        }
    //        catch (Exception ex)
    //        {
    //            cur.Trace.Warn("Compare :" + "\n" + ex.Message);
    //            return -1;
    //        }

    //    }
    //}
}