using System;

namespace Webservice_MVC.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class Album
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
    }
}
