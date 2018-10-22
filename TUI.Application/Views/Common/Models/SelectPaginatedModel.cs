using System.ComponentModel.DataAnnotations;

namespace TUI.Application.Views.Common.Models
{
    public class SelectPaginatedModel
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string KeyJSONKey { get; set; }

        [Required]
        public string ValueJSONKey { get; set; }

        [Required]
        public string Url { get; set; }
    }
}
