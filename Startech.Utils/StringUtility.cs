using System;
using System.Collections.Generic;
using System.Text;

namespace Startech.Utils
{
   public class StringUtility
    {
       private  StringUtility()
       { }

       /// <summary>
       /// ����������ת�����ַ�����
       /// </summary>
       /// <param name="intArray">��������</param>
       /// <returns>�ַ�����</returns>
       public static string[] TranslateToStringArray(int[] intArray)
       {
           string[] stringArray = new string[intArray.Length];
           for (int i = 0; i < intArray.Length; i++)
           {
               stringArray[i] = intArray[i].ToString();
           }
           return stringArray;
       }
    }
}
