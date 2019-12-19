using Abp.AspNetCore.Mvc.ViewComponents;

namespace Shopping_Card.Web.Views
{
    public abstract class Shopping_CardViewComponent : AbpViewComponent
    {
        protected Shopping_CardViewComponent()
        {
            LocalizationSourceName = Shopping_CardConsts.LocalizationSourceName;
        }
    }
}
