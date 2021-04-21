using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyPortpolio.Models
{
    public class Contact
    {
        // DataAnnotation
        // : ASP.NET MVC 및 ASP.NET 데이터 컨트롤의 메타데이터를 정의하는 데 사용되는 특성 클래스를 제공합니다.

        // KeyAttribute
        // : 엔터티를 고유하게 식별하는 속성을 하나 이상 나타냅니다.
        // DataTypeAttribute
        // : 데이터 필드에 연결할 추가 형식의 이름을 지정합니다.

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "이름을 입력하세요.")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public String Name { get; set; }

        [Required(ErrorMessage = "이메일을 입력하세요.")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required(ErrorMessage = "내용을 입력하세요.")]
        [DataType(DataType.Text)]
        public String Contents { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime RegDate { get; set; }
    }
}
