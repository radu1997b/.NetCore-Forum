using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cross_cutting.Extensions
{
    public static class SelectListItemExtension
    {
        private const string DefaultOption = "Choose one";

        public static IEnumerable<SelectListItem> ToSelectList<T>(
          this IEnumerable<T> source,
          long selectedId,
          bool useDefaultOption,
          Func<T, long> valueFunc,
          Func<T, string> textFieldFunc)
        {
            return ToSelectList(source, new List<long> { selectedId }, useDefaultOption, DefaultOption, x => valueFunc(x).ToString(), textFieldFunc);
        }

        public static IEnumerable<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> source,
            IList<long> selectedIds,
            bool useDefaultOption,
            Func<T, long> valueFunc,
            Func<T, string> textFieldFunc)
        {
            return ToSelectList(source, selectedIds, useDefaultOption, DefaultOption,
                x => valueFunc(x).ToString(), textFieldFunc, false);
        }


        public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> source,
            long selectedId, bool useDefaultOption,
            string defaultOptionText, Func<T, long> valueFieldFunc, Func<T, string> textFieldFunc)
        {
            return ToSelectList(
                source,
                new List<long> { selectedId }, useDefaultOption, defaultOptionText,
                x => valueFieldFunc(x).ToString(), textFieldFunc);
        }


        public static IEnumerable<SelectListItem> ToSelectList<T>(
            this IEnumerable<T> source,
            IList<long> selectedIds,
            bool useDefaultOption,
            string defaultOptionText,
            Func<T, string> valueFunc,
            Func<T, string> textFieldFunc,
            bool valueIsEncrupted = true)
        {
            if (source == null)
                return new List<SelectListItem>();

            var selectListData = new List<SelectListItem>();
            if (useDefaultOption)
            {
                selectListData.Add(new SelectListItem
                {
                    Value = string.Empty,
                    Text = defaultOptionText
                });
            }

            selectListData.AddRange(from s in source
                                    select new SelectListItem
                                    {
                                        Value = valueFunc(s),
                                        Text = textFieldFunc(s),
                                    });

            if (valueIsEncrupted)
            {
                selectListData.ForEach(x => x.Selected = selectedIds != null &&
                                                         selectedIds.Count != 0 &&
                                                         selectedIds.Any(
                                                             z =>
                                                                 !string.IsNullOrEmpty(x.Value) &&
                                                                 z.ToString() ==
                                                                 ((x.Value)).ToString()));
            }
            else
            {
                selectListData.ForEach(x => x.Selected = selectedIds != null &&
                                                         selectedIds.Count != 0 &&
                                                         selectedIds.Any(
                                                             z =>
                                                                 !string.IsNullOrEmpty(x.Value) &&
                                                                 z.ToString() == x.Value));
            }

            return selectListData;
        }
    }
}
