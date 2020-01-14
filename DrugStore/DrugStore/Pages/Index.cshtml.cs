using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrugStore.Pages
{
    public class IndexModel : PageModel
    {
        public static List<List<string>> DrugStoresList = new List<List<string>>();

        public void OnGet()
        {

        }

        public static string getInfo()
        {
            XmlDocument doc = new XmlDocument();
            var fileName = "\\drugStoreList.xml";
            var path = System.IO.Directory.GetCurrentDirectory() + fileName;
            doc.Load(path);
            XElement e = XElement.Load(new XmlNodeReader(doc));
            var drugStores = e.Elements("data");

            foreach (var item in drugStores)
            {
                var store = item.Elements();

                DrugStoresList.Add(new List<string>()
                {
                    store.ElementAt(0).Value,
                    store.ElementAt(1).Value,
                    store.ElementAt(2).Value,
                    store.ElementAt(3).Value,
                    store.ElementAt(4).Value,
                    store.ElementAt(5).Value
                });

            }
            return "";
        }

    }
}
