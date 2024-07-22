/**
 * Copyright 2006-2018 Gustavo Augusto Hennig
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 **/
using System;
using System.Collections.Generic;
using System.Text;
using SimpleDatabaseReplicator.UI;
using System.Resources;
using System.Globalization;
using System.Threading;

namespace SimpleDatabaseReplicator
{
    public class Functions
    {

        public static CultureInfo culture = Thread.CurrentThread.CurrentUICulture;


  

        public static bool EqualsValue(object obj1, object obj2)
        {

            bool ret;

            //const int Fator = 10000;

            if (obj1 is DBNull || obj2 is DBNull)
            {
                return (obj1 == obj2);
            }

            switch (obj1.GetType().Name)
            {
                case "Int32":
                case "Int16":
                case "Int64":
                case "Byte":
                case "Decimal":
                case "Float":
                case "Double":
                    ret = (Math.Round(Convert.ToDouble(obj1), 8) == Math.Round(Convert.ToDouble(obj2), 8));
                    break;
                case "DateTime":
                    //Truncate in seconds
                    DateTime dt1 = (DateTime)obj1;
                    DateTime dt2 = (DateTime)obj2;
                    if (dt1 <= Preferences.Settings.MinDateTime && dt2 <= Preferences.Settings.MinDateTime)
                        ret = true;
                    else
                        ret = Math.Floor((double)dt1.Ticks / 10000000) == Math.Floor((double)dt2.Ticks / 10000000);
                    break;
                default:
                    ret = true;
                    if (!obj1.Equals(obj2))
                    {
                        if (obj1 != obj2)
                        {
                            ret = false;
                        }
                    }
                    break;
            }
            return ret;
        }
        public static string RemoveLastChars(string source, int NoChars)
        {
            return source.Substring(0, source.Length - NoChars);
        }


        public static void ChangeCulture(string CultureName)
        {
            culture = new CultureInfo(CultureName);
        }
    }
    public struct CulturesImplemented
    {
        public const string English = "en-US";
        public const string Português_Brasileiro = "pt-BR";
    }
}
