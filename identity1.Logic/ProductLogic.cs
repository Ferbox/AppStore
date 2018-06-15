using System;
using System.Linq;
using System.Collections.Generic;
using identity1.Common.Entities;
using identity1.DALContracts;
using identity1.LogicContracts;
using identity1.Common.Models.ViewModels;
using System.Threading.Tasks;
using System.Web;
using identity1.Common.Models.Enums;

namespace identity1.Logic
{
    public class ProductLogic:IProductLogic
    {
        private readonly IProductDao productDao;

        public ProductLogic(IProductDao _productDao)
        {
            productDao = _productDao;
        }
        public async Task<Product> GetProduct(int id)
        {
            var product = productDao.GetProduct(id);
            return await product;
        }
        public IEnumerable<Product> GetProducts(int[] prodInCart)
        {
            var products = productDao.GetProducts(prodInCart);
            return products;
        }
        public IEnumerable<ProdCatalogViewModel> GetProducts(int type)
        {
            var products = productDao.GetProducts(type);
            return products;
        }
        public void CreateOrder(Order order, string id, int[] orderlist, int[] qty)
        {
            productDao.CreateOrder(order, id, orderlist, qty);
        }

        public void CreateProduct(Product product, string[] charak, List<string> files)
        {
            int typeId = DefineType(charak[0]);
            if (typeId == (int)Enums.TypeProduct.phone)
            {
                product.MemberId = DefineMember(charak[1]);
                product.ColorId = DefineColor(charak[2]);
                product.DisplayId = DefineDisplay(charak[3]);
            }
            else if (typeId == (int)Enums.TypeProduct.laptop)
            {
                product.MemberId = DefineMember(charak[1]);
                product.ColorId = DefineColor(charak[2]);
                product.DisplayId = DefineDisplay(charak[3]);
                product.TouchBar = charak[4] == "Есть" ? true : false;
            }
            else if (typeId == (int)Enums.TypeProduct.tablet)
            {
                product.MemberId = DefineMember(charak[1]);
                product.ColorId = DefineColor(charak[2]);
                product.DisplayId = DefineDisplay(charak[3]);
                product.Cellular = charak[4] == "Есть" ? true : false;
            }
            else if (typeId == (int)Enums.TypeProduct.monoblock)
            {
                product.MemberId = DefineMember(charak[1]);
                product.ColorId = DefineColor(charak[2]);
                product.DisplayId = DefineDisplay(charak[3]);
            }
            else if (typeId == (int)Enums.TypeProduct.watch)
            {
                product.ColorId = DefineColor(charak[1]);
                product.SizeBodyId = charak[2] == "38mm" ? (int)Enums.SizeBodyWatch._38mm : (int)Enums.SizeBodyWatch._38mm;
            }
            productDao.CreateProduct(product, files);
        }

        private int DefineDisplay(string type)
        {
            if (type == "9,7")
                return (int)Enums.Displays.ipad;
            else if (type == "10,5")
                return (int)Enums.Displays.ipadPro_10;
            else if (type == "12,9")
                return (int)Enums.Displays.ipadPro_13;
            else if (type == "21")
                return (int)Enums.Displays.imac_21;
            else if (type == "27")
                return (int)Enums.Displays.imac_27;
            else if (type == "12")
                return (int)Enums.Displays.macbook;
            else if (type == "13")
                return (int)Enums.Displays.macAirOrPro;
            else if (type == "15")
                return (int)Enums.Displays.macPro;
            else if (type == "5,8")
                return (int)Enums.Displays.iphoneX;
            else if (type == "4,7")
                return (int)Enums.Displays.iphone6s78;
            else if (type == "5,5")
                return (int)Enums.Displays.iphone6s78Plus;
            else if (type == "4")
                return (int)Enums.Displays.iphoneSE;
            else
                return (int)Enums.Displays.ipadmini;
        }

        private int DefineColor(string type)
        {
            if (type.ToLower() == "Red".ToLower())
                return (int)Enums.Color.red;
            else if (type.ToLower() == "Space gray".ToLower())
                return (int)Enums.Color.spacegray;
            else if (type.ToLower() == "Silver".ToLower())
                return (int)Enums.Color.silver;
            else if (type.ToLower() == "Rose".ToLower())
                return (int)Enums.Color.rose;
            else if (type.ToLower() == "Rose gold".ToLower())
                return (int)Enums.Color.rosegold;
            else if (type.ToLower() == "Gold".ToLower())
                return (int)Enums.Color.gold;
            else if (type.ToLower() == "Jet black".ToLower())
                return (int)Enums.Color.jetblack;
            else 
                return (int)Enums.Color.black;

        }

        private int DefineMember(string type)
        {
            if (type == "16GB")
                return (int)Enums.MemberSize._16gb;
            else if (type == "32GB")
                return (int)Enums.MemberSize._32gb;
            else if (type == "64GB")
                return (int)Enums.MemberSize._64gb;
            else if (type == "128GB")
                return (int)Enums.MemberSize._128gb;
            else if (type == "256GB")
                return (int)Enums.MemberSize._256gb;
            else if (type == "512GB")
                return (int)Enums.MemberSize._512gb;
            else if (type == "1000GB")
                return (int)Enums.MemberSize._1000gb;
            else
                return (int)Enums.MemberSize._2000gb;
        }

        public int DefineType(string type)
        {
            if (type == "iPhone")
                return (int)Enums.TypeProduct.phone;
            else if (type == "MacBook")
                return (int)Enums.TypeProduct.laptop;
            else if (type == "iPad")
                return (int)Enums.TypeProduct.tablet;
            else if (type == "iMac")
                return (int)Enums.TypeProduct.monoblock;
            else
                return (int)Enums.TypeProduct.watch;
        }
    }
}
