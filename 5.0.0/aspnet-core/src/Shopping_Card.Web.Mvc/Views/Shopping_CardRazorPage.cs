using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Shopping_Card.Web.Views
{
    public abstract class Shopping_CardRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected Shopping_CardRazorPage()
        {
            LocalizationSourceName = Shopping_CardConsts.LocalizationSourceName;
        }
    }
}
