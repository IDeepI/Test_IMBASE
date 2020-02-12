using ImBase;
using System;
using System.Diagnostics;
//ImBase_TLB

namespace Test_IMBASE
{
    class Program
    {
        static ImbaseApplicationClass ImbApplication = new ImbaseApplicationClass();
        static ImDataBaseClass ImDataBase = new ImDataBaseClass();

        //   public static ImbaseCatalogs Catalogs;       
        //  public static ImbaseCatalog Catalog;
        //  public static ImbaseFolder Folder;
        //  public static IImbaseKey ImBase;

        public static string[] ImCodes =
        {
            "i609010608031E000187",
            "i6090106080E9B000024",
            "i60901060803BB000008",
            "i60901060803330000C2",
            "i60901060802950000EB",
            "i609010608034B0000ED",
            "i6090106080E95000098",
            "i60901060803150001A9",
            "i60901060803150001AA",
            "i6090106080339000110",
            "i609010608033D0001A8",
            "i6090106080ED4000109",
            "i6090106080ED400010A",
            "i609010608035700003F",
            "i6090106080ED500005D",
            "i609010608038E00004B",
            "i609010608028B0004E7",
            "i6090106080F0F000015",
            "i6090106080343000106",
            "i6090106080343000107",
            "i60901060803450000E4",
            "i6090106080EAD000012",
            "i60901060803340000D2",
            "i60901060802940001C7",
            "i609010608036500002A",
            "i6090106080365000022",
            "i6090106080E5900000C"
        };
        static DateTime TimeStart = DateTime.Now;
        static void Main()
        {
            Debug.WriteLine(TimeStart);

            if (CheckImbaseConnection())
            {
                var a = CheckByImbaseKey("i6090106080365000022");
            }
        }

        public static string CheckByImbaseKey(string ImCode)
        {
            ImDataBase.GetKeyInfo(ImCode, out string TableRecord, out string CatalogRecord, out string KeysList);
            //      Debug.WriteLine(TableRecord);
            //      Debug.WriteLine(CatalogRecord);
            //      Debug.WriteLine(KeysList);

            int startIndex = CatalogRecord.IndexOf("\"ПОЛНОЕ ОБОЗНАЧЕНИЕ=") + 20;
            //  Debug.WriteLine(startIndex);

            int endIndex = CatalogRecord.IndexOf("\",КЛАСС=");
            //  Debug.WriteLine(endIndex);

            var FullDesignation = CatalogRecord.Substring(startIndex, endIndex - startIndex);

            Debug.WriteLine(FullDesignation);

            Debug.WriteLine(DateTime.Now - TimeStart);
            // Console.ReadLine();
            ImbApplication = null;
            ImDataBase = null;

            return FullDesignation;
        }


        static bool CheckImbaseConnection()
        {
            bool Done = false;
            try
            {
                // Создаем новое подключение, если указатель нулевой
                //
                // if (ImbApplication == null) ImbApplication = CoImbaseApplication.Create();
                // Проверяем состояние сервера
                while (!Done)
                { // Опрос состояния
                    switch (ImbApplication.Status)
                    {
                        case ImBaseLoadStatus.IST_READY:
                            Done = true;
                            break; // Система готова
                        case ImBaseLoadStatus.IST_WAITFORLOGIN:
                        case ImBaseLoadStatus.IST_INTERNALLOADING:
                            // Система ожидает ввода пароля или загружается. Надо подождать.
                            System.Threading.Thread.Sleep(10);
                            break;
                    } // switch
                } // while
            } // try
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);

                // System.Windows.Forms.MessageBox.(e);

                return false;
            }
            Debug.WriteLine(ImbApplication.Status);
            return true;

        }

    }
}


/*
               int Count = ImbApplication.Catalogs.Count;
               Debug.WriteLine(Count);

               Catalogs = ImbApplication.Catalogs;

               Debug.WriteLine(Catalogs.Count);
               ImbApplication.Restore();

               // Получить Каталог по имени
               Catalog = Catalogs.Item("Конструкторский");
               Debug.WriteLine(Catalog.Name);
               // Получить Каталог по имени таблицы
               Catalog = Catalogs.Item("Элтехника");
               Debug.WriteLine(Catalog.Name);
               // Получить Каталог по имени таблицы
               Folder = Catalog.FindFolder("Прочие изделия", ImFindObject.IFO_NAME);
               if (Folder != null) 
                   Debug.WriteLine(Folder.Name);
                  */
/*
//Индикатор ; УВНУ-6-35ДK; 900мм         i60901060803BB000008
ImDataBase.GetKeyData("i60901060803BB000008", out string TableRec);
Debug.WriteLine(TableRec);       

Debug.WriteLine(ImDataBase.GetKeyDataEx("i60901060803BB000008"));   
*/

/*
               GuidAttribute IMyInterfaceAttribute = (GuidAttribute)Attribute.GetCustomAttribute(typeof(IImbaseCatalogs), typeof(GuidAttribute));
               Debug.WriteLine("IMyInterface Attribute: " + IMyInterfaceAttribute.Value);
               Guid myGuid = new Guid(IMyInterfaceAttribute.Value);

               // Use the CLSID to instantiate the COM object using interop.
               Type type = Type.GetTypeFromCLSID(myGuid);
               Object comObj = Activator.CreateInstance(type);

               // Return a pointer to the objects IUnknown interface.
               IntPtr pIUnk = Marshal.GetIUnknownForObject(comObj);
               IntPtr pInterface;
               Int32 result = Marshal.QueryInterface(pIUnk, ref myGuid, out pInterface);



               int Count = iCatalogs.Count;
              for (int Index = 0; Index < Count; Index++)
              {
                  // Перебор всех Каталогов последовательно от первого до последнего
                  iCatalog = iCatalogs.Item(Index);
                  Debug.WriteLine(iCatalog.Name);
              } 


               */
