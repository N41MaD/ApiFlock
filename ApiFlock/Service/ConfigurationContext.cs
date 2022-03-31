using ApiFlock.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace ApiFlock.Service
{
    public class ConfigurationContext 
    {
        public ConfigurationContext(IConfiguration configuration, IOptions<UserSetting> userSetting, IOptions<GeneralSetting> generalSetting, IOptions<EndPointApiPublicaSetting> endPointApiPublicaSetting)
        {
            Configuration = configuration;
            UserSetting = userSetting;
            GeneralSetting = generalSetting;
            EndPointApiPublicaSetting = endPointApiPublicaSetting;
        }


        public IConfiguration Configuration { get; }
        public IOptions<UserSetting> UserSetting { get; }
        public IOptions<EndPointApiPublicaSetting> EndPointApiPublicaSetting { get; set; }
        public IOptions<GeneralSetting> GeneralSetting { get; }
    }
}
