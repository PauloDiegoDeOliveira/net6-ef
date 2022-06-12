using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DevLabs.Application.Utilities
{
    public class ExtensionSystem
    {
        public string base64Data { get; private set; }

        public string GetExtensaoB64(string base64String)
        {
            if (string.IsNullOrWhiteSpace(base64String)) return null;

            Regex DataUriPattern = new Regex(@"^data\:(?<mimeType>image\/(?<imageType>png|tiff|jpg|gif|jpeg|svg+xml|svg));base64,(?<data>[A-Z0-9\+\/\=]+)$", RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase);

            Match match = DataUriPattern.Match(base64String);
            if (!match.Success) return null;

            string imageType = match.Groups["imageType"].Value;
            base64Data = match.Groups["data"].Value;

            string extensao = ModificaExtensao(imageType);

            return extensao;
        }

        private string ModificaExtensao(string extensao)
        {
            Dictionary<string, string> extensoes = new Dictionary<string, string> {
                { "svg+xml", "svg"}
            };

            if (extensoes.ContainsKey(extensao))
                extensao = extensoes[extensao];

            return extensao;
        }
    }
}