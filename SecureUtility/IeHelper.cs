using System;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using mshtml;

namespace SecureUtility {
    public static class IeHelper {
        public static void AutoComplete(DriveInfo foundDrives) {
            try {
                SHDocVw.ShellWindows sws = new SHDocVw.ShellWindows();

                foreach (SHDocVw.InternetExplorer iw in sws) {
                    //MessageBox.Show(iw.LocationURL);
                    if (iw.LocationName == "微博-随时随地发现新鲜事" && iw.LocationURL.Contains("http://weibo.com")) {
                        //MessageBox.Show(doc.DomDocument.ToString());
                        mshtml.HTMLDocument doc = (mshtml.HTMLDocument)iw.Document;
                        //MessageBox.Show(doc.body.toString());
                        //HtmlDocument d = new HtmlDocument();
                        //d.Load(doc.documentElement.innerHTML);
                        //MessageBox.Show((doc.getElementsByName("username").length.ToString()));
                        var ih = new IniFiles(foundDrives.RootDirectory + "\\" + "Sec.ini");
                        NameValueCollection Values = new NameValueCollection();
                        ih.ReadSectionValues("Blog", Values);
                        ((HTMLInputTextElement)(doc.getElementsByName("username").item(0))).value = Values["User"];
                        ((HTMLInputTextElement)(doc.getElementsByName("password").item(0))).value = Values["Pwd"];
                        //((HTMLButtonElement)doc.getElementById("btn_login")).click();
                    }
                }
            }
            catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
            //MessageBox.Show(winTxt);
        }
    }
}
