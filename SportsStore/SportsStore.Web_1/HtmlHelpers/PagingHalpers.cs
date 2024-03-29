﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using SportsStore.Web_1.Models;
namespace SportsStore.Web_1.HtmlHelpers
{
    public  static class PagingHalpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,PagingInfo pagingInfo,
                                                            Func< int,string > pageurl)
        {
            StringBuilder result= new StringBuilder();
            for (int i = 1; i <=pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href",pageurl(i));
                tag.InnerHtml = i.ToString()+">"+" ";
                if (i==pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    

                }
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}