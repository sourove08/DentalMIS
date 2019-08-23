using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace DENTALMIS.Web.Extension
{
    public static class ButtonExtensions
    {
        public static MvcHtmlString Button(this HtmlHelper html, object htmlAttributes)
        {
            return Button(html, "", "submit", new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Generate save button
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static MvcHtmlString SaveButton(this HtmlHelper html)
        {
            return SaveButton(html, new Dictionary<string, object>());
        }

        /// <summary>
        /// Generate save button
        /// </summary>
        /// <param name="html"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString SaveButton(this HtmlHelper html, object htmlAttributes)
        {
            return SaveButton(html, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Generate save button
        /// </summary>
        /// <param name="html"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString SaveButton(this HtmlHelper html, IDictionary<string, object> htmlAttributes)
        {
            if (!htmlAttributes.ContainsKey("title"))
            {
                htmlAttributes.Add("title", "Save");
            }
            if (!htmlAttributes.ContainsKey("class"))
            {
                htmlAttributes.Add("class", "save addButton");

            }
            return Button(html, "Save", "submit", htmlAttributes);
        }


        /// <summary>
        /// Generate delete button
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static MvcHtmlString DeleteButton(this HtmlHelper html)
        {
            return DeleteButton(html, new Dictionary<string, object>());
        }

        /// <summary>
        /// Generate delete button
        /// </summary>
        /// <param name="html"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString DeleteButton(this HtmlHelper html, object htmlAttributes)
        {
            return DeleteButton(html, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Generate delete button
        /// </summary>
        /// <param name="html"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString DeleteButton(this HtmlHelper html, IDictionary<string, object> htmlAttributes)
        {
            if (!htmlAttributes.ContainsKey("title"))
            {
                htmlAttributes.Add("title", "Delete");
            }
            if (!htmlAttributes.ContainsKey("class"))
            {
                htmlAttributes.Add("class", "delete");
            }
            return Button(html, "", "submit", htmlAttributes);
        }

        /// <summary>
        /// Generate edit button
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static MvcHtmlString EditButton(this HtmlHelper html)
        {
            return EditButton(html, new Dictionary<string, object>());
        }

        /// <summary>
        /// Generate edit button
        /// </summary>
        /// <param name="html"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString EditButton(this HtmlHelper html, object htmlAttributes)
        {
            return EditButton(html, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Generate edit button
        /// </summary>
        /// <param name="html"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString EditButton(this HtmlHelper html, IDictionary<string, object> htmlAttributes)
        {
            if (!htmlAttributes.ContainsKey("title"))
            {
                htmlAttributes.Add("title", "Edit");
            }
            if (!htmlAttributes.ContainsKey("class"))
            {
                htmlAttributes.Add("class", "edit");
            }
            return Button(html, "", "submit", htmlAttributes);
        }

        /// <summary>
        /// Generate search button
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static MvcHtmlString SearchButton(this HtmlHelper html)
        {
            return SearchButton(html, new Dictionary<string, object>());
        }

        /// <summary>
        /// Generate search button
        /// </summary>
        /// <param name="html"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString SearchButton(this HtmlHelper html, object htmlAttributes)
        {
            return SearchButton(html, new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// Generate search button
        /// </summary>
        /// <param name="html"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString SearchButton(this HtmlHelper html, IDictionary<string, object> htmlAttributes)
        {
            if (!htmlAttributes.ContainsKey("title"))
            {
                htmlAttributes.Add("title", "Search");
            }
            if (!htmlAttributes.ContainsKey("class"))
            {
                htmlAttributes.Add("class", "search");
            }
            return Button(html, "", "submit", htmlAttributes);
        }

        public static MvcHtmlString Button(this HtmlHelper html, string text, string type, IDictionary<string, object> htmlAttributes)
        {
            var button = new TagBuilder("button");

            button.MergeAttribute("type", type);

            button.MergeAttributes(htmlAttributes);

            button.InnerHtml = text;

            return new MvcHtmlString(button.ToString());
        }

    
        public static MvcHtmlString Button(this HtmlHelper helper, object innerHtml, object htmlAttributes)
        {
            return helper.Button(innerHtml, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, object innerHtml, IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button") { InnerHtml = innerHtml.ToString() };
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString ButtonFor<TModel, TField>(this HtmlHelper<TModel> html,
                                                       Expression<Func<TModel, TField>> property,
                                                       object innerHtml,
                                                       object htmlAttributes)
        {
          
            var attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var name = ExpressionHelper.GetExpressionText(property);
            var metadata = ModelMetadata.FromLambdaExpression(property, html.ViewData);

            string fullName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            ModelState modelState;
            if (html.ViewData.ModelState.TryGetValue(fullName, out modelState) && modelState.Errors.Count > 0)
            {
                if (!attrs.ContainsKey("class")) attrs["class"] = string.Empty;
                attrs["class"] += " " + HtmlHelper.ValidationInputCssClassName;
                attrs["class"] = attrs["class"].ToString().Trim();
            }
            var validation = html.GetUnobtrusiveValidationAttributes(name, metadata);
            if (null != validation) foreach (var v in validation) attrs.Add(v.Key, v.Value);

            string value;
            if (modelState != null && modelState.Value != null)
            {
                value = modelState.Value.AttemptedValue;
            }
            else if (metadata.Model != null)
            {
                value = metadata.Model.ToString();
            }
            else
            {
                value = String.Empty;
            }

            attrs["name"] = name;
            attrs["Value"] = value;
            return html.Button(innerHtml, attrs);
        }
    }
}