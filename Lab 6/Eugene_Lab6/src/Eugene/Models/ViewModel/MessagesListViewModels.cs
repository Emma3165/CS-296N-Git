using System.Collections.Generic;
using Eugene.Models;

namespace Eugene.Models.ViewModel
{
    public class MessagesListViewModels
    {
        public IEnumerable<Message> Messages { get; set; }

        public string CurrentCategory { get; set; }

    }
}
