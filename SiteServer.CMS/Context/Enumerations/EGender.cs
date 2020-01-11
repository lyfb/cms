using System;
using System.Web.UI.WebControls;

namespace SiteServer.CMS.Context.Enumerations
{
	public enum EGender
	{
		NotSet,
		Male,
		Female
	}

	public class EGenderUtils
	{
		public static string GetValue(EGender type)
		{
		    if (type == EGender.NotSet)
			{
				return "NotSet";
			}
		    if (type == EGender.Male)
		    {
		        return "Male";
		    }
		    if (type == EGender.Female)
		    {
		        return "Female";
		    }
		    throw new Exception();
		}

		public static string GetText(EGender type)
		{
		    if (type == EGender.NotSet)
			{
				return "未设置";
			}
		    if (type == EGender.Male)
		    {
		        return "男";
		    }
		    if (type == EGender.Female)
		    {
		        return "女";
		    }
		    throw new Exception();
		}

		public static EGender GetEnumType(string typeStr)
		{
			var retVal = EGender.NotSet;

			if (Equals(EGender.Male, typeStr))
			{
				retVal = EGender.Male;
			}
			else if (Equals(EGender.Female, typeStr))
			{
				retVal = EGender.Female;
			}

			return retVal;
		}

		public static bool Equals(EGender type, string typeStr)
		{
			if (string.IsNullOrEmpty(typeStr)) return false;
			if (string.Equals(GetValue(type).ToLower(), typeStr.ToLower()))
			{
				return true;
			}
			return false;
		}

        public static bool Equals(string typeStr, EGender type)
        {
            return Equals(type, typeStr);
        }

		public static ListItem GetListItem(EGender type, bool selected)
		{
			var item = new ListItem(GetText(type), GetValue(type));
			if (selected)
			{
				item.Selected = true;
			}
			return item;
		}

        public static void AddListItems(ListControl listControl)
        {
            if (listControl != null)
            {
                listControl.Items.Add(GetListItem(EGender.NotSet, false));
                listControl.Items.Add(GetListItem(EGender.Male, false));
                listControl.Items.Add(GetListItem(EGender.Female, false));
            }
        }
	}
}