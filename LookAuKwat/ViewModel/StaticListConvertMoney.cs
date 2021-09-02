
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LookaukwatApp.ViewModels
{
    public class StaticListConvertMoney
    {
       

        public static string GetSymbol(string productCountry)
        {
            string result = null;
            if (productCountry == "Autriche" || productCountry == "Belgique" || productCountry == "Chypre" || productCountry == "Estonie" ||
                productCountry == "Finlande" || productCountry == "France" || productCountry == "Allemagne" || productCountry == "Grèce" ||
                productCountry == "Irlande" || productCountry == "Italie" || productCountry == "Lettonie" || productCountry == "Lituanie" ||
                productCountry == "Luxembourg" || productCountry == "Malte" || productCountry == "Pays-Bas" || productCountry == "Portugal" ||
                productCountry == "Slovaquie" || productCountry == "Slovénie" || productCountry == "Espagne")
            {
                result = "€";
            }
            else if (productCountry == "Royaume-Uni")
            {
                result = "£";
            }
            else if (productCountry == "Canada" || productCountry == "États-Unis")
            {
                result = "$";
            }
            else if (productCountry == "Nigéria")
            {
                result = "₦";
            }
            else if (productCountry == "Rwanda")
            {
                result = "FRw";
            }
            else if (productCountry== "Maroc")
            {
                result = "MAD";
            }
            else if (productCountry== "Tunisie")
            {
                result = "TND";
            } 
            else if (productCountry== "Algérie")
            {
                result = "DZD";
            }
            else if (productCountry== "Afrique du sud")
            {
                result = "Rand";
            }
            else if (productCountry== "Chine")
            {
                result = "CNY";
            }
            else if (productCountry== "Mexique")
            {
                result = "MXN";
            }
            else if (productCountry== "Argentine")
            {
                result = "ARS";
            } 
            else if (productCountry== "Brésil")
            {
                result = "R$";
            }
            else
            {
                result = "Fcfa";
            }

            return result;
        }

        //public static string GetStripeSymbol()
        //{
        //    string result = null;
           
        //    if (Settings.CountryUser == "Autriche" || Settings.CountryUser == "Belgique" || Settings.CountryUser == "Chypre" || Settings.CountryUser == "Estonie" ||
        //        Settings.CountryUser == "Finlande" || Settings.CountryUser == "France" || Settings.CountryUser == "Allemagne" || Settings.CountryUser == "Grèce" ||
        //        Settings.CountryUser == "Irlande" || Settings.CountryUser == "Italie" || Settings.CountryUser == "Lettonie" || Settings.CountryUser == "Lituanie" ||
        //        Settings.CountryUser == "Luxembourg" || Settings.CountryUser == "Malte" || Settings.CountryUser == "Pays-Bas" || Settings.CountryUser == "Portugal" ||
        //        Settings.CountryUser == "Slovaquie" || Settings.CountryUser == "Slovénie" || Settings.CountryUser == "Espagne")
        //    {
        //        result = "eur";
        //    }
        //    else if (Settings.CountryUser == "Burkina Faso" || Settings.CountryUser == "Côte d'ivoire")
        //    {
        //        result = "xof";
        //    }
        //    else if (Settings.CountryUser == "Canada")
        //    {
        //        result = "cad";
        //    }
        //    else if (Settings.CountryUser == "États-Unis")
        //    {
        //        result = "usd";
        //    }
        //    else if (Settings.CountryUser == "Rwanda")
        //    {
        //        result = "rwf";
        //    }
        //    else if (Settings.CountryUser == "Royaume-Uni")
        //    {
        //        result = "gbp";
        //    }
        //    else if (Settings.CountryUser == "Maroc")
        //    {
        //        result = "mad";
        //    }
        //    else if (Settings.CountryUser == "Tunisie")
        //    {
        //        result = "tnd";
        //    }
        //    else if (Settings.CountryUser == "Algérie")
        //    {
        //        result = "dzd";
        //    }
        //    else if (Settings.CountryUser == "Afrique du sud")
        //    {
        //        result = "zar";
        //    }
        //    else if (Settings.CountryUser == "Chine")
        //    {
        //        result = "cny";
        //    }
        //    else if (Settings.CountryUser == "Mexique")
        //    {
        //        result = "mxn";
        //    }
        //    else if (Settings.CountryUser == "Argentine")
        //    {
        //        result = "ars";
        //    }
        //    else if (Settings.CountryUser == "Brésil")
        //    {
        //        result = "brl";
        //    }
        //    else if (Settings.CountryUser == "Brésil")
        //    {
        //        result = "brl";
        //    }
        //    else
        //    {
        //        result = "xaf";
        //    }

        //    return result;
         
        //}


        public static string GetZeroPriceDefinition(string category)
        {
            var ci = Thread.CurrentThread.CurrentCulture;
            if (category == "Emploi")
            {

                if (ci.Name.ToLower().Contains("fr"))
                {
                    return "Salaire à négocier";
                }

                else if (ci.Name.ToLower().Contains("de"))
                {
                    return "Gehalt muss ausgehandelt werden";
                }
                else if (ci.Name.ToLower().Contains("ar"))
                {
                    return "الراتب المراد التفاوض بشأنه";
                }
                else if (ci.Name.ToLower().Contains("es"))
                {
                    return "Salario a negociar";
                }
                else if (ci.Name.ToLower().Contains("it"))
                {
                    return "Stipendio da negoziare";
                }
                else if (ci.Name.ToLower().Contains("pt"))
                {
                    return "Salário a ser negociado";
                }
                else if (ci.Name.ToLower().Contains("zh"))
                {
                    return "薪资面议";
                }
                else
                {

                    return "Salary to be negociated";
                }

            }
            else
            {
                if (ci.Name.ToLower().Contains("fr"))
                {
                    return "Prix à négocier";
                }
                else if (ci.Name.ToLower().Contains("de"))
                {
                    return "Preis zu verhandeln";
                }
                else if (ci.Name.ToLower().Contains("ar"))
                {
                    return "السعر للتفاوض";
                }
                else if (ci.Name.ToLower().Contains("es"))
                {
                    return "Precio a negociar";
                }
                else if (ci.Name.ToLower().Contains("it"))
                {
                    return "Prezzo da negoziare";
                }
                else if (ci.Name.ToLower().Contains("pt"))
                {
                    return "Preço a ser negociado";
                }
                else if (ci.Name.ToLower().Contains("zh"))
                {
                    return "价格有待商议";
                }
                else
                {

                    return "Price to be negotiated";
                }
            }
        }
    }
}
