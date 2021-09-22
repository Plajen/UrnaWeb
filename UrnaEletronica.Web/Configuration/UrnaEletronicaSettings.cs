using System;
using Microsoft.Extensions.Options;
using UrnaEletronica.Web.Configuration.Interfaces;

namespace UrnaEletronica.Web.Configuration
{
    public class UrnaEletronicaSettings : IUrnaEletronicaSettings
    {
        private readonly Settings _options;

        public UrnaEletronicaSettings(IOptions<Settings> options)
        {
            _options = options != null ? options.Value : throw new ArgumentNullException(nameof(options));
        }

        public string ApiUrl => _options.ApiUrl;
    }

    public class Settings
    {
        public string ApiUrl { get; set; }
    }
}
