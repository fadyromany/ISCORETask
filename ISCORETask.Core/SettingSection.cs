
using System.Configuration;
using ConfigurationSection = System.Configuration.ConfigurationSection;

namespace ISCORETask.Core
{
    public class SettingSection : ConfigurationSection
    {
        public string? SqlConnection { get; set; }

    }
}
