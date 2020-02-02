using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.Common.Interfaces
{
    public interface IEnumHelper
    {
        string GetEnumDescription(Enum value);
        List<SelectListItem> GetEnumListWithDescription(Type type);
        List<SelectListItem> GetEnumListWithDescriptionNode(Type type);
        List<SelectListItem> GetEnumListWithDescriptionNumber(Type type);

        /// <summary>
        /// Name'i string olarak gönderilen enum'ı döndürür. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        object StringToEnumName<T>(string name);

        /// <summary>
        /// Name'i string olarak gönderilen enum'ın value'sunu döndürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        int StringToEnumValue<T>(string name);

        /// <summary>
        /// Value'su int olarak gönderilen enum'ın name'ini döndürür.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        string IntToEnumName<T>(int value);

        /// <summary>
        /// Objeden gelen değerin o enum'da olup olmadığını kontrol eder.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsEnum<T>(object value);
    }
}
