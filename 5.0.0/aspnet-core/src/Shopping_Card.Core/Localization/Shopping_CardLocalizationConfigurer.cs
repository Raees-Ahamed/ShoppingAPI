using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Shopping_Card.Localization
{
    public static class Shopping_CardLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(Shopping_CardConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(Shopping_CardLocalizationConfigurer).GetAssembly(),
                        "Shopping_Card.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
