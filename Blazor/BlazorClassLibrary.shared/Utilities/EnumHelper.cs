using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorClassLibrary.shared.Utilities
{
    public class EnumHelper
    {
        public static List<DropDownListItem> ConvertEnumToDropDownSource<T>(string initialText,string initialValue)
        {
            List<DropDownListItem> ret = new List<DropDownListItem>();
            var values = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            if (!string.IsNullOrEmpty(initialValue)||!string.IsNullOrEmpty(initialText)) 
            {
                DropDownListItem dropDownList = new DropDownListItem()
                {
                    Text = initialText,
                    Value = initialValue
                };
                ret.Add(dropDownList);
            }
            for (int i = 0; i < values.Count; i++) 
            {
                DropDownListItem item = new DropDownListItem();
                item.Text = Enum.GetNames(typeof(T))[i];
                item.Value = values[i].ToString();
                ret.Add(item);
            }
            return ret;
        }
    }
}
