using MVCSecondCode.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCSecondCode
{
    [Table("TB_M_LOGIN")]
    public class Login : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}