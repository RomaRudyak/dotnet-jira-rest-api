using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JiraApi.Request
{
    public class IssueAttachmentsRequest : IssueRequestBase
    {
        public String FileName { get; set; }
        public Byte[] FileContent { get; set; }

        public IssueAttachmentsRequest(String keyOrId, HttpMethod method)
            : base(keyOrId, method)
        {

        }

        internal override HttpContent BuildHttpBodyContent()
        {
            if (String.IsNullOrWhiteSpace(FileName))
            {
                throw new InvalidOperationException("FileName property required.");
            }

            if (FileContent == null)
            {
                throw new InvalidOperationException("FileContent property required.");
            }

            MultipartFormDataContent content = new MultipartFormDataContent();

            HttpContent fileContent = new ByteArrayContent(FileContent);

            var mimeType = String.Concat("image/", Path.GetExtension(FileName));

            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mimeType);

            content.Add(fileContent, "file", FileName);

            return content;
        }

        protected override void ConfigurPath()
        {
            base.ConfigurPath();
            ExtendPath("attachments");
        }
    }
}
