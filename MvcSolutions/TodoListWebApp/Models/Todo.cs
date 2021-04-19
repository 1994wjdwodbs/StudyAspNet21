using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListWebApp.Models
{
    public class Todo
    {
        [Key] // 기본 키
        public int Id { get; set; }

        [Required(ErrorMessage = "제목은 필수입니다.")] // NOT NULL
        public string Title { get; set; }
        
        public bool IsDone { get; set; }
        
        public DateTime CreationDate { get; set; }
    }
}
